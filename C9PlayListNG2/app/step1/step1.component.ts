import {Component, OnInit} from '@angular/core';
import {ROUTER_DIRECTIVES} from '@angular/router';

import {SiteSettingService} from '../service/site.setting.service';
import {ISiteSetting} from '../service/static.model';
import {PlayListService} from '../service/playlist.service';



@Component({
   templateUrl:'app/step1/step1.component.html' ,
   directives:[ROUTER_DIRECTIVES] 
})
export class Step1Component implements OnInit{
    input1:number;
    siteSetting:ISiteSetting;
    errorMessage: string;
    wholePlaylist:any[];
    displayedList:any[]=[];

    constructor(private _siteSettingService:SiteSettingService,
                private _playlistService: PlayListService){}  
    
  
    
    ngOnInit(){
        this._siteSettingService.getSiteSetting()
            .subscribe(result=> this.siteSetting = result,  
            error => this.errorMessage = error);  

        this._playlistService.getWholeList()
        .subscribe(result=> this.wholePlaylist = result,  
        error => this.errorMessage = error);  

    };


    randomNumber(inValue: number){
       if (this.wholePlaylist && this.wholePlaylist.length ) {
           this.displayedList=[];
           for (var i = 0; i < inValue; i++) {
               this.displayedList.push(this.wholePlaylist[Math.round(Math.random()  * this.wholePlaylist.length)]);               
           }
       }

    };

    
}
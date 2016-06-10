import {Component, OnInit} from '@angular/core';
import {ROUTER_DIRECTIVES} from '@angular/router';

import {SiteSettingService} from '../service/site.setting.service';
import {ISiteSetting, TrackListItemViewModel} from '../service/static.model';
import {PlayListService} from '../service/playlist.service';
import {SongItemSortPipe} from '../pipe/item.sort.pipe';


@Component({
   templateUrl:'app/step1/step1.component.html' ,
   directives:[ROUTER_DIRECTIVES] ,
   pipes:[SongItemSortPipe]
})
export class Step1Component implements OnInit{
    noofitems:number;
    siteSetting:ISiteSetting;
    errorMessage: string;
    displayedList:TrackListItemViewModel[];
    inMemoryList:TrackListItemViewModel[];


    constructor(private _siteSettingService:SiteSettingService,
                private _playlistService: PlayListService){}  
    
  
    
    ngOnInit(){
        this._siteSettingService.getSiteSetting()
            .subscribe(result=> this.siteSetting = result,  
            error => this.errorMessage = error);  

    };


    private randomIntInRange(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }


    shuffle(){
        if (this.inMemoryList && this.inMemoryList.length ) {
           this.displayedList=[]
           for (let i = 0; i < this.inMemoryList.length-1; i++) {
               this.displayedList.push(this.inMemoryList[this.randomIntInRange(0,this.inMemoryList.length-1)]);               
           }
       }

    };

    getResult(inText:string){
        this.displayedList=[] ;
        this._playlistService.getListByFreeText(inText, this.noofitems)
        .subscribe(result=> {
            result.tracks.items.forEach(x => {
                if (x.album !== null){
                    if (x.album.images!== null) {
                        this.displayedList.push(
                            {
                                imgUri: x.album.images[0].url,
                                title: x.album.name,
                                Id: x.album.id,
                                link: x.external_urls.spotify
                            }                    
                        )
                    }

                }

                
            });

           
           /*
            for (let i = 0; i < result.tracks.items.length; i++) {
                if (result.tracks.items[i].album.images != null) {
                        this.displayedList.push(
                        {
                            imgUri: result.tracks.items[i].album.images[0].url,
                            title: result.tracks.items[i].album.name,
                            Id: result.tracks.items[i].album.id,
                            link: result.tracks.items[i].external_urls.spotify
                        }                    
                    )
                }else{
                    this.displayedList.push(
                        {
                            imgUri: "",
                            title: result.tracks.items[i].album.name,
                            Id: result.tracks.items[i].album.id,
                            link: result.tracks.items[i].external_urls.spotify
                        }
                    )
                }


            }
            */








            this.inMemoryList = this.displayedList;  

             
        }, 

        error => this.errorMessage = error); 
    };




    
}
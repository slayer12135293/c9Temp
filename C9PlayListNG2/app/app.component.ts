import {Component, OnInit} from '@angular/core';
import {Routes,Router, ROUTER_DIRECTIVES,ROUTER_PROVIDERS } from '@angular/router';
import { HTTP_PROVIDERS } from '@angular/http';
import 'rxjs/Rx';   // Load all features
import {Step1Component} from './step1/step1.component';
import {SiteSettingService} from './service/site.setting.service';
import {ISiteSetting} from './service/static.model';
import {PlayListService} from './service/playlist.service';


@Component({
    selector: 'c9-app',
    template: `
        <section class="container">
            <section class="row" *ngIf='siteSetting'>
                <section class="col-md-12 banner" >
                 {{siteSetting.bannerText}}   
                </section>    
            </section>
        </section>
        <router-outlet></router-outlet>       
    `,
    styleUrls:['app/app.component.css'],
    providers:[HTTP_PROVIDERS,ROUTER_PROVIDERS, SiteSettingService,PlayListService],
    directives:[ROUTER_DIRECTIVES]
    
})

@Routes([
    { path: '/', component: Step1Component },
    { path: '/step1', component: Step1Component }
])
export class AppComponent implements OnInit {
    siteSetting:ISiteSetting;
    errorMessage:string;    
    constructor(private _router: Router, 
                private _siteSettingService:SiteSettingService){}    
    
    ngOnInit(){
        this._siteSettingService.getSiteSetting()
            .subscribe(result=> this.siteSetting = result,  
            error => this.errorMessage = error);     
    };


    
}



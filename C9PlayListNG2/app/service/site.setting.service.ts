import {Injectable} from '@angular/core';
import {Http, Response } from '@angular/http';
import {Observable } from 'rxjs/Observable';
import {ISiteSetting} from './static.model';

@Injectable()
export class SiteSettingService{
    private _settingUrl = "app/api/site-setting.json";
    constructor(private _http: Http){}

    getSiteSetting(): Observable<ISiteSetting>{
        return this._http.get(this._settingUrl)
        .map((response:Response)=><ISiteSetting>response.json())
        .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }



}
import {Injectable} from '@angular/core';
import {Http, Response } from '@angular/http';
import {Observable } from 'rxjs/Observable';


@Injectable()
export class PlayListService{
    private _settingUrl = "http://jsonplaceholder.typicode.com/comments";
    constructor(private _http: Http){}

    getWholeList(): Observable<any[]>{
        return this._http.get(this._settingUrl)
        .map((response:Response)=><any[]>response.json())
        .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }



}
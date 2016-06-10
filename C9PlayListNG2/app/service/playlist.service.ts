import {Injectable} from '@angular/core';
import {Http, Response } from '@angular/http';
import {Observable } from 'rxjs/Observable';


@Injectable()
export class PlayListService{
    private _settingUrl = "https://api.spotify.com/v1/search?";
    constructor(private _http: Http){}

    getWholeList(): Observable<any>{
        return this._http.get(this._settingUrl+"q=opeth&type=track")
        .map((response:Response)=><any[]>response.json())
        .catch(this.handleError);
    }
    getListByFreeText(inText:string, inNumber:number): Observable<any>{
        let limit = 50
        if (inNumber>0) {
            limit = inNumber;
        }

        return this._http.get(this._settingUrl+"q="+inText+"&type=track&offset=100&limit="+limit)
        .map((response:Response)=>response.json())
        //.do(data => console.log('All: ' +  JSON.stringify(data)))
        .catch(this.handleError);
        
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }



}
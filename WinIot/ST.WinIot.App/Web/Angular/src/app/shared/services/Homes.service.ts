﻿

//*************************DO NOT MODIFY**************************
//
//THESE FILES ARE AUTOGENERATED WITH TYPEWRITER AND ANY MODIFICATIONS MADE HERE WILL BE LOST
//PLEASE VISIT http://frhagn.github.io/Typewriter/ TO LEARN MORE ABOUT THIS VISUAL STUDIO EXTENSION
//
//*************************DO NOT MODIFY**************************
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'; 
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
//ST.Web.API
import { Home } from '../classes/Home';
import { GlobalService } from "../../global.service";
//Remote Call
@Injectable()
export class HomesService {
    constructor(private _httpClient: HttpClient, private global: GlobalService) { }        
    
    // get: Manage/Homes      
    getHomes(): Observable<Home[]> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Homes`;
            return this._httpClient.get<Home[]>(_Url)
                .catch(this.handleError);
    }
    
    // get: Manage/Homes/${encodeURIComponent(id)}      
    getHome(id: string): Observable<Home> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Homes/${encodeURIComponent(id)}`;
            return this._httpClient.get<Home>(_Url)
                .catch(this.handleError);
    }
    
    // put: Manage/Homes/${encodeURIComponent(id)}      
    putHome(id: string, home: Home): Observable<void> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Homes/${encodeURIComponent(id)}`;
            return this._httpClient.put<void>(_Url, home)
                .catch(this.handleError);
    }
    
    // post: Manage/Homes      
    postHome(home: Home): Observable<Home> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Homes`;
            return this._httpClient.post<Home>(_Url, home)
                .catch(this.handleError);
    }
    
    // delete: Manage/Homes/${encodeURIComponent(id)}      
    deleteHome(id: string): Observable<Home> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Homes/${encodeURIComponent(id)}`;
            return this._httpClient.delete<Home>(_Url)
                .catch(this.handleError);
    }
    
    // Utility
    private handleError(error: HttpErrorResponse) {
        console.error(error);
        let customError: string = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText
        }
        return Observable.throw(customError || 'Server error');
    }
}
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
import { Piece } from '../classes/Piece';
import { GlobalService } from "../../global.service";
//Remote Call
@Injectable()
export class PiecesService {
    constructor(private _httpClient: HttpClient, private global: GlobalService) { }        
    
    // get: Manage/Pieces      
    getPieces(): Observable<Piece[]> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Pieces`;
            return this._httpClient.get<Piece[]>(_Url)
                .catch(this.handleError);
    }
    
    // get: Manage/Pieces/${encodeURIComponent(id)}      
    getPiece(id: string): Observable<Piece> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Pieces/${encodeURIComponent(id)}`;
            return this._httpClient.get<Piece>(_Url)
                .catch(this.handleError);
    }
    
    // put: Manage/Pieces/${encodeURIComponent(id)}      
    putPiece(id: string, piece: Piece): Observable<void> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Pieces/${encodeURIComponent(id)}`;
            return this._httpClient.put<void>(_Url, piece)
                .catch(this.handleError);
    }
    
    // post: Manage/Pieces      
    postPiece(piece: Piece): Observable<Piece> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Pieces`;
            return this._httpClient.post<Piece>(_Url, piece)
                .catch(this.handleError);
    }
    
    // delete: Manage/Pieces/${encodeURIComponent(id)}      
    deletePiece(id: string): Observable<Piece> {
        var _Url = this.global.ApiConfig.apiServer + `/Manage/Pieces/${encodeURIComponent(id)}`;
            return this._httpClient.delete<Piece>(_Url)
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

import {HttpErrorResponse } from '@angular/common/http'; 
export interface IApiError {
    httpError: HttpErrorResponse;
    customText: string;
}

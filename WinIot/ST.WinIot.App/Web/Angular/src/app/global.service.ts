import { Injectable } from '@angular/core';
import { MyAngularConfig } from "./shared/classes/MyAngularConfig";
import { AuthConfig } from 'angular-oauth2-oidc';
@Injectable()
export class GlobalService {
    constructor() {
        
    }
    ApiConfig: MyAngularConfig;
    AuthConfig: AuthConfig;
}

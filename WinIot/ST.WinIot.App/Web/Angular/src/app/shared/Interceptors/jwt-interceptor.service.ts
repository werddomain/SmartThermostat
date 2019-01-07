import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { OAuthService } from 'angular-oauth2-oidc';
//Maybe this is not needed. Maybe the oauth2 allredy do this (It can be configured : https://github.com/manfredsteyer/angular-oauth2-oidc#calling-a-web-api-with-an-access-token)
//Reference doc : http://jasonwatmore.com/post/2018/11/16/angular-7-jwt-authentication-example-tutorial
@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: OAuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let connected = this.authenticationService.hasValidAccessToken();
        if (connected) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.authenticationService.getAccessToken()}`
                }
            });
        }

        return next.handle(request);
    }
}

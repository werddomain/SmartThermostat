import { OAuthService } from 'angular-oauth2-oidc';
import { Injectable } from '@angular/core';
import { Promise } from 'q';



@Injectable()
export class KazoAuthWrapper {

  constructor(private oauthService: OAuthService) {
    
    }

    loginWithPassword(userName: string, password: string) {
        return this.oauthService
            .fetchTokenUsingPasswordFlow(
                userName,
                password
            );
    }
    login() {
        this.oauthService.initImplicitFlow();
    }
}

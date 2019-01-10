import { Injectable } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc'; //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k
import { AngularService } from "./shared/services/AngularConfig.service"
import { GlobalService } from "./global.service";
import 'rxjs/add/operator/toPromise';
@Injectable()
export class AppLoadService {
    constructor(private oauthService: OAuthService, private configService: AngularService, private global: GlobalService) {
        //Doc source : https://www.intertech.com/Blog/angular-4-tutorial-run-code-during-app-initialization/
    }
    loadSettings(): Promise<any> {
        console.log("loadSetting fired")
        const promise = this.configService.getAuth().toPromise().then(o => {
            var openIdConfig = o.authServer + "/.well-known/openid-configuration";
            
            this.global.ApiConfig = o;

            //https://www.linkedin.com/pulse/implicit-flow-authentication-using-angular-ghanshyam-shukla
            this.oauthService.redirectUri = window.location.origin;
            this.oauthService.clientId = o.clientId;
            this.oauthService.scope = o.scope;
            this.oauthService.issuer = o.authServer;
            this.oauthService.tokenValidationHandler = new JwksValidationHandler();
            console.log("ApiCongig Received ::", o);
            console.log("Load config at " + openIdConfig);
            return this.oauthService.loadDiscoveryDocument();//"https://dev.kazo.ca/auth/.well-known/openid-configuration"

        }).catch(raison => {
            console.error("Load settings failed", raison);
            });
        return promise;
    }
}

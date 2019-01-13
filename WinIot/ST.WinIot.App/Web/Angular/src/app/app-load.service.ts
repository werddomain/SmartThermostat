import { Injectable } from '@angular/core';
import { OAuthService, JwksValidationHandler, AuthConfig } from 'angular-oauth2-oidc'; //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k
import { AngularService } from "./shared/services/AngularConfig.service"
import { GlobalService } from "./global.service";
import 'rxjs/add/operator/toPromise';
import { debug } from 'util';
@Injectable()
export class AppLoadService {
    constructor(private oauthService: OAuthService, private configService: AngularService, private global: GlobalService, private authConfig: AuthConfig) {
        //Doc source : https://www.intertech.com/Blog/angular-4-tutorial-run-code-during-app-initialization/
    }
    loadSettings(): Promise<any> {
        console.log("loadSetting fired")
        this.global.AuthConfig = this.authConfig;
        debug;
        console.log("AuthConfig Service", this.authConfig);
        const promise = this.configService.getAuth().toPromise().then(o => {
            var openIdConfig = o.authServer + "/.well-known/openid-configuration";
            
            this.global.ApiConfig = o;

            //https://www.linkedin.com/pulse/implicit-flow-authentication-using-angular-ghanshyam-shukla
            this.global.AuthConfig.redirectUri = window.location.origin + '/ng/index.html';
            this.global.AuthConfig.clientId = o.clientId;
            this.global.AuthConfig.scope = o.scope;
            this.global.AuthConfig.issuer = o.authServer;
            this.oauthService.tokenValidationHandler = new JwksValidationHandler();
            


            //    {
            //    clientId: o.clientId,
            //    issuer: o.authServer,
            //    redirectUri: window.location.origin + '/ng/index.html',
            //    scope: o.scope,
            //    responseType: "code",
            //    oidc: true,


            //};
            this.oauthService.configure(this.global.AuthConfig);
            this.oauthService.setStorage(sessionStorage);

            console.log("ApiCongig Received ::", o);
            console.log("Load config at " + openIdConfig);
            return this.oauthService.loadDiscoveryDocument();//"https://dev.kazo.ca/auth/.well-known/openid-configuration"

        }).catch(raison => {
            console.error("Load settings failed", raison);
            });
        return promise;
    }
}

import { Component, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc'; //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k
import { AngularService } from "./shared/services/AngularConfig.service"
import { GlobalService } from "./global.service";
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
    constructor(private oauthService: OAuthService, private configService: AngularService, private global: GlobalService) {

        
        // Load Discovery Document and then try to login the user
        
            this.oauthService.tryLogin();
       


    }

    ngOnInit() {
    }
}

import { Component, OnInit } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc'; //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  constructor(private oauthService: OAuthService) {
    this.oauthService.redirectUri = window.location.origin;
    this.oauthService.clientId = '{client-id}';
    this.oauthService.scope = 'openid profile email';
    this.oauthService.issuer = 'https://dev-{dev-id}.oktapreview.com';
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();

    // Load Discovery Document and then try to login the user
    this.oauthService.loadDiscoveryDocument().then(() => {
      this.oauthService.tryLogin();
    });
  }

  ngOnInit() {
  }
}

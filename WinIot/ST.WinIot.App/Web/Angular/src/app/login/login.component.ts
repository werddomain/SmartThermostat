import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { routerTransition } from '../router.animations';
import { KazoAuthWrapper } from '../shared';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.less'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    constructor(
        private translate: TranslateService,
        public router: Router,
        private oauthService: OAuthService,
        private kazoAuthWrapper: KazoAuthWrapper
    ) {
        this.translate.addLangs(['en', 'fr', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
        this.translate.setDefaultLang('en');
        const browserLang = this.translate.getBrowserLang();
        this.translate.use(browserLang.match(/en|fr|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
    }
    username: string;
    password: string;
    loginFailed: boolean;

    ngOnInit() { }
    loginOnAuthWebsite() {
        this.kazoAuthWrapper.login();
    }
    loginWithPassword() {
        //localStorage.setItem('isLoggedin', 'true');
        this.kazoAuthWrapper.loginWithPassword(this.username, this.password)
            .then(_ => {
                console.debug('logged in');
                this.loginFailed = false;
                this.router.navigate(['/dashboard']);
            })
            .catch(err => {
                console.error('error logging in', err);
                this.loginFailed = true;
            });
    }
}

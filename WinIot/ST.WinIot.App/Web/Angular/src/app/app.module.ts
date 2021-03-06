import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard, KazoAuthWrapper } from './shared';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OAuthService, OAuthModule, UrlHelperService, OAuthLogger, AuthConfig } from 'angular-oauth2-oidc';
import { GlobalService } from "./global.service";

import { ServicesModule } from './shared/services/services.module'
import { JwtInterceptor } from "./shared/Interceptors/jwt-interceptor.service"
import { AppLoadService } from "./app-load.service"
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';


// AoT requires an exported function for factories
export const createTranslateLoader = (http: HttpClient) => {
  /* for development
  return new TranslateHttpLoader(
      http,
      '/start-angular/SB-Admin-BS4-Angular-6/master/dist/assets/i18n/',
      '.json'
  ); */
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
};
//This value is only used if we use ng serve. Else we override this when we call the Angular mvc Api 'config/GetAuth'
const authConfig: AuthConfig = {
    issuer: "https://dev.kazo.ca/auth",
    clientId: "Jsd8sd7Sd6sdnsdf8sdf6jKJdsf784f45sf7SDf98sdfSdfnsdfjsdf7sdf8s7dfsdf",
    scope: "openid profile GoogleSmartHome",
    redirectUri: window.location.origin + '/index.html',
    oidc: true
}
export function load_settings(appLoadService: AppLoadService) {
    return () => appLoadService.loadSettings();
}
@NgModule({
  imports: [
    MatIconModule,
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      NgbModule,
      NgBootstrapFormValidationModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    }),
    AppRoutingModule,
      OAuthModule.forRoot(),
      ServicesModule.forRoot()
  ],
  declarations: [AppComponent],
    providers: [
        GlobalService,
        AuthGuard,
        KazoAuthWrapper,
        { provide: AuthConfig, useValue: authConfig },
        OAuthService,
        AppLoadService,
        { provide: APP_INITIALIZER, useFactory: load_settings, deps: [AppLoadService], multi: true },
        UrlHelperService,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
    constructor() {
       
    }
}

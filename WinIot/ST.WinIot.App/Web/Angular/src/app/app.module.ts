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
import { FormsModule } from '@angular/forms';
import { OAuthService, OAuthModule, UrlHelperService, OAuthLogger } from 'angular-oauth2-oidc';
import { GlobalService } from "./global.service";
import { AngularService } from "./shared/services/AngularConfig.service"
import { JwtInterceptor } from "./shared/Interceptors/jwt-interceptor.service"
import { AppLoadService } from "./app-load.service"
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
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    }),
    AppRoutingModule,
    OAuthModule.forRoot()
  ],
  declarations: [AppComponent],
    providers: [
        GlobalService,
        AngularService,
        AuthGuard,
        KazoAuthWrapper,
        OAuthService,
        AppLoadService,
        { provide: APP_INITIALIZER, useFactory: load_settings, deps: [AppLoadService], multi: true },
        UrlHelperService,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

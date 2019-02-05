(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

var map = {
	"./access-denied/access-denied.module.ngfactory": [
		"./src/app/access-denied/access-denied.module.ngfactory.js",
		"access-denied-access-denied-module-ngfactory"
	],
	"./blank-page/blank-page.module.ngfactory": [
		"./src/app/layout/blank-page/blank-page.module.ngfactory.js",
		"blank-page-blank-page-module-ngfactory"
	],
	"./bs-component/bs-component.module.ngfactory": [
		"./src/app/layout/bs-component/bs-component.module.ngfactory.js",
		"common",
		"bs-component-bs-component-module-ngfactory"
	],
	"./bs-element/bs-element.module.ngfactory": [
		"./src/app/layout/bs-element/bs-element.module.ngfactory.js",
		"common",
		"bs-element-bs-element-module-ngfactory"
	],
	"./charts/charts.module.ngfactory": [
		"./src/app/layout/charts/charts.module.ngfactory.js",
		"common",
		"charts-charts-module-ngfactory"
	],
	"./dashboard/dashboard.module.ngfactory": [
		"./src/app/layout/dashboard/dashboard.module.ngfactory.js",
		"common",
		"dashboard-dashboard-module-ngfactory"
	],
	"./form/form.module.ngfactory": [
		"./src/app/layout/form/form.module.ngfactory.js",
		"common",
		"form-form-module-ngfactory"
	],
	"./grid/grid.module.ngfactory": [
		"./src/app/layout/grid/grid.module.ngfactory.js",
		"common",
		"grid-grid-module-ngfactory"
	],
	"./home/home.module.ngfactory": [
		"./src/app/layout/setup/home/home.module.ngfactory.js",
		"common",
		"home-home-module-ngfactory"
	],
	"./homepage/homepage.module.ngfactory": [
		"./src/app/layout/homepage/homepage.module.ngfactory.js",
		"common",
		"homepage-homepage-module-ngfactory"
	],
	"./layout/layout.module.ngfactory": [
		"./src/app/layout/layout.module.ngfactory.js",
		"common",
		"layout-layout-module-ngfactory"
	],
	"./login/login.module.ngfactory": [
		"./src/app/login/login.module.ngfactory.js",
		"common",
		"login-login-module-ngfactory"
	],
	"./not-found/not-found.module.ngfactory": [
		"./src/app/not-found/not-found.module.ngfactory.js",
		"not-found-not-found-module-ngfactory"
	],
	"./pieces/pieces.module.ngfactory": [
		"./src/app/layout/setup/pieces/pieces.module.ngfactory.js",
		"common",
		"pieces-pieces-module-ngfactory"
	],
	"./server-error/server-error.module.ngfactory": [
		"./src/app/server-error/server-error.module.ngfactory.js",
		"server-error-server-error-module-ngfactory"
	],
	"./setup/setup.module.ngfactory": [
		"./src/app/layout/setup/setup.module.ngfactory.js",
		"common",
		"setup-setup-module-ngfactory"
	],
	"./signup/signup.module.ngfactory": [
		"./src/app/signup/signup.module.ngfactory.js",
		"signup-signup-module-ngfactory"
	],
	"./tables/tables.module.ngfactory": [
		"./src/app/layout/tables/tables.module.ngfactory.js",
		"common",
		"tables-tables-module-ngfactory"
	]
};
function webpackAsyncContext(req) {
	var ids = map[req];
	if(!ids) {
		return Promise.resolve().then(function() {
			var e = new Error("Cannot find module '" + req + "'");
			e.code = 'MODULE_NOT_FOUND';
			throw e;
		});
	}
	return Promise.all(ids.slice(1).map(__webpack_require__.e)).then(function() {
		var id = ids[0];
		return __webpack_require__(id);
	});
}
webpackAsyncContext.keys = function webpackAsyncContextKeys() {
	return Object.keys(map);
};
webpackAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";
module.exports = webpackAsyncContext;

/***/ }),

/***/ "./src/app/app-load.service.ts":
/*!*************************************!*\
  !*** ./src/app/app-load.service.ts ***!
  \*************************************/
/*! exports provided: AppLoadService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppLoadService", function() { return AppLoadService; });
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");
/* harmony import */ var _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./shared/services/AngularConfig.service */ "./src/app/shared/services/AngularConfig.service.ts");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./global.service */ "./src/app/global.service.ts");
/* harmony import */ var rxjs_add_operator_toPromise__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/add/operator/toPromise */ "./node_modules/rxjs-compat/_esm5/add/operator/toPromise.js");
/* harmony import */ var rxjs_add_operator_toPromise__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(rxjs_add_operator_toPromise__WEBPACK_IMPORTED_MODULE_3__);
 //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k



var AppLoadService = /** @class */ (function () {
    function AppLoadService(oauthService, configService, global, authConfig) {
        this.oauthService = oauthService;
        this.configService = configService;
        this.global = global;
        this.authConfig = authConfig;
        //Doc source : https://www.intertech.com/Blog/angular-4-tutorial-run-code-during-app-initialization/
    }
    AppLoadService.prototype.loadSettings = function () {
        var _this = this;
        this.global.AuthConfig = this.authConfig;
        var promise = this.configService.getAuth().toPromise().then(function (o) {
            var openIdConfig = o.authServer + "/.well-known/openid-configuration";
            _this.global.ApiConfig = o;
            //https://www.linkedin.com/pulse/implicit-flow-authentication-using-angular-ghanshyam-shukla
            _this.global.AuthConfig.redirectUri = window.location.origin + '/ng/index.html';
            _this.global.AuthConfig.clientId = o.clientId;
            _this.global.AuthConfig.scope = o.scope;
            _this.global.AuthConfig.issuer = o.authServer;
            _this.oauthService.tokenValidationHandler = new angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_0__["JwksValidationHandler"]();
            //    {
            //    clientId: o.clientId,
            //    issuer: o.authServer,
            //    redirectUri: window.location.origin + '/ng/index.html',
            //    scope: o.scope,
            //    responseType: "code",
            //    oidc: true,
            //};
            _this.oauthService.configure(_this.global.AuthConfig);
            _this.oauthService.setStorage(sessionStorage);
            console.log("ApiCongig Received ::", o);
            console.log("Load config at " + openIdConfig);
            return _this.oauthService.loadDiscoveryDocument(); //"https://dev.kazo.ca/auth/.well-known/openid-configuration"
        }).catch(function (raison) {
            console.error("Load settings failed", raison);
            _this.oauthService.configure(_this.global.AuthConfig);
            _this.oauthService.setStorage(sessionStorage);
            _this.global.ApiConfig = {
                apiServer: "https://dev.kazo.ca/API",
                authServer: "https://dev.kazo.ca/Auth",
                websiteName: "Kazo",
                websiteShortName: "Kazo",
                clientId: _this.global.AuthConfig.clientId,
                scope: _this.global.AuthConfig.scope
            };
            return _this.oauthService.loadDiscoveryDocument(); //"https://dev.kazo.ca/auth/.well-known/openid-configuration"
        });
        return promise;
    };
    return AppLoadService;
}());



/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shared_guard__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./shared/guard */ "./src/app/shared/guard/index.ts");


var routes = [
    { path: '', loadChildren: './layout/layout.module#LayoutModule', canActivate: [_shared_guard__WEBPACK_IMPORTED_MODULE_1__["AuthGuard"]] },
    { path: 'login', loadChildren: './login/login.module#LoginModule' },
    { path: 'signup', loadChildren: './signup/signup.module#SignupModule' },
    { path: 'error', loadChildren: './server-error/server-error.module#ServerErrorModule' },
    { path: 'access-denied', loadChildren: './access-denied/access-denied.module#AccessDeniedModule' },
    { path: 'not-found', loadChildren: './not-found/not-found.module#NotFoundModule' },
    { path: '**', redirectTo: 'not-found' }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    return AppRoutingModule;
}());



/***/ }),

/***/ "./src/app/app.component.less.shim.ngstyle.js":
/*!****************************************************!*\
  !*** ./src/app/app.component.less.shim.ngstyle.js ***!
  \****************************************************/
/*! exports provided: styles */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "styles", function() { return styles; });
/**
 * @fileoverview This file was generated by the Angular template compiler. Do not edit.
 *
 * @suppress {suspiciousCode,uselessCode,missingProperties,missingOverride,checkTypes}
 * tslint:disable
 */ 
var styles = ["\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQubGVzcyJ9 */"];



/***/ }),

/***/ "./src/app/app.component.ngfactory.js":
/*!********************************************!*\
  !*** ./src/app/app.component.ngfactory.js ***!
  \********************************************/
/*! exports provided: RenderType_AppComponent, View_AppComponent_0, View_AppComponent_Host_0, AppComponentNgFactory */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RenderType_AppComponent", function() { return RenderType_AppComponent; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "View_AppComponent_0", function() { return View_AppComponent_0; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "View_AppComponent_Host_0", function() { return View_AppComponent_Host_0; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponentNgFactory", function() { return AppComponentNgFactory; });
/* harmony import */ var _app_component_less_shim_ngstyle__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./app.component.less.shim.ngstyle */ "./src/app/app.component.less.shim.ngstyle.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");
/* harmony import */ var _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./shared/services/AngularConfig.service */ "./src/app/shared/services/AngularConfig.service.ts");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./global.service */ "./src/app/global.service.ts");
/**
 * @fileoverview This file was generated by the Angular template compiler. Do not edit.
 *
 * @suppress {suspiciousCode,uselessCode,missingProperties,missingOverride,checkTypes}
 * tslint:disable
 */ 







var styles_AppComponent = [_app_component_less_shim_ngstyle__WEBPACK_IMPORTED_MODULE_0__["styles"]];
var RenderType_AppComponent = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵcrt"]({ encapsulation: 0, styles: styles_AppComponent, data: {} });

function View_AppComponent_0(_l) { return _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵvid"](0, [(_l()(), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵeld"](0, 16777216, null, null, 1, "router-outlet", [], null, null, null, null, null)), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵdid"](1, 212992, null, 0, _angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterOutlet"], [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ChildrenOutletContexts"], _angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewContainerRef"], _angular_core__WEBPACK_IMPORTED_MODULE_1__["ComponentFactoryResolver"], [8, null], _angular_core__WEBPACK_IMPORTED_MODULE_1__["ChangeDetectorRef"]], null, null)], function (_ck, _v) { _ck(_v, 1, 0); }, null); }
function View_AppComponent_Host_0(_l) { return _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵvid"](0, [(_l()(), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵeld"](0, 0, null, null, 1, "app-root", [], null, null, null, View_AppComponent_0, RenderType_AppComponent)), _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵdid"](1, 114688, null, 0, _app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"], [angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_4__["OAuthService"], _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_5__["AngularService"], _global_service__WEBPACK_IMPORTED_MODULE_6__["GlobalService"]], null, null)], function (_ck, _v) { _ck(_v, 1, 0); }, null); }
var AppComponentNgFactory = _angular_core__WEBPACK_IMPORTED_MODULE_1__["ɵccf"]("app-root", _app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"], View_AppComponent_Host_0, {}, {}, []);



/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");
/* harmony import */ var _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./shared/services/AngularConfig.service */ "./src/app/shared/services/AngularConfig.service.ts");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./global.service */ "./src/app/global.service.ts");

 //https://dev.to/ped4enko/how-to-build-an-angular-app-with-authentication-in-30-minutes-506k


var AppComponent = /** @class */ (function () {
    function AppComponent(oauthService, configService, global) {
        // Load Discovery Document and then try to login the user
        this.oauthService = oauthService;
        this.configService = configService;
        this.global = global;
        this.oauthService.tryLogin();
    }
    AppComponent.prototype.ngOnInit = function () {
    };
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ngfactory.js":
/*!*****************************************!*\
  !*** ./src/app/app.module.ngfactory.js ***!
  \*****************************************/
/*! exports provided: AppModuleNgFactory */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModuleNgFactory", function() { return AppModuleNgFactory; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _app_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./app.module */ "./src/app/app.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../node_modules/@ng-bootstrap/ng-bootstrap/ng-bootstrap.ngfactory */ "./node_modules/@ng-bootstrap/ng-bootstrap/ng-bootstrap.ngfactory.js");
/* harmony import */ var _node_modules_angular_router_router_ngfactory__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../node_modules/@angular/router/router.ngfactory */ "./node_modules/@angular/router/router.ngfactory.js");
/* harmony import */ var _app_component_ngfactory__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app.component.ngfactory */ "./src/app/app.component.ngfactory.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/animations/browser */ "./node_modules/@angular/animations/fesm5/browser.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_animations__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/animations */ "./node_modules/@angular/animations/fesm5/animations.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");
/* harmony import */ var _shared_Interceptors_jwt_interceptor_service__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./shared/Interceptors/jwt-interceptor.service */ "./src/app/shared/Interceptors/jwt-interceptor.service.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @ng-bootstrap/ng-bootstrap */ "./node_modules/@ng-bootstrap/ng-bootstrap/fesm5/ng-bootstrap.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ng-bootstrap-form-validation */ "./node_modules/ng-bootstrap-form-validation/fesm5/ng-bootstrap-form-validation.js");
/* harmony import */ var _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @ngx-translate/core */ "./node_modules/@ngx-translate/core/fesm5/ngx-translate-core.js");
/* harmony import */ var _shared_services_Devices_service__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./shared/services/Devices.service */ "./src/app/shared/services/Devices.service.ts");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./global.service */ "./src/app/global.service.ts");
/* harmony import */ var _shared_services_DeviceTraits_service__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./shared/services/DeviceTraits.service */ "./src/app/shared/services/DeviceTraits.service.ts");
/* harmony import */ var _shared_services_Homes_service__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! ./shared/services/Homes.service */ "./src/app/shared/services/Homes.service.ts");
/* harmony import */ var _shared_services_Hubs_service__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! ./shared/services/Hubs.service */ "./src/app/shared/services/Hubs.service.ts");
/* harmony import */ var _shared_services_Pieces_service__WEBPACK_IMPORTED_MODULE_24__ = __webpack_require__(/*! ./shared/services/Pieces.service */ "./src/app/shared/services/Pieces.service.ts");
/* harmony import */ var _shared_services_Relays_service__WEBPACK_IMPORTED_MODULE_25__ = __webpack_require__(/*! ./shared/services/Relays.service */ "./src/app/shared/services/Relays.service.ts");
/* harmony import */ var _shared_guard_auth_guard__WEBPACK_IMPORTED_MODULE_26__ = __webpack_require__(/*! ./shared/guard/auth.guard */ "./src/app/shared/guard/auth.guard.ts");
/* harmony import */ var _shared_auth_kazo_auth_wrapper__WEBPACK_IMPORTED_MODULE_27__ = __webpack_require__(/*! ./shared/auth/kazo.auth.wrapper */ "./src/app/shared/auth/kazo.auth.wrapper.ts");
/* harmony import */ var _angular_cdk_bidi__WEBPACK_IMPORTED_MODULE_28__ = __webpack_require__(/*! @angular/cdk/bidi */ "./node_modules/@angular/cdk/esm5/bidi.es5.js");
/* harmony import */ var _angular_material_core__WEBPACK_IMPORTED_MODULE_29__ = __webpack_require__(/*! @angular/material/core */ "./node_modules/@angular/material/esm5/core.es5.js");
/* harmony import */ var _angular_material_icon__WEBPACK_IMPORTED_MODULE_30__ = __webpack_require__(/*! @angular/material/icon */ "./node_modules/@angular/material/esm5/icon.es5.js");
/* harmony import */ var _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_31__ = __webpack_require__(/*! ./shared/services/AngularConfig.service */ "./src/app/shared/services/AngularConfig.service.ts");
/* harmony import */ var _app_load_service__WEBPACK_IMPORTED_MODULE_32__ = __webpack_require__(/*! ./app-load.service */ "./src/app/app-load.service.ts");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_33__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _shared_services_services_module__WEBPACK_IMPORTED_MODULE_34__ = __webpack_require__(/*! ./shared/services/services.module */ "./src/app/shared/services/services.module.ts");
/**
 * @fileoverview This file was generated by the Angular template compiler. Do not edit.
 *
 * @suppress {suspiciousCode,uselessCode,missingProperties,missingOverride,checkTypes}
 * tslint:disable
 */ 



































var AppModuleNgFactory = _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵcmf"](_app_module__WEBPACK_IMPORTED_MODULE_1__["AppModule"], [_app_component__WEBPACK_IMPORTED_MODULE_2__["AppComponent"]], function (_l) { return _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmod"]([_angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ComponentFactoryResolver"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵCodegenComponentFactoryResolver"], [[8, [_node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["NgbAlertNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["NgbDatepickerNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["ɵzNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["ɵbaNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["ɵsNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["ɵvNgFactory"], _node_modules_ng_bootstrap_ng_bootstrap_ng_bootstrap_ngfactory__WEBPACK_IMPORTED_MODULE_3__["ɵwNgFactory"], _node_modules_angular_router_router_ngfactory__WEBPACK_IMPORTED_MODULE_4__["ɵEmptyOutletComponentNgFactory"], _app_component_ngfactory__WEBPACK_IMPORTED_MODULE_5__["AppComponentNgFactory"]]], [3, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ComponentFactoryResolver"]], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModuleRef"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["LOCALE_ID"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵangular_packages_core_core_o"], [[3, _angular_core__WEBPACK_IMPORTED_MODULE_0__["LOCALE_ID"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_common__WEBPACK_IMPORTED_MODULE_6__["NgLocalization"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["NgLocaleLocalization"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["LOCALE_ID"], [2, _angular_common__WEBPACK_IMPORTED_MODULE_6__["ɵangular_packages_common_common_a"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["APP_ID"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵangular_packages_core_core_g"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["IterableDiffers"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵangular_packages_core_core_m"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["KeyValueDiffers"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵangular_packages_core_core_n"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["DomSanitizer"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomSanitizerImpl"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](6144, _angular_core__WEBPACK_IMPORTED_MODULE_0__["Sanitizer"], null, [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["DomSanitizer"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["HAMMER_GESTURE_CONFIG"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["HammerGestureConfig"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["EVENT_MANAGER_PLUGINS"], function (p0_0, p0_1, p0_2, p1_0, p2_0, p2_1, p2_2, p2_3) { return [new _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomEventsPlugin"](p0_0, p0_1, p0_2), new _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵKeyEventsPlugin"](p1_0), new _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵHammerGesturesPlugin"](p2_0, p2_1, p2_2, p2_3)]; }, [_angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["PLATFORM_ID"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["HAMMER_GESTURE_CONFIG"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵConsole"], [2, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["HAMMER_LOADER"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["EventManager"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["EventManager"], [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["EVENT_MANAGER_PLUGINS"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](135680, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomSharedStylesHost"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomSharedStylesHost"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomRendererFactory2"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomRendererFactory2"], [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["EventManager"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomSharedStylesHost"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["AnimationDriver"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ɵangular_packages_platform_browser_animations_animations_b"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["ɵAnimationStyleNormalizer"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ɵangular_packages_platform_browser_animations_animations_c"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["ɵAnimationEngine"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ɵangular_packages_platform_browser_animations_animations_a"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"], _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["AnimationDriver"], _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["ɵAnimationStyleNormalizer"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["RendererFactory2"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ɵangular_packages_platform_browser_animations_animations_d"], [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomRendererFactory2"], _angular_animations_browser__WEBPACK_IMPORTED_MODULE_8__["ɵAnimationEngine"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](6144, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵSharedStylesHost"], null, [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵDomSharedStylesHost"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_core__WEBPACK_IMPORTED_MODULE_0__["Testability"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Testability"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_animations__WEBPACK_IMPORTED_MODULE_10__["AnimationBuilder"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ɵBrowserAnimationBuilder"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["RendererFactory2"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["DOCUMENT"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpXsrfTokenExtractor"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_g"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["DOCUMENT"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["PLATFORM_ID"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_e"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_h"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_h"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpXsrfTokenExtractor"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_f"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthResourceServerErrorHandler"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthNoopResourceServerErrorHandler"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HTTP_INTERCEPTORS"], function (p0_0, p1_0, p1_1, p1_2, p2_0) { return [p0_0, new angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["DefaultOAuthInterceptor"](p1_0, p1_1, p1_2), new _shared_Interceptors_jwt_interceptor_service__WEBPACK_IMPORTED_MODULE_13__["JwtInterceptor"](p2_0)]; }, [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_h"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthStorage"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthResourceServerErrorHandler"], [2, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthModuleConfig"]], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ɵangular_packages_forms_forms_j"], _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ɵangular_packages_forms_forms_j"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_forms__WEBPACK_IMPORTED_MODULE_14__["FormBuilder"], _angular_forms__WEBPACK_IMPORTED_MODULE_14__["FormBuilder"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModal"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModal"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ComponentFactoryResolver"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["ɵbb"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModalConfig"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ActivatedRoute"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_g"], [_angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_router__WEBPACK_IMPORTED_MODULE_16__["NoPreloading"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["NoPreloading"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](6144, _angular_router__WEBPACK_IMPORTED_MODULE_16__["PreloadingStrategy"], null, [_angular_router__WEBPACK_IMPORTED_MODULE_16__["NoPreloading"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](135680, _angular_router__WEBPACK_IMPORTED_MODULE_16__["RouterPreloader"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["RouterPreloader"], [_angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModuleFactoryLoader"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Compiler"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["PreloadingStrategy"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _angular_router__WEBPACK_IMPORTED_MODULE_16__["PreloadAllModules"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["PreloadAllModules"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_n"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_c"], [_angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["ViewportScroller"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_CONFIGURATION"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_INITIALIZER"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_j"], [_angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_h"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _angular_core__WEBPACK_IMPORTED_MODULE_0__["APP_BOOTSTRAP_LISTENER"], function (p0_0) { return [p0_0]; }, [_angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_INITIALIZER"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["ɵa"], ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["ɵa"], [ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["CUSTOM_ERROR_MESSAGES"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](5120, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateLoader"], _app_module__WEBPACK_IMPORTED_MODULE_1__["createTranslateLoader"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateCompiler"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateFakeCompiler"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateParser"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateDefaultParser"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["MissingTranslationHandler"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["FakeMissingTranslationHandler"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateStore"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateStore"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateService"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateService"], [_ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateStore"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateLoader"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateCompiler"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateParser"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["MissingTranslationHandler"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["USE_DEFAULT_LANG"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["USE_STORE"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_Devices_service__WEBPACK_IMPORTED_MODULE_19__["DevicesService"], _shared_services_Devices_service__WEBPACK_IMPORTED_MODULE_19__["DevicesService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_DeviceTraits_service__WEBPACK_IMPORTED_MODULE_21__["DeviceTraitsService"], _shared_services_DeviceTraits_service__WEBPACK_IMPORTED_MODULE_21__["DeviceTraitsService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_Homes_service__WEBPACK_IMPORTED_MODULE_22__["HomesService"], _shared_services_Homes_service__WEBPACK_IMPORTED_MODULE_22__["HomesService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_Hubs_service__WEBPACK_IMPORTED_MODULE_23__["HubsService"], _shared_services_Hubs_service__WEBPACK_IMPORTED_MODULE_23__["HubsService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_Pieces_service__WEBPACK_IMPORTED_MODULE_24__["PiecesService"], _shared_services_Pieces_service__WEBPACK_IMPORTED_MODULE_24__["PiecesService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_services_Relays_service__WEBPACK_IMPORTED_MODULE_25__["RelaysService"], _shared_services_Relays_service__WEBPACK_IMPORTED_MODULE_25__["RelaysService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_guard_auth_guard__WEBPACK_IMPORTED_MODULE_26__["AuthGuard"], _shared_guard_auth_guard__WEBPACK_IMPORTED_MODULE_26__["AuthGuard"], [angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](4608, _shared_auth_kazo_auth_wrapper__WEBPACK_IMPORTED_MODULE_27__["KazoAuthWrapper"], _shared_auth_kazo_auth_wrapper__WEBPACK_IMPORTED_MODULE_27__["KazoAuthWrapper"], [angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_cdk_bidi__WEBPACK_IMPORTED_MODULE_28__["BidiModule"], _angular_cdk_bidi__WEBPACK_IMPORTED_MODULE_28__["BidiModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_material_core__WEBPACK_IMPORTED_MODULE_29__["MatCommonModule"], _angular_material_core__WEBPACK_IMPORTED_MODULE_29__["MatCommonModule"], [[2, _angular_material_core__WEBPACK_IMPORTED_MODULE_29__["MATERIAL_SANITY_CHECKS"]], [2, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["HAMMER_LOADER"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_material_icon__WEBPACK_IMPORTED_MODULE_30__["MatIconModule"], _angular_material_icon__WEBPACK_IMPORTED_MODULE_30__["MatIconModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_common__WEBPACK_IMPORTED_MODULE_6__["CommonModule"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["CommonModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ErrorHandler"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵangular_packages_platform_browser_platform_browser_a"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgProbeToken"], function () { return [_angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_b"]()]; }, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_h"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_h"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_d"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_d"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](2048, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["XhrFactory"], null, [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_d"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpXhrBackend"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpXhrBackend"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["XhrFactory"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](2048, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpBackend"], null, [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpXhrBackend"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpHandler"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵHttpInterceptingHandler"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpBackend"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpHandler"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthStorage"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["ɵb"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["ValidationHandler"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["NullValidationHandler"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["AuthConfig"], _app_module__WEBPACK_IMPORTED_MODULE_1__["ɵ0"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["UrlHelperService"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["UrlHelperService"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthLogger"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["ɵa"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"], [2, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthStorage"]], [2, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["ValidationHandler"]], [2, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["AuthConfig"]], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["UrlHelperService"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthLogger"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_31__["AngularService"], _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_31__["AngularService"], [_angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClient"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _app_load_service__WEBPACK_IMPORTED_MODULE_32__["AppLoadService"], _app_load_service__WEBPACK_IMPORTED_MODULE_32__["AppLoadService"], [angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthService"], _shared_services_AngularConfig_service__WEBPACK_IMPORTED_MODULE_31__["AngularService"], _global_service__WEBPACK_IMPORTED_MODULE_20__["GlobalService"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["AuthConfig"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_core__WEBPACK_IMPORTED_MODULE_0__["APP_INITIALIZER"], function (p0_0, p1_0, p2_0) { return [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["ɵangular_packages_platform_browser_platform_browser_j"](p0_0), _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_i"](p1_0), _app_module__WEBPACK_IMPORTED_MODULE_1__["load_settings"](p2_0)]; }, [[2, _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgProbeToken"]], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_h"], _app_load_service__WEBPACK_IMPORTED_MODULE_32__["AppLoadService"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationInitStatus"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationInitStatus"], [[2, _angular_core__WEBPACK_IMPORTED_MODULE_0__["APP_INITIALIZER"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](131584, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationRef"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationRef"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵConsole"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ErrorHandler"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ComponentFactoryResolver"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationInitStatus"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationModule"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationModule"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationRef"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["BrowserModule"], _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["BrowserModule"], [[3, _angular_platform_browser__WEBPACK_IMPORTED_MODULE_7__["BrowserModule"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["BrowserAnimationsModule"], _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["BrowserAnimationsModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientXsrfModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientXsrfModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ɵangular_packages_forms_forms_bc"], _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ɵangular_packages_forms_forms_bc"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_forms__WEBPACK_IMPORTED_MODULE_14__["FormsModule"], _angular_forms__WEBPACK_IMPORTED_MODULE_14__["FormsModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ReactiveFormsModule"], _angular_forms__WEBPACK_IMPORTED_MODULE_14__["ReactiveFormsModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbAccordionModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbAccordionModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbAlertModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbAlertModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbButtonsModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbButtonsModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbCarouselModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbCarouselModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbCollapseModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbCollapseModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbDatepickerModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbDatepickerModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbDropdownModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbDropdownModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModalModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModalModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbPaginationModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbPaginationModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbPopoverModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbPopoverModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbProgressbarModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbProgressbarModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbRatingModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbRatingModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTabsetModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTabsetModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTimepickerModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTimepickerModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTooltipModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTooltipModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTypeaheadModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbTypeaheadModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModule"], _ng_bootstrap_ng_bootstrap__WEBPACK_IMPORTED_MODULE_15__["NgbModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["NgBootstrapFormValidationModule"], ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["NgBootstrapFormValidationModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateModule"], _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["TranslateModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_a"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_e"], [[3, _angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_router__WEBPACK_IMPORTED_MODULE_16__["UrlSerializer"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["DefaultUrlSerializer"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ChildrenOutletContexts"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ChildrenOutletContexts"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_CONFIGURATION"], { useHash: true }, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_common__WEBPACK_IMPORTED_MODULE_6__["LocationStrategy"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_d"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["PlatformLocation"], [2, _angular_common__WEBPACK_IMPORTED_MODULE_6__["APP_BASE_HREF"]], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_CONFIGURATION"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_common__WEBPACK_IMPORTED_MODULE_6__["Location"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["Location"], [_angular_common__WEBPACK_IMPORTED_MODULE_6__["LocationStrategy"]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_core__WEBPACK_IMPORTED_MODULE_0__["Compiler"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Compiler"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](512, _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModuleFactoryLoader"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["SystemJsNgModuleLoader"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["Compiler"], [2, _angular_core__WEBPACK_IMPORTED_MODULE_0__["SystemJsNgModuleLoaderConfig"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTES"], function () { return [[{ path: "", loadChildren: "./layout/layout.module#LayoutModule", canActivate: [_shared_guard_auth_guard__WEBPACK_IMPORTED_MODULE_26__["AuthGuard"]] }, { path: "login", loadChildren: "./login/login.module#LoginModule" }, { path: "signup", loadChildren: "./signup/signup.module#SignupModule" }, { path: "error", loadChildren: "./server-error/server-error.module#ServerErrorModule" }, { path: "access-denied", loadChildren: "./access-denied/access-denied.module#AccessDeniedModule" }, { path: "not-found", loadChildren: "./not-found/not-found.module#NotFoundModule" }, { path: "**", redirectTo: "not-found" }]]; }, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, _angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_f"], [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ApplicationRef"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["UrlSerializer"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ChildrenOutletContexts"], _angular_common__WEBPACK_IMPORTED_MODULE_6__["Location"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Injector"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModuleFactoryLoader"], _angular_core__WEBPACK_IMPORTED_MODULE_0__["Compiler"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTES"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["ROUTER_CONFIGURATION"], [2, _angular_router__WEBPACK_IMPORTED_MODULE_16__["UrlHandlingStrategy"]], [2, _angular_router__WEBPACK_IMPORTED_MODULE_16__["RouteReuseStrategy"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _angular_router__WEBPACK_IMPORTED_MODULE_16__["RouterModule"], _angular_router__WEBPACK_IMPORTED_MODULE_16__["RouterModule"], [[2, _angular_router__WEBPACK_IMPORTED_MODULE_16__["ɵangular_packages_router_router_a"]], [2, _angular_router__WEBPACK_IMPORTED_MODULE_16__["Router"]]]), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _app_routing_module__WEBPACK_IMPORTED_MODULE_33__["AppRoutingModule"], _app_routing_module__WEBPACK_IMPORTED_MODULE_33__["AppRoutingModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthModule"], angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _shared_services_services_module__WEBPACK_IMPORTED_MODULE_34__["ServicesModule"], _shared_services_services_module__WEBPACK_IMPORTED_MODULE_34__["ServicesModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1073742336, _app_module__WEBPACK_IMPORTED_MODULE_1__["AppModule"], _app_module__WEBPACK_IMPORTED_MODULE_1__["AppModule"], []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵAPP_ROOT"], true, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_9__["ANIMATION_MODULE_TYPE"], "BrowserAnimations", []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_e"], "XSRF-TOKEN", []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["ɵangular_packages_common_http_http_f"], "X-XSRF-TOKEN", []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_12__["OAuthModuleConfig"], null, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](1024, ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["CUSTOM_ERROR_MESSAGES"], function () { return [[]]; }, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, ng_bootstrap_form_validation__WEBPACK_IMPORTED_MODULE_17__["BOOTSTRAP_VERSION"], 1, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["USE_STORE"], undefined, []), _angular_core__WEBPACK_IMPORTED_MODULE_0__["ɵmpd"](256, _ngx_translate_core__WEBPACK_IMPORTED_MODULE_18__["USE_DEFAULT_LANG"], undefined, [])]); });



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: createTranslateLoader, load_settings, AppModule, ɵ0 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "createTranslateLoader", function() { return createTranslateLoader; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "load_settings", function() { return load_settings; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ɵ0", function() { return ɵ0; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _ngx_translate_http_loader__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @ngx-translate/http-loader */ "./node_modules/@ngx-translate/http-loader/fesm5/ngx-translate-http-loader.js");
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");
/* harmony import */ var _app_load_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app-load.service */ "./src/app/app-load.service.ts");




// AoT requires an exported function for factories
var createTranslateLoader = function (http) {
    /* for development
    return new TranslateHttpLoader(
        http,
        '/start-angular/SB-Admin-BS4-Angular-6/master/dist/assets/i18n/',
        '.json'
    ); */
    return new _ngx_translate_http_loader__WEBPACK_IMPORTED_MODULE_1__["TranslateHttpLoader"](http, './assets/i18n/', '.json');
};
//This value is only used if we use ng serve. Else we override this when we call the Angular mvc Api 'config/GetAuth'
var authConfig = {
    issuer: "https://dev.kazo.ca/auth",
    clientId: "Jsd8sd7Sd6sdnsdf8sdf6jKJdsf784f45sf7SDf98sdfSdfnsdfjsdf7sdf8s7dfsdf",
    scope: "openid profile GoogleSmartHome",
    redirectUri: window.location.origin + '/index.html',
    oidc: true
};
function load_settings(appLoadService) {
    return function () { return appLoadService.loadSettings(); };
}
var ɵ0 = authConfig;
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    return AppModule;
}());




/***/ }),

/***/ "./src/app/global.service.ts":
/*!***********************************!*\
  !*** ./src/app/global.service.ts ***!
  \***********************************/
/*! exports provided: GlobalService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GlobalService", function() { return GlobalService; });
var GlobalService = /** @class */ (function () {
    function GlobalService() {
    }
    return GlobalService;
}());



/***/ }),

/***/ "./src/app/shared/Interceptors/jwt-interceptor.service.ts":
/*!****************************************************************!*\
  !*** ./src/app/shared/Interceptors/jwt-interceptor.service.ts ***!
  \****************************************************************/
/*! exports provided: JwtInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "JwtInterceptor", function() { return JwtInterceptor; });
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");

//Maybe this is not needed. Maybe the oauth2 allredy do this (It can be configured : https://github.com/manfredsteyer/angular-oauth2-oidc#calling-a-web-api-with-an-access-token)
//Reference doc : http://jasonwatmore.com/post/2018/11/16/angular-7-jwt-authentication-example-tutorial
var JwtInterceptor = /** @class */ (function () {
    function JwtInterceptor(authenticationService) {
        this.authenticationService = authenticationService;
    }
    JwtInterceptor.prototype.intercept = function (request, next) {
        // add authorization header with jwt token if available
        var connected = this.authenticationService.hasValidAccessToken();
        if (connected) {
            request = request.clone({
                setHeaders: {
                    Authorization: "Bearer " + this.authenticationService.getAccessToken()
                }
            });
        }
        return next.handle(request);
    };
    return JwtInterceptor;
}());



/***/ }),

/***/ "./src/app/shared/auth/kazo.auth.wrapper.ts":
/*!**************************************************!*\
  !*** ./src/app/shared/auth/kazo.auth.wrapper.ts ***!
  \**************************************************/
/*! exports provided: KazoAuthWrapper */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "KazoAuthWrapper", function() { return KazoAuthWrapper; });
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");

var KazoAuthWrapper = /** @class */ (function () {
    function KazoAuthWrapper(oauthService) {
        this.oauthService = oauthService;
    }
    KazoAuthWrapper.prototype.loginWithPassword = function (userName, password) {
        return this.oauthService
            .fetchTokenUsingPasswordFlow(userName, password);
    };
    KazoAuthWrapper.prototype.login = function () {
        this.oauthService.initImplicitFlow();
    };
    return KazoAuthWrapper;
}());



/***/ }),

/***/ "./src/app/shared/guard/auth.guard.ts":
/*!********************************************!*\
  !*** ./src/app/shared/guard/auth.guard.ts ***!
  \********************************************/
/*! exports provided: AuthGuard */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthGuard", function() { return AuthGuard; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var angular_oauth2_oidc__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! angular-oauth2-oidc */ "./node_modules/angular-oauth2-oidc/esm5/angular-oauth2-oidc.js");


var AuthGuard = /** @class */ (function () {
    function AuthGuard(oauthService, router) {
        this.oauthService = oauthService;
        this.router = router;
    }
    AuthGuard.prototype.canActivate = function (route, state) {
        if (this.oauthService.hasValidIdToken()) {
            return true;
        }
        this.router.navigate(['/login']);
        return false;
    };
    return AuthGuard;
}());



/***/ }),

/***/ "./src/app/shared/guard/index.ts":
/*!***************************************!*\
  !*** ./src/app/shared/guard/index.ts ***!
  \***************************************/
/*! exports provided: AuthGuard */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _auth_guard__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./auth.guard */ "./src/app/shared/guard/auth.guard.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "AuthGuard", function() { return _auth_guard__WEBPACK_IMPORTED_MODULE_0__["AuthGuard"]; });




/***/ }),

/***/ "./src/app/shared/services/AngularConfig.service.ts":
/*!**********************************************************!*\
  !*** ./src/app/shared/services/AngularConfig.service.ts ***!
  \**********************************************************/
/*! exports provided: AngularService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AngularService", function() { return AngularService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Observable__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Observable */ "./node_modules/rxjs-compat/_esm5/Observable.js");
/* harmony import */ var rxjs_add_operator_do__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/add/operator/do */ "./node_modules/rxjs-compat/_esm5/add/operator/do.js");
/* harmony import */ var rxjs_add_operator_catch__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/add/operator/catch */ "./node_modules/rxjs-compat/_esm5/add/operator/catch.js");
/* harmony import */ var rxjs_add_operator_map__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/add/operator/map */ "./node_modules/rxjs-compat/_esm5/add/operator/map.js");





//LocalCall
var AngularService = /** @class */ (function () {
    function AngularService(_httpClient) {
        this._httpClient = _httpClient;
    }
    // get: config/Angular/GetAuth      
    AngularService.prototype.getAuth = function () {
        var _Url = "/config/Angular/GetAuth";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // Utility
    AngularService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        return rxjs_Observable__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(customError || 'Server error');
    };
    return AngularService;
}());



/***/ }),

/***/ "./src/app/shared/services/DeviceTraits.service.ts":
/*!*********************************************************!*\
  !*** ./src/app/shared/services/DeviceTraits.service.ts ***!
  \*********************************************************/
/*! exports provided: DeviceTraitsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeviceTraitsService", function() { return DeviceTraitsService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var DeviceTraitsService = /** @class */ (function () {
    function DeviceTraitsService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/DeviceTraits      
    DeviceTraitsService.prototype.getDeviceTraits = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/DeviceTraits";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // Utility
    DeviceTraitsService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return DeviceTraitsService;
}());



/***/ }),

/***/ "./src/app/shared/services/DeviceTypes.service.ts":
/*!********************************************************!*\
  !*** ./src/app/shared/services/DeviceTypes.service.ts ***!
  \********************************************************/
/*! exports provided: DeviceTypesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeviceTypesService", function() { return DeviceTypesService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var DeviceTypesService = /** @class */ (function () {
    function DeviceTypesService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/DeviceTypes      
    DeviceTypesService.prototype.getDeviceTypes = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/DeviceTypes";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // Utility
    DeviceTypesService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return DeviceTypesService;
}());



/***/ }),

/***/ "./src/app/shared/services/Devices.service.ts":
/*!****************************************************!*\
  !*** ./src/app/shared/services/Devices.service.ts ***!
  \****************************************************/
/*! exports provided: DevicesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DevicesService", function() { return DevicesService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var DevicesService = /** @class */ (function () {
    function DevicesService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/Devices      
    DevicesService.prototype.getDevices = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Devices";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // get: Manage/Devices/${encodeURIComponent(id)}      
    DevicesService.prototype.getDevice = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Devices/" + encodeURIComponent(id));
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // put: Manage/Devices/${encodeURIComponent(id)}      
    DevicesService.prototype.putDevice = function (id, device) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Devices/" + encodeURIComponent(id));
        return this._httpClient.put(_Url, device)
            .catch(this.handleError);
    };
    // post: Manage/Devices      
    DevicesService.prototype.postDevice = function (device) {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Devices";
        return this._httpClient.post(_Url, device)
            .catch(this.handleError);
    };
    // delete: Manage/Devices/${encodeURIComponent(id)}      
    DevicesService.prototype.deleteDevice = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Devices/" + encodeURIComponent(id));
        return this._httpClient.delete(_Url)
            .catch(this.handleError);
    };
    // Utility
    DevicesService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return DevicesService;
}());



/***/ }),

/***/ "./src/app/shared/services/Homes.service.ts":
/*!**************************************************!*\
  !*** ./src/app/shared/services/Homes.service.ts ***!
  \**************************************************/
/*! exports provided: HomesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomesService", function() { return HomesService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var HomesService = /** @class */ (function () {
    function HomesService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/Homes      
    HomesService.prototype.getHomes = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Homes";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // get: Manage/Homes/${encodeURIComponent(id)}      
    HomesService.prototype.getHome = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Homes/" + encodeURIComponent(id));
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // put: Manage/Homes/${encodeURIComponent(id)}      
    HomesService.prototype.putHome = function (id, home) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Homes/" + encodeURIComponent(id));
        return this._httpClient.put(_Url, home)
            .catch(this.handleError);
    };
    // post: Manage/Homes      
    HomesService.prototype.postHome = function (home) {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Homes";
        return this._httpClient.post(_Url, home)
            .catch(this.handleError);
    };
    // delete: Manage/Homes/${encodeURIComponent(id)}      
    HomesService.prototype.deleteHome = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Homes/" + encodeURIComponent(id));
        return this._httpClient.delete(_Url)
            .catch(this.handleError);
    };
    // Utility
    HomesService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        if (error.status == 404)
            customError = "Not Found";
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return HomesService;
}());



/***/ }),

/***/ "./src/app/shared/services/Hubs.service.ts":
/*!*************************************************!*\
  !*** ./src/app/shared/services/Hubs.service.ts ***!
  \*************************************************/
/*! exports provided: HubsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HubsService", function() { return HubsService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var HubsService = /** @class */ (function () {
    function HubsService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/Hubs      
    HubsService.prototype.getHubs = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Hubs";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // get: Manage/Hubs/${encodeURIComponent(id)}      
    HubsService.prototype.getHub = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Hubs/" + encodeURIComponent(id));
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // put: Manage/Hubs/${encodeURIComponent(id)}      
    HubsService.prototype.putHub = function (id, hub) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Hubs/" + encodeURIComponent(id));
        return this._httpClient.put(_Url, hub)
            .catch(this.handleError);
    };
    // post: Manage/Hubs      
    HubsService.prototype.postHub = function (hub) {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Hubs";
        return this._httpClient.post(_Url, hub)
            .catch(this.handleError);
    };
    // delete: Manage/Hubs/${encodeURIComponent(id)}      
    HubsService.prototype.deleteHub = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Hubs/" + encodeURIComponent(id));
        return this._httpClient.delete(_Url)
            .catch(this.handleError);
    };
    // Utility
    HubsService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return HubsService;
}());



/***/ }),

/***/ "./src/app/shared/services/Pieces.service.ts":
/*!***************************************************!*\
  !*** ./src/app/shared/services/Pieces.service.ts ***!
  \***************************************************/
/*! exports provided: PiecesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PiecesService", function() { return PiecesService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var PiecesService = /** @class */ (function () {
    function PiecesService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/Pieces      
    PiecesService.prototype.getPieces = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Pieces";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // get: Manage/Pieces/${encodeURIComponent(id)}      
    PiecesService.prototype.getPiece = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Pieces/" + encodeURIComponent(id));
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // put: Manage/Pieces/${encodeURIComponent(id)}      
    PiecesService.prototype.putPiece = function (id, piece) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Pieces/" + encodeURIComponent(id));
        return this._httpClient.put(_Url, piece)
            .catch(this.handleError);
    };
    // post: Manage/Pieces      
    PiecesService.prototype.postPiece = function (piece) {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Pieces";
        return this._httpClient.post(_Url, piece)
            .catch(this.handleError);
    };
    // delete: Manage/Pieces/${encodeURIComponent(id)}      
    PiecesService.prototype.deletePiece = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Pieces/" + encodeURIComponent(id));
        return this._httpClient.delete(_Url)
            .catch(this.handleError);
    };
    // Utility
    PiecesService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return PiecesService;
}());



/***/ }),

/***/ "./src/app/shared/services/Relays.service.ts":
/*!***************************************************!*\
  !*** ./src/app/shared/services/Relays.service.ts ***!
  \***************************************************/
/*! exports provided: RelaysService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RelaysService", function() { return RelaysService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/Rx */ "./node_modules/rxjs-compat/_esm5/Rx.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../global.service */ "./src/app/global.service.ts");



//Remote Call
var RelaysService = /** @class */ (function () {
    function RelaysService(_httpClient, global) {
        this._httpClient = _httpClient;
        this.global = global;
    }
    // get: Manage/Relays      
    RelaysService.prototype.getRelays = function () {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Relays";
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // get: Manage/Relays/${encodeURIComponent(id)}      
    RelaysService.prototype.getRelay = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Relays/" + encodeURIComponent(id));
        return this._httpClient.get(_Url)
            .catch(this.handleError);
    };
    // put: Manage/Relays/${encodeURIComponent(id)}      
    RelaysService.prototype.putRelay = function (id, relay) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Relays/" + encodeURIComponent(id));
        return this._httpClient.put(_Url, relay)
            .catch(this.handleError);
    };
    // post: Manage/Relays      
    RelaysService.prototype.postRelay = function (relay) {
        var _Url = this.global.ApiConfig.apiServer + "/Manage/Relays";
        return this._httpClient.post(_Url, relay)
            .catch(this.handleError);
    };
    // delete: Manage/Relays/${encodeURIComponent(id)}      
    RelaysService.prototype.deleteRelay = function (id) {
        var _Url = this.global.ApiConfig.apiServer + ("/Manage/Relays/" + encodeURIComponent(id));
        return this._httpClient.delete(_Url)
            .catch(this.handleError);
    };
    // Utility
    RelaysService.prototype.handleError = function (error) {
        console.error(error);
        var customError = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText;
        }
        var apiError = {
            customText: customError || 'Server error',
            httpError: error
        };
        return rxjs_Rx__WEBPACK_IMPORTED_MODULE_1__["Observable"].throw(apiError);
    };
    return RelaysService;
}());



/***/ }),

/***/ "./src/app/shared/services/index.ts":
/*!******************************************!*\
  !*** ./src/app/shared/services/index.ts ***!
  \******************************************/
/*! exports provided: AngularService, DevicesService, DeviceTraitsService, DeviceTypesService, HomesService, HubsService, PiecesService, RelaysService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _AngularConfig_service__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./AngularConfig.service */ "./src/app/shared/services/AngularConfig.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "AngularService", function() { return _AngularConfig_service__WEBPACK_IMPORTED_MODULE_0__["AngularService"]; });

/* harmony import */ var _Devices_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Devices.service */ "./src/app/shared/services/Devices.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "DevicesService", function() { return _Devices_service__WEBPACK_IMPORTED_MODULE_1__["DevicesService"]; });

/* harmony import */ var _DeviceTraits_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./DeviceTraits.service */ "./src/app/shared/services/DeviceTraits.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "DeviceTraitsService", function() { return _DeviceTraits_service__WEBPACK_IMPORTED_MODULE_2__["DeviceTraitsService"]; });

/* harmony import */ var _DeviceTypes_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./DeviceTypes.service */ "./src/app/shared/services/DeviceTypes.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "DeviceTypesService", function() { return _DeviceTypes_service__WEBPACK_IMPORTED_MODULE_3__["DeviceTypesService"]; });

/* harmony import */ var _Homes_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./Homes.service */ "./src/app/shared/services/Homes.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "HomesService", function() { return _Homes_service__WEBPACK_IMPORTED_MODULE_4__["HomesService"]; });

/* harmony import */ var _Hubs_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./Hubs.service */ "./src/app/shared/services/Hubs.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "HubsService", function() { return _Hubs_service__WEBPACK_IMPORTED_MODULE_5__["HubsService"]; });

/* harmony import */ var _Pieces_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./Pieces.service */ "./src/app/shared/services/Pieces.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "PiecesService", function() { return _Pieces_service__WEBPACK_IMPORTED_MODULE_6__["PiecesService"]; });

/* harmony import */ var _Relays_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./Relays.service */ "./src/app/shared/services/Relays.service.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "RelaysService", function() { return _Relays_service__WEBPACK_IMPORTED_MODULE_7__["RelaysService"]; });











/***/ }),

/***/ "./src/app/shared/services/services.module.ts":
/*!****************************************************!*\
  !*** ./src/app/shared/services/services.module.ts ***!
  \****************************************************/
/*! exports provided: ServicesModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ServicesModule", function() { return ServicesModule; });
/* harmony import */ var ___WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./ */ "./src/app/shared/services/index.ts");

var ServicesModule = /** @class */ (function () {
    function ServicesModule() {
    }
    ServicesModule.forRoot = function () {
        return {
            ngModule: ServicesModule,
            providers: [
                ___WEBPACK_IMPORTED_MODULE_0__["AngularService"],
                ___WEBPACK_IMPORTED_MODULE_0__["DevicesService"],
                ___WEBPACK_IMPORTED_MODULE_0__["DeviceTraitsService"],
                ___WEBPACK_IMPORTED_MODULE_0__["HomesService"],
                ___WEBPACK_IMPORTED_MODULE_0__["HubsService"],
                ___WEBPACK_IMPORTED_MODULE_0__["PiecesService"],
                ___WEBPACK_IMPORTED_MODULE_0__["RelaysService"]
            ]
        };
    };
    return ServicesModule;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
/* harmony import */ var _app_app_module_ngfactory__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module.ngfactory */ "./src/app/app.module.ngfactory.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_1__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
_angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["platformBrowser"]().bootstrapModuleFactory(_app_app_module_ngfactory__WEBPACK_IMPORTED_MODULE_2__["AppModuleNgFactory"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! d:\SmartThermostat\WinIot\ST.WinIot.App\Web\Angular\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map
(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["setup-setup-module"],{

/***/ "./src/app/layout/setup/setup-routing.module.ts":
/*!******************************************************!*\
  !*** ./src/app/layout/setup/setup-routing.module.ts ***!
  \******************************************************/
/*! exports provided: setupRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "setupRoutingModule", function() { return setupRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _setup_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./setup.component */ "./src/app/layout/setup/setup.component.ts");




var routes = [
    {
        path: '',
        component: _setup_component__WEBPACK_IMPORTED_MODULE_3__["setupComponent"],
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'prefix' },
            { path: 'home', loadChildren: './home/home.module#homeModule' },
        ]
    }
];
var setupRoutingModule = /** @class */ (function () {
    function setupRoutingModule() {
    }
    setupRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], setupRoutingModule);
    return setupRoutingModule;
}());



/***/ }),

/***/ "./src/app/layout/setup/setup.component.html":
/*!***************************************************!*\
  !*** ./src/app/layout/setup/setup.component.html ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<app-bread-crumb></app-bread-crumb>\r\n<section class=\"setup-container\">\r\n    <router-outlet></router-outlet>\r\n</section>\r\n"

/***/ }),

/***/ "./src/app/layout/setup/setup.component.less":
/*!***************************************************!*\
  !*** ./src/app/layout/setup/setup.component.less ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2xheW91dC9zZXR1cC9zZXR1cC5jb21wb25lbnQubGVzcyJ9 */"

/***/ }),

/***/ "./src/app/layout/setup/setup.component.ts":
/*!*************************************************!*\
  !*** ./src/app/layout/setup/setup.component.ts ***!
  \*************************************************/
/*! exports provided: setupComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "setupComponent", function() { return setupComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _setup_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./setup.service */ "./src/app/layout/setup/setup.service.ts");



var setupComponent = /** @class */ (function () {
    function setupComponent(setupService) {
        this.setupService = setupService;
    }
    setupComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.setupService.fireBreadCrumbItemChanged.subscribe(function (o) { _this.BreadCrumbs = o; });
        this.setupService.SetBreadCrumb([{
                active: false,
                icon: "fa-cogs",
                name: "Setup",
                route: "/setup"
            }]);
    };
    setupComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-setup',
            template: __webpack_require__(/*! ./setup.component.html */ "./src/app/layout/setup/setup.component.html"),
            styles: [__webpack_require__(/*! ./setup.component.less */ "./src/app/layout/setup/setup.component.less")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_setup_service__WEBPACK_IMPORTED_MODULE_2__["SetupService"]])
    ], setupComponent);
    return setupComponent;
}());



/***/ }),

/***/ "./src/app/layout/setup/setup.module.ts":
/*!**********************************************!*\
  !*** ./src/app/layout/setup/setup.module.ts ***!
  \**********************************************/
/*! exports provided: setupModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "setupModule", function() { return setupModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _setup_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./setup-routing.module */ "./src/app/layout/setup/setup-routing.module.ts");
/* harmony import */ var _setup_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./setup.component */ "./src/app/layout/setup/setup.component.ts");
/* harmony import */ var _setup_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./setup.service */ "./src/app/layout/setup/setup.service.ts");
/* harmony import */ var _shared__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../shared */ "./src/app/shared/index.ts");







var setupModule = /** @class */ (function () {
    function setupModule() {
    }
    setupModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"], _setup_routing_module__WEBPACK_IMPORTED_MODULE_3__["setupRoutingModule"], _shared__WEBPACK_IMPORTED_MODULE_6__["BreadCrumbModule"]],
            declarations: [_setup_component__WEBPACK_IMPORTED_MODULE_4__["setupComponent"]],
            providers: [_setup_service__WEBPACK_IMPORTED_MODULE_5__["SetupService"]]
        })
    ], setupModule);
    return setupModule;
}());



/***/ })

}]);
//# sourceMappingURL=setup-setup-module.js.map
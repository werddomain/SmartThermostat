(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["homepage-homepage-module"],{

/***/ "./src/app/layout/homepage/homepage-routing.module.ts":
/*!************************************************************!*\
  !*** ./src/app/layout/homepage/homepage-routing.module.ts ***!
  \************************************************************/
/*! exports provided: homepageRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homepageRoutingModule", function() { return homepageRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _homepage_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./homepage.component */ "./src/app/layout/homepage/homepage.component.ts");




var routes = [
    {
        path: '',
        component: _homepage_component__WEBPACK_IMPORTED_MODULE_3__["homepageComponent"]
    }
];
var homepageRoutingModule = /** @class */ (function () {
    function homepageRoutingModule() {
    }
    homepageRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], homepageRoutingModule);
    return homepageRoutingModule;
}());



/***/ }),

/***/ "./src/app/layout/homepage/homepage.component.html":
/*!*********************************************************!*\
  !*** ./src/app/layout/homepage/homepage.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Test </h1>\r\n<i class=\"fab fa-acquisitions-incorporated\"></i>\r\n"

/***/ }),

/***/ "./src/app/layout/homepage/homepage.component.less":
/*!*********************************************************!*\
  !*** ./src/app/layout/homepage/homepage.component.less ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2xheW91dC9ob21lcGFnZS9ob21lcGFnZS5jb21wb25lbnQubGVzcyJ9 */"

/***/ }),

/***/ "./src/app/layout/homepage/homepage.component.ts":
/*!*******************************************************!*\
  !*** ./src/app/layout/homepage/homepage.component.ts ***!
  \*******************************************************/
/*! exports provided: homepageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homepageComponent", function() { return homepageComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var homepageComponent = /** @class */ (function () {
    function homepageComponent() {
    }
    homepageComponent.prototype.ngOnInit = function () { };
    homepageComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-homepage',
            template: __webpack_require__(/*! ./homepage.component.html */ "./src/app/layout/homepage/homepage.component.html"),
            styles: [__webpack_require__(/*! ./homepage.component.less */ "./src/app/layout/homepage/homepage.component.less")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], homepageComponent);
    return homepageComponent;
}());



/***/ }),

/***/ "./src/app/layout/homepage/homepage.module.ts":
/*!****************************************************!*\
  !*** ./src/app/layout/homepage/homepage.module.ts ***!
  \****************************************************/
/*! exports provided: homepageModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homepageModule", function() { return homepageModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _homepage_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./homepage-routing.module */ "./src/app/layout/homepage/homepage-routing.module.ts");
/* harmony import */ var _homepage_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./homepage.component */ "./src/app/layout/homepage/homepage.component.ts");
/* harmony import */ var _shared__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./../../shared */ "./src/app/shared/index.ts");






var homepageModule = /** @class */ (function () {
    function homepageModule() {
    }
    homepageModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"], _homepage_routing_module__WEBPACK_IMPORTED_MODULE_3__["homepageRoutingModule"], _shared__WEBPACK_IMPORTED_MODULE_5__["PageHeaderModule"], _shared__WEBPACK_IMPORTED_MODULE_5__["BreadCrumbModule"]],
            declarations: [_homepage_component__WEBPACK_IMPORTED_MODULE_4__["homepageComponent"]]
        })
    ], homepageModule);
    return homepageModule;
}());



/***/ })

}]);
//# sourceMappingURL=homepage-homepage-module.js.map
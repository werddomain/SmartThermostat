(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["blank-page-blank-page-module"],{

/***/ "./src/app/layout/blank-page/blank-page-routing.module.ts":
/*!****************************************************************!*\
  !*** ./src/app/layout/blank-page/blank-page-routing.module.ts ***!
  \****************************************************************/
/*! exports provided: BlankPageRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BlankPageRoutingModule", function() { return BlankPageRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _blank_page_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./blank-page.component */ "./src/app/layout/blank-page/blank-page.component.ts");




var routes = [
    {
        path: '',
        component: _blank_page_component__WEBPACK_IMPORTED_MODULE_3__["BlankPageComponent"]
    }
];
var BlankPageRoutingModule = /** @class */ (function () {
    function BlankPageRoutingModule() {
    }
    BlankPageRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], BlankPageRoutingModule);
    return BlankPageRoutingModule;
}());



/***/ }),

/***/ "./src/app/layout/blank-page/blank-page.component.html":
/*!*************************************************************!*\
  !*** ./src/app/layout/blank-page/blank-page.component.html ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/layout/blank-page/blank-page.component.less":
/*!*************************************************************!*\
  !*** ./src/app/layout/blank-page/blank-page.component.less ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2xheW91dC9ibGFuay1wYWdlL2JsYW5rLXBhZ2UuY29tcG9uZW50Lmxlc3MifQ== */"

/***/ }),

/***/ "./src/app/layout/blank-page/blank-page.component.ts":
/*!***********************************************************!*\
  !*** ./src/app/layout/blank-page/blank-page.component.ts ***!
  \***********************************************************/
/*! exports provided: BlankPageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BlankPageComponent", function() { return BlankPageComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var BlankPageComponent = /** @class */ (function () {
    function BlankPageComponent() {
    }
    BlankPageComponent.prototype.ngOnInit = function () { };
    BlankPageComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-blank-page',
            template: __webpack_require__(/*! ./blank-page.component.html */ "./src/app/layout/blank-page/blank-page.component.html"),
            styles: [__webpack_require__(/*! ./blank-page.component.less */ "./src/app/layout/blank-page/blank-page.component.less")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], BlankPageComponent);
    return BlankPageComponent;
}());



/***/ }),

/***/ "./src/app/layout/blank-page/blank-page.module.ts":
/*!********************************************************!*\
  !*** ./src/app/layout/blank-page/blank-page.module.ts ***!
  \********************************************************/
/*! exports provided: BlankPageModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BlankPageModule", function() { return BlankPageModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _blank_page_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./blank-page-routing.module */ "./src/app/layout/blank-page/blank-page-routing.module.ts");
/* harmony import */ var _blank_page_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./blank-page.component */ "./src/app/layout/blank-page/blank-page.component.ts");





var BlankPageModule = /** @class */ (function () {
    function BlankPageModule() {
    }
    BlankPageModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"], _blank_page_routing_module__WEBPACK_IMPORTED_MODULE_3__["BlankPageRoutingModule"]],
            declarations: [_blank_page_component__WEBPACK_IMPORTED_MODULE_4__["BlankPageComponent"]]
        })
    ], BlankPageModule);
    return BlankPageModule;
}());



/***/ })

}]);
//# sourceMappingURL=blank-page-blank-page-module.js.map
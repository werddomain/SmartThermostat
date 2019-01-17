(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["home-home-module"],{

/***/ "./src/app/layout/setup/home/home-routing.module.ts":
/*!**********************************************************!*\
  !*** ./src/app/layout/setup/home/home-routing.module.ts ***!
  \**********************************************************/
/*! exports provided: homeRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homeRoutingModule", function() { return homeRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _home_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./home.component */ "./src/app/layout/setup/home/home.component.ts");




var routes = [
    {
        path: '',
        component: _home_component__WEBPACK_IMPORTED_MODULE_3__["homeComponent"]
    }
];
var homeRoutingModule = /** @class */ (function () {
    function homeRoutingModule() {
    }
    homeRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], homeRoutingModule);
    return homeRoutingModule;
}());



/***/ }),

/***/ "./src/app/layout/setup/home/home.component.html":
/*!*******************************************************!*\
  !*** ./src/app/layout/setup/home/home.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "//Form doc: https://phpenthusiast.com/blog/angular-form-ngform-and-two-ways-data-binding\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <!-- ######## Home Card #########-->\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                Home\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <form class=\"form-horizontal\">\r\n                    <div class=\"form-group\">\r\n                        <label for=\"home\" class=\"control-label col-xs-4\">Home Name</label>\r\n                        <div class=\"col-xs-8\">\r\n                            <div class=\"input-group\">\r\n                                <div class=\"input-group-addon\">\r\n                                    <i class=\"fa fa-building-o\"></i>\r\n                                </div>\r\n                                <input [(ngModel)]=\"home.name\" id=\"home\" name=\"home\" placeholder=\"My Home\" type=\"text\" required=\"required\" class=\"form-control\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"fullAddress\" class=\"control-label col-xs-4\">Address</label>\r\n                        <div class=\"col-xs-8\">\r\n                            <div class=\"input-group\">\r\n                                <div class=\"input-group-addon\">\r\n                                    <i class=\"fa fa-address-card-o\"></i>\r\n                                </div>\r\n                                <input [(ngModel)]=\"home.fullAddress\" id=\"fullAddress\" name=\"fullAddress\" placeholder=\"123 MyStreat, city, state country \" required=\"required\" type=\"text\" class=\"form-control\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"city\" class=\"control-label col-xs-4\">city</label>\r\n                        <div class=\"col-xs-8\">\r\n                            <input [(ngModel)]=\"home.city\" id=\"city\" name=\"city\" type=\"text\" class=\"form-control\" required=\"required\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"state\" class=\"control-label col-xs-4\">state</label>\r\n                        <div class=\"col-xs-8\">\r\n                            <input [(ngModel)]=\"home.state\" id=\"state\" name=\"state\" type=\"text\" class=\"form-control\" required=\"required\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"country\" class=\"control-label col-xs-4\">country</label>\r\n                        <div class=\"col-xs-8\">\r\n                            <input [(ngModel)]=\"home.country\" id=\"country\" name=\"country\" type=\"text\" class=\"form-control\" required=\"required\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        <div class=\"col-xs-offset-4 col-xs-8\">\r\n                            <button name=\"submit\" type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n                        </div>\r\n                    </div>\r\n                </form>\r\n            </div>\r\n\r\n        </div>\r\n        <!-- ######## /Home Card #########-->\r\n        <!-- ######## Peices Card #########-->\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                Peices\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <form>\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"peiceName\" class=\"col-4 col-form-label\">Name</label>\r\n                        <div class=\"col-8\">\r\n                            <div class=\"input-group\">\r\n                                <div class=\"input-group-addon\">\r\n                                    <i class=\"fa fa-codepen\"></i>\r\n                                </div>\r\n                                <input id=\"peiceName\" name=\"peiceName\" [(ngModel)]=\"currentPiece.name\" placeholder=\"Living Room\" type=\"text\" class=\"form-control here\" required=\"required\" maxlength=\"30\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"pieceFloor\" class=\"col-4 col-form-label\">Floor</label>\r\n                        <div class=\"col-8\">\r\n                            <input id=\"pieceFloor\" [(ngModel)]=\"currentPiece.floor\" name=\"pieceFloor\" placeholder=\"1\" type=\"number\" class=\"form-control here\" aria-describedby=\"pieceFloorHelpBlock\" required=\"required\">\r\n                            <span id=\"pieceFloorHelpBlock\" class=\"form-text text-muted\">0 = basement, 1 = 1st floor</span>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        <label for=\"peiceType\" class=\"col-4 col-form-label\">Piece Type</label>\r\n                        <div class=\"col-8\">\r\n                            <select [(ngModel)]=\"currentPiece.type\" name=\"peiceType\" id=\"peiceType\" class=\"form-control\" required>\r\n                                <option *ngFor=\"let item of piecesTypes\" value=\"{{item.value}}\">{{item.text}}</option>\r\n                            </select>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        <div class=\"offset-4 col-8\">\r\n                            <button class=\"btn btn-success\" type=\"button\" ng-show=\"!isInEdit\" (click)=\"addPeice()\"><i class=\"fa fa-plus\"></i> Add</button>\r\n                            <button class=\"btn btn-primary\" type=\"button\" ng-show=\"isInEdit\" (click)=\"savePeice()\"><i class=\"fa fa-save\"></i> Save</button>\r\n                        </div>\r\n                    </div>\r\n                </form>\r\n\r\n\r\n                <div class=\"form-group\">\r\n                    <label for=\"peiceType\" class=\"control-label col-xs-4\">Type</label>\r\n                    <div class=\"col-xs-8\">\r\n                        <select [(ngModel)]=\"currentPiece.type\" name=\"peiceType\" id=\"peiceType\" class=\"form-control\" required>\r\n                            <option *ngFor=\"let item of piecesTypes\" value=\"{{item.value}}\">{{item.text}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                \r\n            </div>\r\n            <div class=\"card-body\">\r\n                <div class=\"list-group list-group-flush\">\r\n\r\n                    <div *ngFor=\"let item of pieces; let i = index\" class=\"list-group-item list-group-item-action\">\r\n                        <div class=\"d-flex w-100 justify-content-between\">\r\n                            <h5 class=\"mb-1\">{{item.name}}</h5>\r\n                            <small class=\"text-muted\">{{getPieceTypeName(item.type)}}</small>\r\n                        </div>\r\n                        <p class=\"mb-1\">\r\n                            <button type=\"button\" (click)=\"editPeice(i)\" class=\"btn btn-primary\"><i class=\" fa fa-pencil\"></i> Edit</button>\r\n                            <button type=\"button\" (click)=\"removePeice(i)\" class=\"btn btn-danger\"><i class=\"fa fa-trash\"></i> Remove</button>\r\n                        </p>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- ######## /Peices Card #########-->\r\n    </div>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./src/app/layout/setup/home/home.component.less":
/*!*******************************************************!*\
  !*** ./src/app/layout/setup/home/home.component.less ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2xheW91dC9zZXR1cC9ob21lL2hvbWUuY29tcG9uZW50Lmxlc3MifQ== */"

/***/ }),

/***/ "./src/app/layout/setup/home/home.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/layout/setup/home/home.component.ts ***!
  \*****************************************************/
/*! exports provided: homeComponent, EnumToArrayPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homeComponent", function() { return homeComponent; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EnumToArrayPipe", function() { return EnumToArrayPipe; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _setup_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../setup.service */ "./src/app/layout/setup/setup.service.ts");
/* harmony import */ var _app_shared_classes__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @app/shared/classes */ "./src/app/shared/classes/index.ts");




var homeComponent = /** @class */ (function () {
    function homeComponent(setupService) {
        this.setupService = setupService;
        this.isInEdit = false;
    }
    homeComponent.prototype.getPieceTypeName = function (type) {
        return _app_shared_classes__WEBPACK_IMPORTED_MODULE_3__["PieceTypeEnum"][type].replace("_", " ");
    };
    homeComponent.prototype.ngOnInit = function () {
        this.setupService.ActivateBreadCrumb({
            active: true,
            icon: "fa-home",
            name: "Home",
            route: "/setup/home"
        });
        if (this.setupService.CurrentHome != null)
            this.home = this.setupService.CurrentHome;
        if (this.setupService.Pieces != null && this.pieces.length > 0)
            this.pieces = this.setupService.Pieces;
        this.piecesTypes = this.getEnumValues();
    };
    homeComponent.prototype.cleanCurrentPeice = function () {
        this.currentPiece = this.clonePiece(this.currentPiece);
        this.currentPiece.name = "";
        this.currentPiece.pieceId = "";
    };
    homeComponent.prototype.addPeice = function () {
        this.pieces.push(this.currentPiece);
        this.cleanCurrentPeice();
    };
    homeComponent.prototype.savePeice = function () {
        this.isInEdit = false;
        this.cleanCurrentPeice();
    };
    homeComponent.prototype.editPeice = function (index) {
        this.isInEdit = true;
        this.currentPiece = this.pieces[index];
    };
    homeComponent.prototype.removePeice = function (index) {
        this.pieces.splice(index);
    };
    homeComponent.prototype.clonePiece = function (item) {
        return {
            floor: item.floor,
            name: item.name,
            type: item.type,
            homeId: item.homeId
        };
    };
    homeComponent.prototype.getEnumValues = function () {
        /* Enums are listed like this in the object:
         * 0: "EnumName0"
         * 1: "EnumName1"
         * "EnumName0": 0
         * "EnumName1": 1
         * */
        var keys = new Array();
        for (var enumMember in _app_shared_classes__WEBPACK_IMPORTED_MODULE_3__["PieceTypeEnum"]) {
            //So we get only the integer one
            var isValueProperty = parseInt(enumMember, 10) >= 0;
            if (isValueProperty) {
                //Then we get the corresponding name by PieceTypeEnum[enumMember]
                keys.push({ value: parseInt(enumMember), name: _app_shared_classes__WEBPACK_IMPORTED_MODULE_3__["PieceTypeEnum"][enumMember].replace("_", " ") });
            }
        }
        return keys;
    };
    homeComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-home',
            template: __webpack_require__(/*! ./home.component.html */ "./src/app/layout/setup/home/home.component.html"),
            styles: [__webpack_require__(/*! ./home.component.less */ "./src/app/layout/setup/home/home.component.less")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_setup_service__WEBPACK_IMPORTED_MODULE_2__["SetupService"]])
    ], homeComponent);
    return homeComponent;
}());

var EnumToArrayPipe = /** @class */ (function () {
    function EnumToArrayPipe() {
    }
    EnumToArrayPipe.prototype.transform = function (value, args) {
        var keys = [];
        for (var enumMember in value) {
            var isValueProperty = parseInt(enumMember, 10) >= 0;
            if (isValueProperty) {
                keys.push({ value: parseInt(enumMember), name: value[enumMember].replace("_", " ") });
                // Uncomment if you want log
                // console.log("enum member: ", value[enumMember]);
            }
        }
        return keys;
    };
    EnumToArrayPipe = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Pipe"])({
            name: 'enumToArray'
        })
    ], EnumToArrayPipe);
    return EnumToArrayPipe;
}());



/***/ }),

/***/ "./src/app/layout/setup/home/home.module.ts":
/*!**************************************************!*\
  !*** ./src/app/layout/setup/home/home.module.ts ***!
  \**************************************************/
/*! exports provided: homeModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "homeModule", function() { return homeModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _home_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./home-routing.module */ "./src/app/layout/setup/home/home-routing.module.ts");
/* harmony import */ var _home_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./home.component */ "./src/app/layout/setup/home/home.component.ts");





var homeModule = /** @class */ (function () {
    function homeModule() {
    }
    homeModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_common__WEBPACK_IMPORTED_MODULE_2__["CommonModule"], _home_routing_module__WEBPACK_IMPORTED_MODULE_3__["homeRoutingModule"]],
            declarations: [_home_component__WEBPACK_IMPORTED_MODULE_4__["homeComponent"]]
        })
    ], homeModule);
    return homeModule;
}());



/***/ }),

/***/ "./src/app/shared/classes/ConnectionTypeEnum.ts":
/*!******************************************************!*\
  !*** ./src/app/shared/classes/ConnectionTypeEnum.ts ***!
  \******************************************************/
/*! exports provided: ConnectionTypeEnum */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ConnectionTypeEnum", function() { return ConnectionTypeEnum; });
// This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
// To modify this class, edit "1_ApiModels"
// More info: http://frhagn.github.io/Typewriter/
// AutoGenerated File
var ConnectionTypeEnum;
(function (ConnectionTypeEnum) {
    ConnectionTypeEnum[ConnectionTypeEnum["Wifi"] = 1] = "Wifi";
    ConnectionTypeEnum[ConnectionTypeEnum["NRF24L01"] = 2] = "NRF24L01";
    ConnectionTypeEnum[ConnectionTypeEnum["I2C"] = 3] = "I2C";
})(ConnectionTypeEnum || (ConnectionTypeEnum = {}));


/***/ }),

/***/ "./src/app/shared/classes/PieceTypeEnum.ts":
/*!*************************************************!*\
  !*** ./src/app/shared/classes/PieceTypeEnum.ts ***!
  \*************************************************/
/*! exports provided: PieceTypeEnum */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PieceTypeEnum", function() { return PieceTypeEnum; });
// This File was auto-generated by TypeWriter. Any changes can be overriten if regenerated.
// To modify this class, edit "1_ApiModels"
// More info: http://frhagn.github.io/Typewriter/
// AutoGenerated File
var PieceTypeEnum;
(function (PieceTypeEnum) {
    PieceTypeEnum[PieceTypeEnum["Kitchen"] = 1] = "Kitchen";
    PieceTypeEnum[PieceTypeEnum["Master_Bedroom"] = 2] = "Master_Bedroom";
    PieceTypeEnum[PieceTypeEnum["Bedroom"] = 3] = "Bedroom";
    PieceTypeEnum[PieceTypeEnum["Living_Room"] = 4] = "Living_Room";
    PieceTypeEnum[PieceTypeEnum["BathRoom"] = 5] = "BathRoom";
})(PieceTypeEnum || (PieceTypeEnum = {}));


/***/ }),

/***/ "./src/app/shared/classes/index.ts":
/*!*****************************************!*\
  !*** ./src/app/shared/classes/index.ts ***!
  \*****************************************/
/*! exports provided: ConnectionTypeEnum, PieceTypeEnum */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _ConnectionTypeEnum__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./ConnectionTypeEnum */ "./src/app/shared/classes/ConnectionTypeEnum.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "ConnectionTypeEnum", function() { return _ConnectionTypeEnum__WEBPACK_IMPORTED_MODULE_0__["ConnectionTypeEnum"]; });

/* harmony import */ var _PieceTypeEnum__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./PieceTypeEnum */ "./src/app/shared/classes/PieceTypeEnum.ts");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "PieceTypeEnum", function() { return _PieceTypeEnum__WEBPACK_IMPORTED_MODULE_1__["PieceTypeEnum"]; });





/***/ })

}]);
//# sourceMappingURL=home-home-module.js.map
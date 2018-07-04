(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error('Cannot find module "' + req + '".');
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/layout.root.cpn */ "./src/app/components/layout.root.cpn.ts");
/* harmony import */ var _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/pages.login.cpn */ "./src/app/components/pages.login.cpn.ts");
/* harmony import */ var _internals_token_interceptor__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./internals/token.interceptor */ "./src/app/internals/token.interceptor.ts");
/* harmony import */ var _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/pages.home.cpn */ "./src/app/components/pages.home.cpn.ts");
/* harmony import */ var _internals_root_interceptor__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./internals/root.interceptor */ "./src/app/internals/root.interceptor.ts");
/* harmony import */ var _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./internals/loader.interceptor */ "./src/app/internals/loader.interceptor.ts");
/* harmony import */ var _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./components/pages.view.cpn */ "./src/app/components/pages.view.cpn.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_3__["NgModule"])({
            declarations: [
                _components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_5__["LayoutRootComponent"],
                _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_8__["PageHomeComponent"],
                _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_6__["PageLoginComponent"],
                _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_11__["PageViewComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"].forRoot([
                    { path: 'home', component: _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_8__["PageHomeComponent"] },
                    { path: 'login', component: _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_6__["PageLoginComponent"] },
                    { path: 'view/:id', component: _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_11__["PageViewComponent"] },
                    { path: '', redirectTo: '/home', pathMatch: 'full' }
                ])
            ],
            providers: [{
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useExisting: _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_10__["LoaderInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useClass: _internals_root_interceptor__WEBPACK_IMPORTED_MODULE_9__["RootInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useClass: _internals_token_interceptor__WEBPACK_IMPORTED_MODULE_7__["TokenInterceptor"],
                    multi: true
                }],
            bootstrap: [_components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_5__["LayoutRootComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/components/layout.root.cpn.html":
/*!*************************************************!*\
  !*** ./src/app/components/layout.root.cpn.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h1>\r\n    <span>yo {{ credentials.user.login }}</span>\r\n  </h1>\r\n  <router-outlet></router-outlet>\r\n  <div id=\"loader\" *ngIf=\"loading\">Chargement</div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/layout.root.cpn.less":
/*!*************************************************!*\
  !*** ./src/app/components/layout.root.cpn.less ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div#loader {\n  background: #444;\n  bottom: 0;\n  color: white;\n  font-weight: bold;\n  position: fixed;\n  right: 0;\n}\n"

/***/ }),

/***/ "./src/app/components/layout.root.cpn.ts":
/*!***********************************************!*\
  !*** ./src/app/components/layout.root.cpn.ts ***!
  \***********************************************/
/*! exports provided: LayoutRootComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LayoutRootComponent", function() { return LayoutRootComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../internals/loader.interceptor */ "./src/app/internals/loader.interceptor.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/** Racine de l'application */
var LayoutRootComponent = /** @class */ (function () {
    function LayoutRootComponent(http, router, loader, authentication) {
        this.http = http;
        this.router = router;
        this.loader = loader;
        this.authentication = authentication;
    }
    LayoutRootComponent.prototype.ngOnInit = function () {
        var _this = this;
        // Démo
        this.http.get("demo").subscribe();
        // Suivi des autorisations
        this.authentication
            .getCredentials()
            .subscribe(function (data) {
            _this.credentials = data;
            _this.checkCredentials(_this.router.url);
        });
        this.router
            .events
            .subscribe(function (data) {
            if (data instanceof _angular_router__WEBPACK_IMPORTED_MODULE_2__["NavigationStart"]) {
                _this.checkCredentials(data.url);
            }
        });
        // Suivi du chargement
        this.loader
            .getLoader()
            .subscribe(function (data) {
            _this.loading = data;
        });
    };
    /**
     * Vérifie les droits d'accès et redirige vers la page de login.
     * @param url URL courante.
     */
    LayoutRootComponent.prototype.checkCredentials = function (url) {
        if (url != "/login" && !this.credentials.connected) {
            this.router.navigate(["login"]);
        }
    };
    LayoutRootComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'layout-root',
            template: __webpack_require__(/*! ./layout.root.cpn.html */ "./src/app/components/layout.root.cpn.html"),
            styles: [__webpack_require__(/*! ./layout.root.cpn.less */ "./src/app/components/layout.root.cpn.less")]
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_4__["LoaderInterceptor"],
            _services_authentication_service__WEBPACK_IMPORTED_MODULE_3__["AuthenticationService"]])
    ], LayoutRootComponent);
    return LayoutRootComponent;
}());



/***/ }),

/***/ "./src/app/components/pages.home.cpn.html":
/*!************************************************!*\
  !*** ./src/app/components/pages.home.cpn.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Salut mec</h2>\r\n  <p>Choisis une vue.</p>\r\n  <ul>\r\n    <li *ngFor=\"let view of views\"\r\n        [routerLink]=\"['/view', view.id]\">{{ view.id }} : {{ translator.tr(view.label) }}</li>\r\n  </ul>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages.home.cpn.less":
/*!************************************************!*\
  !*** ./src/app/components/pages.home.cpn.less ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/pages.home.cpn.ts":
/*!**********************************************!*\
  !*** ./src/app/components/pages.home.cpn.ts ***!
  \**********************************************/
/*! exports provided: PageHomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageHomeComponent", function() { return PageHomeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../services/translator.service */ "./src/app/services/translator.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/** Page d'accueil */
var PageHomeComponent = /** @class */ (function () {
    function PageHomeComponent(state, router, authentication, translator, ar) {
        var _this = this;
        this.state = state;
        this.router = router;
        this.authentication = authentication;
        this.translator = translator;
        this.ar = ar;
        this.views = [];
        ar.params.subscribe(function (params) {
            // onInit broken
            _this.state
                .getViews()
                .subscribe(function (views) {
                _this.views = views;
            });
        });
    }
    PageHomeComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-home',
            template: __webpack_require__(/*! ./pages.home.cpn.html */ "./src/app/components/pages.home.cpn.html"),
            styles: [__webpack_require__(/*! ./pages.home.cpn.less */ "./src/app/components/pages.home.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_state_service__WEBPACK_IMPORTED_MODULE_3__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _services_authentication_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationService"],
            _services_translator_service__WEBPACK_IMPORTED_MODULE_4__["TranslatorService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PageHomeComponent);
    return PageHomeComponent;
}());



/***/ }),

/***/ "./src/app/components/pages.login.cpn.html":
/*!*************************************************!*\
  !*** ./src/app/components/pages.login.cpn.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Connexion</h2>\r\n  <form>\r\n    <div>\r\n      <label>Login</label>\r\n      <input type=\"text\"\r\n             name=\"name\"\r\n             [(ngModel)]=\"name\" />\r\n    </div>\r\n    <div>\r\n      <label>Mot de passe</label>\r\n      <input type=\"password\"\r\n             name=\"password\"\r\n             [(ngModel)]=\"password\" />\r\n    </div>\r\n    <input type=\"button\"\r\n           name=\"submit\"\r\n           value=\"Connexion\"\r\n           (click)=\"authentication.connect(name, password)\" />\r\n  </form>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages.login.cpn.less":
/*!*************************************************!*\
  !*** ./src/app/components/pages.login.cpn.less ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div {\n  background: pink;\n}\ndiv > h2 {\n  color: red;\n}\n"

/***/ }),

/***/ "./src/app/components/pages.login.cpn.ts":
/*!***********************************************!*\
  !*** ./src/app/components/pages.login.cpn.ts ***!
  \***********************************************/
/*! exports provided: PageLoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageLoginComponent", function() { return PageLoginComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../services/state.service */ "./src/app/services/state.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




/** Mire de connexion */
var PageLoginComponent = /** @class */ (function () {
    function PageLoginComponent(authentication, state, router, ar) {
        var _this = this;
        this.authentication = authentication;
        this.state = state;
        this.router = router;
        this.ar = ar;
        ar.params.subscribe(function (params) {
            // onInit broken
            _this.authentication
                .getCredentials()
                .subscribe(function (data) {
                if (data.connected) {
                    _this.state
                        .loadState()
                        .subscribe(function (data) {
                        _this.router.navigate(["home"]);
                    });
                }
            });
        });
    }
    PageLoginComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-login',
            template: __webpack_require__(/*! ./pages.login.cpn.html */ "./src/app/components/pages.login.cpn.html"),
            styles: [__webpack_require__(/*! ./pages.login.cpn.less */ "./src/app/components/pages.login.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_authentication_service__WEBPACK_IMPORTED_MODULE_1__["AuthenticationService"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_3__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"]])
    ], PageLoginComponent);
    return PageLoginComponent;
}());



/***/ }),

/***/ "./src/app/components/pages.view.cpn.html":
/*!************************************************!*\
  !*** ./src/app/components/pages.view.cpn.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Vue {{ view.id }}</h2>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages.view.cpn.less":
/*!************************************************!*\
  !*** ./src/app/components/pages.view.cpn.less ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div {\n  background: pink;\n}\ndiv > h2 {\n  color: red;\n}\n"

/***/ }),

/***/ "./src/app/components/pages.view.cpn.ts":
/*!**********************************************!*\
  !*** ./src/app/components/pages.view.cpn.ts ***!
  \**********************************************/
/*! exports provided: PageViewComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageViewComponent", function() { return PageViewComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../services/state.service */ "./src/app/services/state.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



/** Affichage d'une vue */
var PageViewComponent = /** @class */ (function () {
    function PageViewComponent(state, ar) {
        var _this = this;
        this.state = state;
        this.ar = ar;
        ar.params.subscribe(function (params) {
            // onInit broken
            _this.state
                .getViews()
                .subscribe(function (views) {
                for (var i = 0; i < views.length; i++) {
                    if (views[i].id == params["id"]) {
                        _this.view = views[i];
                    }
                }
            });
        });
    }
    PageViewComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-view',
            template: __webpack_require__(/*! ./pages.view.cpn.html */ "./src/app/components/pages.view.cpn.html"),
            styles: [__webpack_require__(/*! ./pages.view.cpn.less */ "./src/app/components/pages.view.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_state_service__WEBPACK_IMPORTED_MODULE_2__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PageViewComponent);
    return PageViewComponent;
}());



/***/ }),

/***/ "./src/app/dto/authentication.session.dto.ts":
/*!***************************************************!*\
  !*** ./src/app/dto/authentication.session.dto.ts ***!
  \***************************************************/
/*! exports provided: AuthenticationSessionDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthenticationSessionDTO", function() { return AuthenticationSessionDTO; });
/* harmony import */ var _user_dto__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./user.dto */ "./src/app/dto/user.dto.ts");

var AuthenticationSessionDTO = /** @class */ (function () {
    function AuthenticationSessionDTO() {
        this.connected = false;
        this.token = "";
        this.user = new _user_dto__WEBPACK_IMPORTED_MODULE_0__["UserDTO"]();
    }
    return AuthenticationSessionDTO;
}());



/***/ }),

/***/ "./src/app/dto/user.dto.ts":
/*!*********************************!*\
  !*** ./src/app/dto/user.dto.ts ***!
  \*********************************/
/*! exports provided: UserDTO, UserConfigurationDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserDTO", function() { return UserDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserConfigurationDTO", function() { return UserConfigurationDTO; });
var UserDTO = /** @class */ (function () {
    function UserDTO() {
        this.login = "";
        this.email = "";
        this.configuration = new UserConfigurationDTO();
    }
    return UserDTO;
}());

var UserConfigurationDTO = /** @class */ (function () {
    function UserConfigurationDTO() {
        this.culture = "";
    }
    return UserConfigurationDTO;
}());



/***/ }),

/***/ "./src/app/internals/loader.interceptor.ts":
/*!*************************************************!*\
  !*** ./src/app/internals/loader.interceptor.ts ***!
  \*************************************************/
/*! exports provided: LoaderInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoaderInterceptor", function() { return LoaderInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



/** Gestion de l'indicateur de chargement */
var LoaderInterceptor = /** @class */ (function () {
    function LoaderInterceptor() {
        this.count = 0;
        this.loader = new rxjs__WEBPACK_IMPORTED_MODULE_1__["BehaviorSubject"](false);
    }
    /** Retourne le statut courant du chargement */
    LoaderInterceptor.prototype.getLoader = function () {
        return this.loader.asObservable();
    };
    LoaderInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        return next
            .handle(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(function (data) {
            if (data.type == 0) {
                /* Dafuq */
                _this.count++;
                if (_this.count == 1) {
                    _this.loader.next(true);
                }
            }
            else {
                _this.count--;
                if (_this.count == 0) {
                    _this.loader.next(false);
                }
            }
            return data;
        }));
    };
    LoaderInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [])
    ], LoaderInterceptor);
    return LoaderInterceptor;
}());



/***/ }),

/***/ "./src/app/internals/root.interceptor.ts":
/*!***********************************************!*\
  !*** ./src/app/internals/root.interceptor.ts ***!
  \***********************************************/
/*! exports provided: RootInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RootInterceptor", function() { return RootInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

/* Redirection des requêtes sortantes vers "/services/.." */
var RootInterceptor = /** @class */ (function () {
    function RootInterceptor() {
    }
    RootInterceptor.prototype.intercept = function (request, next) {
        var event = request.clone({
            url: "services/" + request.url
        });
        return next.handle(event);
    };
    RootInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        })
    ], RootInterceptor);
    return RootInterceptor;
}());



/***/ }),

/***/ "./src/app/internals/token.interceptor.ts":
/*!************************************************!*\
  !*** ./src/app/internals/token.interceptor.ts ***!
  \************************************************/
/*! exports provided: TokenInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TokenInterceptor", function() { return TokenInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../dto/authentication.session.dto */ "./src/app/dto/authentication.session.dto.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



/** Gestion du jeton */
var TokenInterceptor = /** @class */ (function () {
    function TokenInterceptor(authentication) {
        var _this = this;
        this.authentication = authentication;
        this.credentials = new _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_2__["AuthenticationSessionDTO"]();
        this.authentication
            .getCredentials()
            .subscribe(function (data) {
            _this.credentials = data;
        });
    }
    TokenInterceptor.prototype.intercept = function (request, next) {
        if (this.credentials.connected) {
            var modified = request.clone({
                setHeaders: {
                    'token': this.credentials.token
                }
            });
            return next.handle(modified);
        }
        else {
            return next.handle(request);
        }
    };
    TokenInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_services_authentication_service__WEBPACK_IMPORTED_MODULE_1__["AuthenticationService"]])
    ], TokenInterceptor);
    return TokenInterceptor;
}());



/***/ }),

/***/ "./src/app/services/authentication.service.ts":
/*!****************************************************!*\
  !*** ./src/app/services/authentication.service.ts ***!
  \****************************************************/
/*! exports provided: AuthenticationService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthenticationService", function() { return AuthenticationService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../dto/authentication.session.dto */ "./src/app/dto/authentication.session.dto.ts");
/* harmony import */ var _state_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./state.service */ "./src/app/services/state.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/** Service d'authentification */
var AuthenticationService = /** @class */ (function () {
    function AuthenticationService(http, state) {
        this.http = http;
        this.state = state;
        this.credentials = new rxjs__WEBPACK_IMPORTED_MODULE_2__["BehaviorSubject"](new _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_3__["AuthenticationSessionDTO"]());
    }
    /** Retourne le droits d'accès courants */
    AuthenticationService.prototype.getCredentials = function () {
        return this.credentials.asObservable();
    };
    /**
     * Tente une connexion
     * @param name Login ou e-mail de l'utilisateur.
     * @param password Mot de passe.
     */
    AuthenticationService.prototype.connect = function (name, password) {
        var _this = this;
        if (name && password) {
            this.http
                .get("auth/connect?name=" + name + "&password=" + password)
                .subscribe(function (data) {
                _this.credentials.next(data);
                _this.state.loadState();
            });
        }
        else {
            throw new Error("Missing argument");
        }
    };
    /** Procède à la déconnexion. */
    AuthenticationService.prototype.disconnect = function () {
        this.credentials.next(new _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_3__["AuthenticationSessionDTO"]());
        this.http.get("auth/disconnect");
    };
    AuthenticationService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"],
            _state_service__WEBPACK_IMPORTED_MODULE_4__["StateService"]])
    ], AuthenticationService);
    return AuthenticationService;
}());



/***/ }),

/***/ "./src/app/services/state.service.ts":
/*!*******************************************!*\
  !*** ./src/app/services/state.service.ts ***!
  \*******************************************/
/*! exports provided: StateService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StateService", function() { return StateService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




/** Service d'état */
var StateService = /** @class */ (function () {
    function StateService(http) {
        this.http = http;
        this.views = new rxjs__WEBPACK_IMPORTED_MODULE_2__["BehaviorSubject"]([]);
    }
    /** Retourne la liste des vues */
    StateService.prototype.getViews = function () {
        return this.views.asObservable();
    };
    /** Charge l'état complet de l'application */
    StateService.prototype.loadState = function () {
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["forkJoin"])(this.loadViews());
    };
    /** Recharge les vues */
    StateService.prototype.loadViews = function () {
        var _this = this;
        return this.http
            .get("views/get")
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (data) {
            _this.views.next(data);
            return data;
        }));
    };
    StateService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], StateService);
    return StateService;
}());



/***/ }),

/***/ "./src/app/services/translator.service.ts":
/*!************************************************!*\
  !*** ./src/app/services/translator.service.ts ***!
  \************************************************/
/*! exports provided: TranslatorService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TranslatorService", function() { return TranslatorService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _authentication_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./authentication.service */ "./src/app/services/authentication.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


/** Service de traduction */
var TranslatorService = /** @class */ (function () {
    function TranslatorService(authentication) {
        var _this = this;
        this.authentication = authentication;
        this.authentication
            .getCredentials()
            .subscribe(function (data) {
            _this.credentials = data;
        });
    }
    /** Retourne la langue de l'utilisateur */
    TranslatorService.prototype.getLang = function () {
        return this.credentials.connected ? this.credentials.user.configuration.culture : "FRA";
    };
    /**
     * Retourne la traduction appropriée pour un lot de traductions.
     * @param bundle Lot de traductions
     */
    TranslatorService.prototype.translate = function (bundle) {
        console.log(bundle);
        return bundle.data[this.getLang()] ? bundle.data[this.getLang()] : "?";
    };
    TranslatorService.prototype.tr = function (bundle) {
        return this.translate(bundle);
    };
    TranslatorService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_authentication_service__WEBPACK_IMPORTED_MODULE_1__["AuthenticationService"]])
    ], TranslatorService);
    return TranslatorService;
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
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
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
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\kawa\source\repos\Baraka\Baraka\ui\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map
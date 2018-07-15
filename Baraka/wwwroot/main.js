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
/* harmony import */ var _components_layout_popin_cpn__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/layout/popin.cpn */ "./src/app/components/layout/popin.cpn.ts");
/* harmony import */ var _components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/layout/root.cpn */ "./src/app/components/layout/root.cpn.ts");
/* harmony import */ var _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/pages/home.cpn */ "./src/app/components/pages/home.cpn.ts");
/* harmony import */ var _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/pages/login.cpn */ "./src/app/components/pages/login.cpn.ts");
/* harmony import */ var _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./components/pages/view.cpn */ "./src/app/components/pages/view.cpn.ts");
/* harmony import */ var _components_pages_views_admin_cpn__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./components/pages/views/admin.cpn */ "./src/app/components/pages/views/admin.cpn.ts");
/* harmony import */ var _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./internals/loader.interceptor */ "./src/app/internals/loader.interceptor.ts");
/* harmony import */ var _internals_exceptions_interceptor__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./internals/exceptions.interceptor */ "./src/app/internals/exceptions.interceptor.ts");
/* harmony import */ var _internals_root_interceptor__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./internals/root.interceptor */ "./src/app/internals/root.interceptor.ts");
/* harmony import */ var _internals_token_interceptor__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./internals/token.interceptor */ "./src/app/internals/token.interceptor.ts");
/* harmony import */ var _internals_references_interceptor__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./internals/references.interceptor */ "./src/app/internals/references.interceptor.ts");
/* harmony import */ var _components_pages_views_admin_table_edit_cpn__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./components/pages/views/admin/table.edit.cpn */ "./src/app/components/pages/views/admin/table.edit.cpn.ts");
/* harmony import */ var _components_formulars_admin_tables_table_add_form__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./components/formulars/admin/tables/table.add.form */ "./src/app/components/formulars/admin/tables/table.add.form.ts");
/* harmony import */ var _components_formulars_admin_tables_field_add_form__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./components/formulars/admin/tables/field.add.form */ "./src/app/components/formulars/admin/tables/field.add.form.ts");
/* harmony import */ var _components_formulars_admin_tables_table_edit_form__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./components/formulars/admin/tables/table.edit.form */ "./src/app/components/formulars/admin/tables/table.edit.form.ts");
/* harmony import */ var _components_formulars_admin_tables_field_edit_form__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! ./components/formulars/admin/tables/field.edit.form */ "./src/app/components/formulars/admin/tables/field.edit.form.ts");
/* harmony import */ var _internals_exceptions_handler__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! ./internals/exceptions.handler */ "./src/app/internals/exceptions.handler.ts");
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
                _components_formulars_admin_tables_field_add_form__WEBPACK_IMPORTED_MODULE_18__["AdminFieldAddFormular"],
                _components_formulars_admin_tables_field_edit_form__WEBPACK_IMPORTED_MODULE_20__["AdminFieldEditFormular"],
                _components_formulars_admin_tables_table_add_form__WEBPACK_IMPORTED_MODULE_17__["AdminTableAddFormular"],
                _components_formulars_admin_tables_table_edit_form__WEBPACK_IMPORTED_MODULE_19__["AdminTableEditFormular"],
                _components_layout_popin_cpn__WEBPACK_IMPORTED_MODULE_5__["LayoutPopinComponent"],
                _components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_6__["LayoutRootComponent"],
                _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_7__["PageHomeComponent"],
                _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_8__["PageLoginComponent"],
                _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_9__["PageViewComponent"],
                _components_pages_views_admin_cpn__WEBPACK_IMPORTED_MODULE_10__["PagesViewAdminComponent"],
                _components_pages_views_admin_table_edit_cpn__WEBPACK_IMPORTED_MODULE_16__["PagesViewAdminTableEditComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_1__["ReactiveFormsModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"].forRoot([
                    { path: 'home', component: _components_pages_home_cpn__WEBPACK_IMPORTED_MODULE_7__["PageHomeComponent"] },
                    { path: 'login', component: _components_pages_login_cpn__WEBPACK_IMPORTED_MODULE_8__["PageLoginComponent"] },
                    { path: 'view/:view', component: _components_pages_view_cpn__WEBPACK_IMPORTED_MODULE_9__["PageViewComponent"] },
                    { path: 'view/:view/admin', component: _components_pages_views_admin_cpn__WEBPACK_IMPORTED_MODULE_10__["PagesViewAdminComponent"] },
                    { path: 'view/:view/admin/model/:action', component: _components_pages_views_admin_table_edit_cpn__WEBPACK_IMPORTED_MODULE_16__["PagesViewAdminTableEditComponent"] },
                    { path: 'view/:view/admin/model/:action/:id', component: _components_pages_views_admin_table_edit_cpn__WEBPACK_IMPORTED_MODULE_16__["PagesViewAdminTableEditComponent"] },
                    { path: '', redirectTo: '/home', pathMatch: 'full' }
                ])
            ],
            providers: [{
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useExisting: _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_11__["LoaderInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useExisting: _internals_exceptions_interceptor__WEBPACK_IMPORTED_MODULE_12__["ExceptionsInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useClass: _internals_root_interceptor__WEBPACK_IMPORTED_MODULE_13__["RootInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useClass: _internals_token_interceptor__WEBPACK_IMPORTED_MODULE_14__["TokenInterceptor"],
                    multi: true
                }, {
                    provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HTTP_INTERCEPTORS"],
                    useClass: _internals_references_interceptor__WEBPACK_IMPORTED_MODULE_15__["ReferencesInterceptor"],
                    multi: true
                }, {
                    provide: _angular_core__WEBPACK_IMPORTED_MODULE_3__["ErrorHandler"],
                    useClass: _internals_exceptions_handler__WEBPACK_IMPORTED_MODULE_21__["ExceptionsHandler"]
                }],
            bootstrap: [_components_layout_root_cpn__WEBPACK_IMPORTED_MODULE_6__["LayoutRootComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.add.form.html":
/*!***********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.add.form.html ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"form-group\" [formGroup]=\"form\" (submit)=\"submit()\">\r\n  <div>\r\n    <label>Nom</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"label\" />\r\n    <p *ngIf=\"label.invalid && label.dirty\">Wtf is this shit ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Code</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"code\" />\r\n    <p *ngIf=\"code.invalid && code.dirty\">Wut ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Type</label>\r\n    <select formControlName=\"type\">\r\n      <option value=\"STRING\">Chaîne de caractères</option>\r\n      <option value=\"BOOLEAN\">Logique</option>\r\n      <option value=\"NUMERIC\">Nombre</option>\r\n      <option value=\"DATE\">Date</option>\r\n      <option value=\"REFERENCE\">Liaison</option>\r\n    </select>\r\n  </div>\r\n  <div *ngIf=\"type.value == 'REFERENCE'\">\r\n    <label>Destination</label>\r\n    <select formControlName=\"reference\">\r\n      <option value=\"t.Id\"\r\n              *ngFor=\"let t of tables\">{{ translator.tr(t.label) }}</option>\r\n    </select>\r\n  </div>\r\n  <div>\r\n    <input type=\"submit\"\r\n           value=\"Ajouter\"\r\n           [disabled]=\"form.invalid\" />\r\n  </div>\r\n</form>\r\n"

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.add.form.less":
/*!***********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.add.form.less ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.add.form.ts":
/*!*********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.add.form.ts ***!
  \*********************************************************************/
/*! exports provided: AdminFieldAddFormular */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminFieldAddFormular", function() { return AdminFieldAddFormular; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _services_validators_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/validators.service */ "./src/app/services/validators.service.ts");
/* harmony import */ var _utils_string_utils__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../utils/string.utils */ "./src/app/utils/string.utils.ts");
/* harmony import */ var _dto_table_dto__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../dto/table.dto */ "./src/app/dto/table.dto.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _persisted_abs__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../persisted.abs */ "./src/app/components/formulars/persisted.abs.ts");
/* harmony import */ var _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ../../../../dto/field.dto */ "./src/app/dto/field.dto.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};











/** Formulaire d'ajout d'un champ */
var AdminFieldAddFormular = /** @class */ (function (_super) {
    __extends(AdminFieldAddFormular, _super);
    function AdminFieldAddFormular(translator, http, state, router, ar, validators) {
        var _this = _super.call(this, http, "fields") || this;
        _this.translator = translator;
        _this.http = http;
        _this.state = state;
        _this.router = router;
        _this.ar = ar;
        _this.validators = validators;
        return _this;
    }
    AdminFieldAddFormular.prototype.ngOnInit = function () {
        var _this = this;
        /* Création du formulaire */
        this.label = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3)
        ]);
        this.code = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3),
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].pattern(/^[a-z0-9_]+$/)
        ], [this.validators.check("fields/check-code?table=" + this.table.id + "&code=")]);
        this.type = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('STRING', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]);
        this.reference = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', []);
        this.form = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
            label: this.label,
            code: this.code,
            type: this.type,
            reference: this.reference
        });
        /* Gestion du code */
        this.label
            .valueChanges
            .subscribe(function (data) {
            if (!_this.persisted && _this.code.pristine) {
                var treated = _utils_string_utils__WEBPACK_IMPORTED_MODULE_5__["StringUtils"].StringToCode(_this.label.value);
                _this.code.setValue(treated);
            }
        });
        /* Surveillance des tables */
        this.state
            .getTables()
            .subscribe(function (data) { return _this.tables = data; });
    };
    AdminFieldAddFormular.prototype.check = function () {
        return this.form.valid;
    };
    AdminFieldAddFormular.prototype.provide = function () {
        var result = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["FieldDTO"]();
        result.label = this.translator.edit(result.label, this.label.value);
        result.code = this.code.value;
        switch (this.type.value) {
            case "STRING":
                result.configuration = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["StringFieldConfigurationDTO"]();
                break;
            case "BOOLEAN":
                result.configuration = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["BooleanFieldConfigurationDTO"]();
                break;
            case "DATE":
                result.configuration = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["DateFieldConfigurationDTO"]();
                break;
            case "NUMERIC":
                result.configuration = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["NumericFieldConfigurationDTO"]();
                break;
            case "REFERENCE":
                result.configuration = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_10__["ReferenceFieldConfigurationDTO"]();
                break;
        }
        result.table.id = this.table.id;
        return result;
    };
    AdminFieldAddFormular.prototype.digest = function (entity) {
        entity.table = this.table;
        this.table.fields.push(entity);
        this.state.publishTable(this.table);
        this.router.navigate(["../../edit-field", entity.id], { relativeTo: this.ar });
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _dto_table_dto__WEBPACK_IMPORTED_MODULE_6__["TableDTO"])
    ], AdminFieldAddFormular.prototype, "table", void 0);
    AdminFieldAddFormular = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'admin-field-add',
            template: __webpack_require__(/*! ./field.add.form.html */ "./src/app/components/formulars/admin/tables/field.add.form.html"),
            styles: [__webpack_require__(/*! ./field.add.form.less */ "./src/app/components/formulars/admin/tables/field.add.form.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_7__["TranslatorService"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_8__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _services_validators_service__WEBPACK_IMPORTED_MODULE_4__["ValidatorsService"]])
    ], AdminFieldAddFormular);
    return AdminFieldAddFormular;
}(_persisted_abs__WEBPACK_IMPORTED_MODULE_9__["PersitedAbstractFormular"]));



/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.edit.form.html":
/*!************************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.edit.form.html ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"form-group\" [formGroup]=\"form\" (submit)=\"save()\">\r\n  <h2>Editer le champ {{ field.id }}</h2>\r\n  <div>\r\n    <label>Nom</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"label\" />\r\n    <p *ngIf=\"label.invalid && label.dirty\">Wtf is this shit ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Code</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"code\" />\r\n    <p *ngIf=\"code.invalid && code.dirty\">Wut ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Archivée</label>\r\n    <input type=\"checkbox\"\r\n           class=\"form-control\"\r\n           formControlName=\"archived\" />\r\n  </div>\r\n  <div>\r\n    <input type=\"submit\"\r\n           value=\"Modifier\"\r\n           [disabled]=\"form.invalid\" />\r\n  </div>\r\n</form>\r\n"

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.edit.form.less":
/*!************************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.edit.form.less ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/field.edit.form.ts":
/*!**********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/field.edit.form.ts ***!
  \**********************************************************************/
/*! exports provided: AdminFieldEditFormular */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminFieldEditFormular", function() { return AdminFieldEditFormular; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _services_validators_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/validators.service */ "./src/app/services/validators.service.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _persisted_abs__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../persisted.abs */ "./src/app/components/formulars/persisted.abs.ts");
/* harmony import */ var _dto_field_dto__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../dto/field.dto */ "./src/app/dto/field.dto.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









/** Formulaire d'ajout d'une table */
var AdminFieldEditFormular = /** @class */ (function (_super) {
    __extends(AdminFieldEditFormular, _super);
    function AdminFieldEditFormular(translator, http, state, router, ar, validators) {
        var _this = _super.call(this, http, "fields") || this;
        _this.translator = translator;
        _this.http = http;
        _this.state = state;
        _this.router = router;
        _this.ar = ar;
        _this.validators = validators;
        return _this;
    }
    Object.defineProperty(AdminFieldEditFormular.prototype, "field", {
        get: function () {
            return this._field;
        },
        set: function (field) {
            this._field = field;
            if (this.form != null && this.field != null) {
                this.refresh();
            }
        },
        enumerable: true,
        configurable: true
    });
    ;
    ;
    AdminFieldEditFormular.prototype.ngOnInit = function () {
        var _this = this;
        /* Gestion des références */
        this.table = this.field.table;
        /* Création du formulaire */
        this.label = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.translator.tr(this.field.label), [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3)
        ]);
        this.code = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.field.code, [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3),
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].pattern(/^[a-z0-9_]+$/)
        ], [this.validators.check("fields/check-code?table=" + this.table.id + "&code=")]);
        this.archived = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.field.configuration.archived, []);
        this.reference = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', []);
        this.form = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
            label: this.label,
            code: this.code,
            archived: this.archived,
            reference: this.reference
        });
        /* Surveillance des tables */
        this.state
            .getTables()
            .subscribe(function (data) { return _this.tables = data; });
    };
    AdminFieldEditFormular.prototype.check = function () {
        return this.form.valid;
    };
    AdminFieldEditFormular.prototype.provide = function () {
        var result = new _dto_field_dto__WEBPACK_IMPORTED_MODULE_8__["FieldDTO"]();
        result.id = this.field.id;
        result.label = this.translator.edit(result.label, this.label.value);
        result.code = this.code.value;
        result.configuration = this.field.configuration;
        result.configuration.archived = this.archived.value;
        result.table.id = this.table.id;
        return result;
    };
    AdminFieldEditFormular.prototype.digest = function (entity) {
        entity.table = this.table;
        this.state.publishField(entity);
    };
    /** Rafraichit le contenu du formulaire. */
    AdminFieldEditFormular.prototype.refresh = function () {
        if (this.form != null && this.field != null) {
            this.label.setValue(this.translator.tr(this.field.label));
            this.code.setValue(this.field.code);
            this.archived.setValue(this.field.configuration.archived);
        }
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _dto_field_dto__WEBPACK_IMPORTED_MODULE_8__["FieldDTO"]),
        __metadata("design:paramtypes", [_dto_field_dto__WEBPACK_IMPORTED_MODULE_8__["FieldDTO"]])
    ], AdminFieldEditFormular.prototype, "field", null);
    AdminFieldEditFormular = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'admin-field-edit',
            template: __webpack_require__(/*! ./field.edit.form.html */ "./src/app/components/formulars/admin/tables/field.edit.form.html"),
            styles: [__webpack_require__(/*! ./field.edit.form.less */ "./src/app/components/formulars/admin/tables/field.edit.form.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_5__["TranslatorService"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_6__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _services_validators_service__WEBPACK_IMPORTED_MODULE_4__["ValidatorsService"]])
    ], AdminFieldEditFormular);
    return AdminFieldEditFormular;
}(_persisted_abs__WEBPACK_IMPORTED_MODULE_7__["PersitedAbstractFormular"]));



/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.add.form.html":
/*!***********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.add.form.html ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"form-group\" [formGroup]=\"form\" (submit)=\"add()\">\r\n  <div>\r\n    <label>Nom</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"label\" />\r\n    <p *ngIf=\"label.invalid && label.dirty\">Wtf is this shit ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Code</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"code\" />\r\n    <p *ngIf=\"code.invalid && code.dirty\">Wut ?</p>\r\n  </div>\r\n  <div>\r\n    <input type=\"submit\"\r\n           value=\"Ajouter\"\r\n           [disabled]=\"form.invalid\" />\r\n  </div>\r\n</form>\r\n"

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.add.form.less":
/*!***********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.add.form.less ***!
  \***********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.add.form.ts":
/*!*********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.add.form.ts ***!
  \*********************************************************************/
/*! exports provided: AdminTableAddFormular */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminTableAddFormular", function() { return AdminTableAddFormular; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _services_validators_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/validators.service */ "./src/app/services/validators.service.ts");
/* harmony import */ var _utils_string_utils__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../utils/string.utils */ "./src/app/utils/string.utils.ts");
/* harmony import */ var _dto_table_dto__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../dto/table.dto */ "./src/app/dto/table.dto.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _persisted_abs__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ../../persisted.abs */ "./src/app/components/formulars/persisted.abs.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};










/** Formulaire d'ajout d'une table */
var AdminTableAddFormular = /** @class */ (function (_super) {
    __extends(AdminTableAddFormular, _super);
    function AdminTableAddFormular(translator, http, state, router, validators, ar) {
        var _this = _super.call(this, http, "tables") || this;
        _this.translator = translator;
        _this.http = http;
        _this.state = state;
        _this.router = router;
        _this.validators = validators;
        _this.ar = ar;
        return _this;
    }
    AdminTableAddFormular.prototype.ngOnInit = function () {
        var _this = this;
        /* Création du formulaire */
        this.label = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3)
        ]);
        this.code = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3),
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].pattern(/^[a-z0-9_]+$/)
        ], [this.validators.check("tables/check-code?code=")]);
        this.form = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
            label: this.label,
            code: this.code
        });
        /* Gestion du code */
        this.label
            .valueChanges
            .subscribe(function (data) {
            if (!_this.persisted && _this.code.pristine) {
                var treated = _utils_string_utils__WEBPACK_IMPORTED_MODULE_5__["StringUtils"].StringToCode(_this.label.value);
                _this.code.setValue(treated);
            }
        });
    };
    AdminTableAddFormular.prototype.check = function () {
        return this.form.valid;
    };
    AdminTableAddFormular.prototype.provide = function () {
        var result = new _dto_table_dto__WEBPACK_IMPORTED_MODULE_6__["TableDTO"]();
        result.label = this.translator.edit(result.label, this.label.value);
        result.code = this.code.value;
        result.configuration = new _dto_table_dto__WEBPACK_IMPORTED_MODULE_6__["TableConfigurationDTO"]();
        return result;
    };
    AdminTableAddFormular.prototype.digest = function (entity) {
        this.state.publishTable(entity);
        this.router.navigate(["../edit-table", entity.id], { relativeTo: this.ar });
    };
    AdminTableAddFormular = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'admin-table-add',
            template: __webpack_require__(/*! ./table.add.form.html */ "./src/app/components/formulars/admin/tables/table.add.form.html"),
            styles: [__webpack_require__(/*! ./table.add.form.less */ "./src/app/components/formulars/admin/tables/table.add.form.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_7__["TranslatorService"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_8__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _services_validators_service__WEBPACK_IMPORTED_MODULE_4__["ValidatorsService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], AdminTableAddFormular);
    return AdminTableAddFormular;
}(_persisted_abs__WEBPACK_IMPORTED_MODULE_9__["PersitedAbstractFormular"]));



/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.edit.form.html":
/*!************************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.edit.form.html ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<form class=\"form-group\" [formGroup]=\"form\" (submit)=\"save()\">\r\n  <h2>Editer la table</h2>\r\n  <div>\r\n    <label>Nom</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"label\" />\r\n    <p *ngIf=\"label.invalid && label.dirty\">Wtf is this shit ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Code</label>\r\n    <input type=\"text\"\r\n           class=\"form-control\"\r\n           formControlName=\"code\" />\r\n    <p *ngIf=\"code.invalid && code.dirty\">Wut ?</p>\r\n  </div>\r\n  <div>\r\n    <label>Archivée</label>\r\n    <input type=\"checkbox\"\r\n           class=\"form-control\"\r\n           formControlName=\"archived\" />\r\n  </div>\r\n  <div>\r\n    <input type=\"submit\"\r\n           value=\"Modifier\"\r\n           [disabled]=\"form.invalid\" />\r\n  </div>\r\n</form>\r\n"

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.edit.form.less":
/*!************************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.edit.form.less ***!
  \************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/formulars/admin/tables/table.edit.form.ts":
/*!**********************************************************************!*\
  !*** ./src/app/components/formulars/admin/tables/table.edit.form.ts ***!
  \**********************************************************************/
/*! exports provided: AdminTableEditFormular */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AdminTableEditFormular", function() { return AdminTableEditFormular; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _services_validators_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/validators.service */ "./src/app/services/validators.service.ts");
/* harmony import */ var _dto_table_dto__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../../../dto/table.dto */ "./src/app/dto/table.dto.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _persisted_abs__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ../../persisted.abs */ "./src/app/components/formulars/persisted.abs.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};









/** Formulaire d'ajout d'une table */
var AdminTableEditFormular = /** @class */ (function (_super) {
    __extends(AdminTableEditFormular, _super);
    function AdminTableEditFormular(translator, http, state, router, validators) {
        var _this = _super.call(this, http, "tables") || this;
        _this.translator = translator;
        _this.http = http;
        _this.state = state;
        _this.router = router;
        _this.validators = validators;
        return _this;
    }
    AdminTableEditFormular.prototype.ngOnInit = function () {
        /* Création du formulaire */
        this.label = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.translator.tr(this.table.label), [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3)
        ]);
        this.code = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.table.code, [
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required,
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].minLength(3),
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].pattern(/^[a-z0-9_]+$/)
        ], [this.validators.check("tables/check-code?code=")]);
        this.archived = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"](this.table.configuration.archived, []);
        this.form = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormGroup"]({
            label: this.label,
            code: this.code,
            archived: this.archived
        });
    };
    AdminTableEditFormular.prototype.check = function () {
        return this.form.valid;
    };
    AdminTableEditFormular.prototype.provide = function () {
        var result = new _dto_table_dto__WEBPACK_IMPORTED_MODULE_5__["TableDTO"]();
        result.id = this.table.id;
        result.label = this.translator.edit(result.label, this.label.value);
        result.code = this.code.value;
        result.configuration = new _dto_table_dto__WEBPACK_IMPORTED_MODULE_5__["TableConfigurationDTO"]();
        result.configuration.archived = this.archived.value;
        return result;
    };
    AdminTableEditFormular.prototype.digest = function (entity) {
        entity.fields = this.table.fields;
        this.state.publishTable(entity);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _dto_table_dto__WEBPACK_IMPORTED_MODULE_5__["TableDTO"])
    ], AdminTableEditFormular.prototype, "table", void 0);
    AdminTableEditFormular = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'admin-table-edit',
            template: __webpack_require__(/*! ./table.edit.form.html */ "./src/app/components/formulars/admin/tables/table.edit.form.html"),
            styles: [__webpack_require__(/*! ./table.edit.form.less */ "./src/app/components/formulars/admin/tables/table.edit.form.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_6__["TranslatorService"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_7__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _services_validators_service__WEBPACK_IMPORTED_MODULE_4__["ValidatorsService"]])
    ], AdminTableEditFormular);
    return AdminTableEditFormular;
}(_persisted_abs__WEBPACK_IMPORTED_MODULE_8__["PersitedAbstractFormular"]));



/***/ }),

/***/ "./src/app/components/formulars/persisted.abs.ts":
/*!*******************************************************!*\
  !*** ./src/app/components/formulars/persisted.abs.ts ***!
  \*******************************************************/
/*! exports provided: PersitedAbstractFormular */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PersitedAbstractFormular", function() { return PersitedAbstractFormular; });
/** Classe abstraite descriptive d'un formulaire permettant l'ajout et/ou la mise à jour
 *  d'une entité persitante en base.
 *  Le composant permet de réaliser des appels au serveur sur la base de deux modes :
 *  insertion (à l'URL '{prefix}/add') et mise à jour ('{prefix}/update'). Le préfixe
 *  utilisé est fixé directement par les classes héritantes.
 *  Par défaut, la classe réalise un premier appel au serveur (via la méthode 'submit()')
 *  en mode d'insertion et les suivants en mode de mise à jour. La classe fille peut toutefois
 *  forcer le comportement de chaque appel. */
var PersitedAbstractFormular = /** @class */ (function () {
    function PersitedAbstractFormular(http, prefix) {
        this.http = http;
        this.prefix = prefix;
        this.persisted = false;
    }
    /** Réalise une action d'ajout. */
    PersitedAbstractFormular.prototype.add = function () {
        this.sync(true);
    };
    /** Réalise une action de mise à jour. */
    PersitedAbstractFormular.prototype.save = function () {
        this.sync(false);
    };
    /** Réalise une action d'ajout ou de mise à jour. */
    PersitedAbstractFormular.prototype.submit = function () {
        this.sync(!this.persisted);
    };
    /**
     * Synchronise l'entité avec le serveur.
     * @param add true pour réaliser un ajout, false sinon.
     */
    PersitedAbstractFormular.prototype.sync = function (add) {
        var _this = this;
        if (this.check()) {
            var action = add ? "add" : "update";
            var instance = this.provide();
            this.http
                .post(this.prefix + "/" + action, instance)
                .subscribe(function (data) {
                _this.persisted = false;
                _this.digest(data, add);
            });
        }
    };
    return PersitedAbstractFormular;
}());



/***/ }),

/***/ "./src/app/components/layout/popin.cpn.html":
/*!**************************************************!*\
  !*** ./src/app/components/layout/popin.cpn.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"popin\">\r\n  <ng-content></ng-content>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/layout/popin.cpn.less":
/*!**************************************************!*\
  !*** ./src/app/components/layout/popin.cpn.less ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div.popin {\n  background: red;\n  color: white;\n  left: 48px;\n  position: fixed;\n  top: 48px;\n}\n"

/***/ }),

/***/ "./src/app/components/layout/popin.cpn.ts":
/*!************************************************!*\
  !*** ./src/app/components/layout/popin.cpn.ts ***!
  \************************************************/
/*! exports provided: LayoutPopinComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LayoutPopinComponent", function() { return LayoutPopinComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

/** Fenêtre pop-in */
var LayoutPopinComponent = /** @class */ (function () {
    function LayoutPopinComponent() {
    }
    LayoutPopinComponent.prototype.ngOnInit = function () {
    };
    LayoutPopinComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'layout-popin',
            template: __webpack_require__(/*! ./popin.cpn.html */ "./src/app/components/layout/popin.cpn.html"),
            styles: [__webpack_require__(/*! ./popin.cpn.less */ "./src/app/components/layout/popin.cpn.less")]
        })
    ], LayoutPopinComponent);
    return LayoutPopinComponent;
}());



/***/ }),

/***/ "./src/app/components/layout/root.cpn.html":
/*!*************************************************!*\
  !*** ./src/app/components/layout/root.cpn.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h1>\r\n    <span>yo {{ credentials.user.login }}</span>\r\n    {{ error }} {{ error != null }}\r\n  </h1>\r\n  <router-outlet></router-outlet>\r\n  <layout-popin *ngIf=\"error\">\r\n    <p>{{ translator.translate(error.message) }}</p>\r\n    <p (click)=\"error = null\">Fermer !</p>\r\n  </layout-popin>\r\n  <div id=\"loader\" *ngIf=\"loading\">Chargement</div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/layout/root.cpn.less":
/*!*************************************************!*\
  !*** ./src/app/components/layout/root.cpn.less ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div#loader {\n  background: #444;\n  bottom: 0;\n  color: white;\n  font-weight: bold;\n  position: fixed;\n  right: 0;\n}\n"

/***/ }),

/***/ "./src/app/components/layout/root.cpn.ts":
/*!***********************************************!*\
  !*** ./src/app/components/layout/root.cpn.ts ***!
  \***********************************************/
/*! exports provided: LayoutRootComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LayoutRootComponent", function() { return LayoutRootComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../internals/loader.interceptor */ "./src/app/internals/loader.interceptor.ts");
/* harmony import */ var _internals_exceptions_interceptor__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../internals/exceptions.interceptor */ "./src/app/internals/exceptions.interceptor.ts");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../dto/authentication.session.dto */ "./src/app/dto/authentication.session.dto.ts");
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
    function LayoutRootComponent(translator, http, router, loader, exceptions, authentication) {
        this.translator = translator;
        this.http = http;
        this.router = router;
        this.loader = loader;
        this.exceptions = exceptions;
        this.authentication = authentication;
        this.credentials = new _dto_authentication_session_dto__WEBPACK_IMPORTED_MODULE_7__["AuthenticationSessionDTO"]();
        this.loading = false;
        this.error = null;
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
        // Suivi des erreurs
        this.exceptions
            .getFailures()
            .subscribe(function (data) {
            _this.error = data;
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
            template: __webpack_require__(/*! ./root.cpn.html */ "./src/app/components/layout/root.cpn.html"),
            styles: [__webpack_require__(/*! ./root.cpn.less */ "./src/app/components/layout/root.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_3__["TranslatorService"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _internals_loader_interceptor__WEBPACK_IMPORTED_MODULE_4__["LoaderInterceptor"],
            _internals_exceptions_interceptor__WEBPACK_IMPORTED_MODULE_5__["ExceptionsInterceptor"],
            _services_authentication_service__WEBPACK_IMPORTED_MODULE_6__["AuthenticationService"]])
    ], LayoutRootComponent);
    return LayoutRootComponent;
}());



/***/ }),

/***/ "./src/app/components/pages/home.cpn.html":
/*!************************************************!*\
  !*** ./src/app/components/pages/home.cpn.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Salut mec</h2>\r\n  <p>Choisis une vue.</p>\r\n  <ul>\r\n    <li *ngFor=\"let view of views\"\r\n        [routerLink]=\"['/view', view.id]\">{{ view.id }} : {{ translator.tr(view.label) }}</li>\r\n  </ul>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages/home.cpn.less":
/*!************************************************!*\
  !*** ./src/app/components/pages/home.cpn.less ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/pages/home.cpn.ts":
/*!**********************************************!*\
  !*** ./src/app/components/pages/home.cpn.ts ***!
  \**********************************************/
/*! exports provided: PageHomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageHomeComponent", function() { return PageHomeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../services/translator.service */ "./src/app/services/translator.service.ts");
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
        this.ar.params.subscribe(function (params) {
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
            template: __webpack_require__(/*! ./home.cpn.html */ "./src/app/components/pages/home.cpn.html"),
            styles: [__webpack_require__(/*! ./home.cpn.less */ "./src/app/components/pages/home.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_state_service__WEBPACK_IMPORTED_MODULE_2__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _services_authentication_service__WEBPACK_IMPORTED_MODULE_3__["AuthenticationService"],
            _services_translator_service__WEBPACK_IMPORTED_MODULE_4__["TranslatorService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PageHomeComponent);
    return PageHomeComponent;
}());



/***/ }),

/***/ "./src/app/components/pages/login.cpn.html":
/*!*************************************************!*\
  !*** ./src/app/components/pages/login.cpn.html ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Connexion</h2>\r\n  <form>\r\n    <div>\r\n      <label>Login</label>\r\n      <input type=\"text\"\r\n             name=\"name\"\r\n             [(ngModel)]=\"name\" />\r\n    </div>\r\n    <div>\r\n      <label>Mot de passe</label>\r\n      <input type=\"password\"\r\n             name=\"password\"\r\n             [(ngModel)]=\"password\" />\r\n    </div>\r\n    <input type=\"button\"\r\n           name=\"submit\"\r\n           value=\"Connexion\"\r\n           (click)=\"authentication.connect(name, password)\" />\r\n  </form>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages/login.cpn.less":
/*!*************************************************!*\
  !*** ./src/app/components/pages/login.cpn.less ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div {\n  background: pink;\n}\ndiv > h2 {\n  color: red;\n}\n"

/***/ }),

/***/ "./src/app/components/pages/login.cpn.ts":
/*!***********************************************!*\
  !*** ./src/app/components/pages/login.cpn.ts ***!
  \***********************************************/
/*! exports provided: PageLoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageLoginComponent", function() { return PageLoginComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_authentication_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../services/authentication.service */ "./src/app/services/authentication.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/state.service */ "./src/app/services/state.service.ts");
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
        this.ar.params.subscribe(function (params) {
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
            template: __webpack_require__(/*! ./login.cpn.html */ "./src/app/components/pages/login.cpn.html"),
            styles: [__webpack_require__(/*! ./login.cpn.less */ "./src/app/components/pages/login.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_authentication_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationService"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_3__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PageLoginComponent);
    return PageLoginComponent;
}());



/***/ }),

/***/ "./src/app/components/pages/view.abs.ts":
/*!**********************************************!*\
  !*** ./src/app/components/pages/view.abs.ts ***!
  \**********************************************/
/*! exports provided: PagesViewAbstractComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PagesViewAbstractComponent", function() { return PagesViewAbstractComponent; });
/** Vue abstraite */
var PagesViewAbstractComponent = /** @class */ (function () {
    function PagesViewAbstractComponent(redirect, state, router, ar) {
        var _this = this;
        this.redirect = redirect;
        this.state = state;
        this.router = router;
        this.ar = ar;
        this.ar.params.subscribe(function (params) {
            // onInit broken
            _this.state
                .getViews()
                .subscribe(function (views) {
                /* Récupération de la vue */
                _this.views = views;
                _this.view = views.filter(function (v) { return v.id == params["view"]; })[0];
                /* Redirection */
                if (_this.redirect) {
                    _this.router.navigate(["/view", _this.view.id, _this.view.configuration.type.toLowerCase()], {
                        skipLocationChange: true
                    });
                }
            });
        });
    }
    return PagesViewAbstractComponent;
}());



/***/ }),

/***/ "./src/app/components/pages/view.cpn.html":
/*!************************************************!*\
  !*** ./src/app/components/pages/view.cpn.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Chargement en cours {{ view.id }}</h2>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages/view.cpn.less":
/*!************************************************!*\
  !*** ./src/app/components/pages/view.cpn.less ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div {\n  background: pink;\n}\ndiv > h2 {\n  color: red;\n}\n"

/***/ }),

/***/ "./src/app/components/pages/view.cpn.ts":
/*!**********************************************!*\
  !*** ./src/app/components/pages/view.cpn.ts ***!
  \**********************************************/
/*! exports provided: PageViewComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageViewComponent", function() { return PageViewComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../services/state.service */ "./src/app/services/state.service.ts");
/* harmony import */ var _view_abs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./view.abs */ "./src/app/components/pages/view.abs.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var PageViewComponent = /** @class */ (function (_super) {
    __extends(PageViewComponent, _super);
    function PageViewComponent(state, router, ar) {
        var _this = _super.call(this, true, state, router, ar) || this;
        _this.state = state;
        _this.router = router;
        _this.ar = ar;
        _this.ar.params.subscribe(function (params) {
            // onInit broken
        });
        return _this;
    }
    PageViewComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-view',
            template: __webpack_require__(/*! ./view.cpn.html */ "./src/app/components/pages/view.cpn.html"),
            styles: [__webpack_require__(/*! ./view.cpn.less */ "./src/app/components/pages/view.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_state_service__WEBPACK_IMPORTED_MODULE_2__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PageViewComponent);
    return PageViewComponent;
}(_view_abs__WEBPACK_IMPORTED_MODULE_3__["PagesViewAbstractComponent"]));



/***/ }),

/***/ "./src/app/components/pages/views/admin.cpn.html":
/*!*******************************************************!*\
  !*** ./src/app/components/pages/views/admin.cpn.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h3>Liste des vues</h3>\r\n  <div>Ajouter</div>\r\n  <ul>\r\n    <li *ngFor=\"let view of views\">\r\n      <div>{{ view.Id }} {{ translator.tr(view.label) }}</div>\r\n      <div>\r\n        <span>Editer</span>\r\n        <span>Supprimer</span>\r\n      </div>\r\n    </li>\r\n  </ul>\r\n  <p>Créer une vue</p>\r\n  <h3>Liste des tables</h3>\r\n  <div [routerLink]=\"['model', 'add-table']\">Ajouter</div>\r\n  <ul>\r\n    <li *ngFor=\"let table of tables\">\r\n      <div>{{ table.id }} {{ translator.tr(table.label) }}</div>\r\n      <div>\r\n        <span [routerLink]=\"['model', 'edit-table', table.id]\">Editer</span>\r\n        <span>Supprimer</span>\r\n      </div>\r\n    </li>\r\n  </ul>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages/views/admin.cpn.less":
/*!*******************************************************!*\
  !*** ./src/app/components/pages/views/admin.cpn.less ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/pages/views/admin.cpn.ts":
/*!*****************************************************!*\
  !*** ./src/app/components/pages/views/admin.cpn.ts ***!
  \*****************************************************/
/*! exports provided: PagesViewAdminComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PagesViewAdminComponent", function() { return PagesViewAdminComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _view_abs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../view.abs */ "./src/app/components/pages/view.abs.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../services/state.service */ "./src/app/services/state.service.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/** Vue administrateur */
var PagesViewAdminComponent = /** @class */ (function (_super) {
    __extends(PagesViewAdminComponent, _super);
    function PagesViewAdminComponent(translator, state, router, ar) {
        var _this = _super.call(this, false, state, router, ar) || this;
        _this.translator = translator;
        _this.state = state;
        _this.router = router;
        _this.ar = ar;
        _this.ar.params.subscribe(function (params) {
            // onInit broken
            _this.state
                .getTables()
                .subscribe(function (data) {
                _this.tables = data;
            });
        });
        return _this;
    }
    PagesViewAdminComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-view-admin',
            template: __webpack_require__(/*! ./admin.cpn.html */ "./src/app/components/pages/views/admin.cpn.html"),
            styles: [__webpack_require__(/*! ./admin.cpn.less */ "./src/app/components/pages/views/admin.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_translator_service__WEBPACK_IMPORTED_MODULE_3__["TranslatorService"],
            _services_state_service__WEBPACK_IMPORTED_MODULE_4__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"]])
    ], PagesViewAdminComponent);
    return PagesViewAdminComponent;
}(_view_abs__WEBPACK_IMPORTED_MODULE_2__["PagesViewAbstractComponent"]));



/***/ }),

/***/ "./src/app/components/pages/views/admin/table.edit.cpn.html":
/*!******************************************************************!*\
  !*** ./src/app/components/pages/views/admin/table.edit.cpn.html ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Table</h2>\r\n  <div class=\"column\">\r\n    <div *ngIf=\"action == 'add-table'\">\r\n      <h3>Créer une table</h3>\r\n      <admin-table-add></admin-table-add>\r\n    </div>\r\n    <div *ngIf=\"action != 'add-table'\">\r\n      <h3 [routerLink]=\"['../../edit-table', table.id]\">Modifier une table</h3>\r\n      <div>\r\n        <h4>{{ translator.tr(table.label) }}</h4>\r\n        <p>{{ table.code }}</p>\r\n      </div>\r\n      <h3>Champs</h3>\r\n      <div>\r\n        <p>\r\n          <span [routerLink]=\"['../../add-field', table.id]\">Ajouter</span>\r\n        </p>\r\n        <admin-field-add *ngIf=\"action == 'add-field'\" [table]=\"table\"></admin-field-add>\r\n        <p *ngIf=\"table.fields.length == 0\">Aucun champ référencé</p>\r\n        <ul *ngIf=\"table.fields.length > 0\">\r\n          <li *ngFor=\"let f of table.fields\"\r\n              [routerLink]=\"['../../edit-field', f.id]\"\r\n              (click)=\"field = f\">{{ translator.translate(f.label) }} de type {{ f.configuration.type }}</li>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n  </div>\r\n  <div class=\"column\" *ngIf=\"action == 'edit-table'\">\r\n    <admin-table-edit [table]=\"table\"></admin-table-edit>\r\n  </div>\r\n  <div class=\"column\" *ngIf=\"action == 'edit-field'\">\r\n    <admin-field-edit [field]=\"field\"></admin-field-edit>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/components/pages/views/admin/table.edit.cpn.less":
/*!******************************************************************!*\
  !*** ./src/app/components/pages/views/admin/table.edit.cpn.less ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div div.column {\n  display: inline-block;\n  vertical-align: top;\n  width: 40%;\n}\ndiv div.column:last-child {\n  border-left: 1px solid black;\n  padding-left: 4px;\n}\n"

/***/ }),

/***/ "./src/app/components/pages/views/admin/table.edit.cpn.ts":
/*!****************************************************************!*\
  !*** ./src/app/components/pages/views/admin/table.edit.cpn.ts ***!
  \****************************************************************/
/*! exports provided: PagesViewAdminTableEditComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PagesViewAdminTableEditComponent", function() { return PagesViewAdminTableEditComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _view_abs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../view.abs */ "./src/app/components/pages/view.abs.ts");
/* harmony import */ var _services_translator_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../../../services/translator.service */ "./src/app/services/translator.service.ts");
/* harmony import */ var _services_state_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../../../services/state.service */ "./src/app/services/state.service.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





/** Edition d'une table */
var PagesViewAdminTableEditComponent = /** @class */ (function (_super) {
    __extends(PagesViewAdminTableEditComponent, _super);
    function PagesViewAdminTableEditComponent(state, router, ar, translator) {
        var _this = _super.call(this, false, state, router, ar) || this;
        _this.state = state;
        _this.router = router;
        _this.ar = ar;
        _this.translator = translator;
        _this.ar.params.subscribe(function (params) {
            // onInit broken
            _this.action = params["action"];
            _this.state
                .getTables()
                .subscribe(function (data) {
                switch (_this.action) {
                    case "edit-table":
                    case "add-field":
                        _this.table = data.filter(function (t) { return t.id == params["id"]; })[0];
                        _this.field = null;
                        break;
                }
            });
            _this.state
                .getFields()
                .subscribe(function (data) {
                if (_this.action == "edit-field") {
                    console.log(data);
                    console.log(params["id"]);
                    _this.field = data.filter(function (f) { return f.id == params["id"]; })[0];
                    console.log(_this.field);
                    _this.table = _this.field.table;
                }
            });
        });
        return _this;
    }
    PagesViewAdminTableEditComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'pages-view-admin-table-edit',
            template: __webpack_require__(/*! ./table.edit.cpn.html */ "./src/app/components/pages/views/admin/table.edit.cpn.html"),
            styles: [__webpack_require__(/*! ./table.edit.cpn.less */ "./src/app/components/pages/views/admin/table.edit.cpn.less")]
        }),
        __metadata("design:paramtypes", [_services_state_service__WEBPACK_IMPORTED_MODULE_4__["StateService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
            _services_translator_service__WEBPACK_IMPORTED_MODULE_3__["TranslatorService"]])
    ], PagesViewAdminTableEditComponent);
    return PagesViewAdminTableEditComponent;
}(_view_abs__WEBPACK_IMPORTED_MODULE_2__["PagesViewAbstractComponent"]));



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

/***/ "./src/app/dto/bundle.dto.ts":
/*!***********************************!*\
  !*** ./src/app/dto/bundle.dto.ts ***!
  \***********************************/
/*! exports provided: BundleDTO, BundleDataDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BundleDTO", function() { return BundleDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BundleDataDTO", function() { return BundleDataDTO; });
var BundleDTO = /** @class */ (function () {
    function BundleDTO() {
        this.data = new BundleDataDTO();
    }
    return BundleDTO;
}());

var BundleDataDTO = /** @class */ (function () {
    function BundleDataDTO() {
        this.FRA = "";
        this.ENG = "";
    }
    return BundleDataDTO;
}());



/***/ }),

/***/ "./src/app/dto/entity.dto.ts":
/*!***********************************!*\
  !*** ./src/app/dto/entity.dto.ts ***!
  \***********************************/
/*! exports provided: EntityDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EntityDTO", function() { return EntityDTO; });
var EntityDTO = /** @class */ (function () {
    function EntityDTO() {
        this.id = "00000000-0000-0000-0000-000000000000";
    }
    return EntityDTO;
}());



/***/ }),

/***/ "./src/app/dto/field.dto.ts":
/*!**********************************!*\
  !*** ./src/app/dto/field.dto.ts ***!
  \**********************************/
/*! exports provided: FieldDTO, AbstractFieldConfigurationDTO, StringFieldConfigurationDTO, BooleanFieldConfigurationDTO, NumericFieldConfigurationDTO, DateFieldConfigurationDTO, ReferenceFieldConfigurationDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FieldDTO", function() { return FieldDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AbstractFieldConfigurationDTO", function() { return AbstractFieldConfigurationDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StringFieldConfigurationDTO", function() { return StringFieldConfigurationDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BooleanFieldConfigurationDTO", function() { return BooleanFieldConfigurationDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NumericFieldConfigurationDTO", function() { return NumericFieldConfigurationDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DateFieldConfigurationDTO", function() { return DateFieldConfigurationDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReferenceFieldConfigurationDTO", function() { return ReferenceFieldConfigurationDTO; });
/* harmony import */ var _bundle_dto__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./bundle.dto */ "./src/app/dto/bundle.dto.ts");
/* harmony import */ var _table_dto__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./table.dto */ "./src/app/dto/table.dto.ts");
/* harmony import */ var _persisted_dto__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./persisted.dto */ "./src/app/dto/persisted.dto.ts");
/* harmony import */ var _entity_dto__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./entity.dto */ "./src/app/dto/entity.dto.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();




var FieldDTO = /** @class */ (function (_super) {
    __extends(FieldDTO, _super);
    function FieldDTO() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.label = new _bundle_dto__WEBPACK_IMPORTED_MODULE_0__["BundleDTO"]();
        _this.code = "";
        _this.configuration = null;
        _this.table = new _table_dto__WEBPACK_IMPORTED_MODULE_1__["TableDTO"]();
        return _this;
    }
    return FieldDTO;
}(_entity_dto__WEBPACK_IMPORTED_MODULE_3__["EntityDTO"]));

var AbstractFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(AbstractFieldConfigurationDTO, _super);
    function AbstractFieldConfigurationDTO() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.archived = true;
        return _this;
    }
    return AbstractFieldConfigurationDTO;
}(_persisted_dto__WEBPACK_IMPORTED_MODULE_2__["GenericPersistedDTO"]));

var StringFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(StringFieldConfigurationDTO, _super);
    function StringFieldConfigurationDTO() {
        return _super.call(this, "STRING") || this;
    }
    return StringFieldConfigurationDTO;
}(AbstractFieldConfigurationDTO));

var BooleanFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(BooleanFieldConfigurationDTO, _super);
    function BooleanFieldConfigurationDTO() {
        return _super.call(this, "BOOLEAN") || this;
    }
    return BooleanFieldConfigurationDTO;
}(AbstractFieldConfigurationDTO));

var NumericFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(NumericFieldConfigurationDTO, _super);
    function NumericFieldConfigurationDTO() {
        return _super.call(this, "NUMERIC") || this;
    }
    return NumericFieldConfigurationDTO;
}(AbstractFieldConfigurationDTO));

var DateFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(DateFieldConfigurationDTO, _super);
    function DateFieldConfigurationDTO() {
        return _super.call(this, "DATE") || this;
    }
    return DateFieldConfigurationDTO;
}(AbstractFieldConfigurationDTO));

var ReferenceFieldConfigurationDTO = /** @class */ (function (_super) {
    __extends(ReferenceFieldConfigurationDTO, _super);
    function ReferenceFieldConfigurationDTO() {
        return _super.call(this, "REFERENCE") || this;
    }
    return ReferenceFieldConfigurationDTO;
}(AbstractFieldConfigurationDTO));



/***/ }),

/***/ "./src/app/dto/persisted.dto.ts":
/*!**************************************!*\
  !*** ./src/app/dto/persisted.dto.ts ***!
  \**************************************/
/*! exports provided: PersistedDTO, GenericPersistedDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PersistedDTO", function() { return PersistedDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GenericPersistedDTO", function() { return GenericPersistedDTO; });
var PersistedDTO = /** @class */ (function () {
    function PersistedDTO() {
    }
    return PersistedDTO;
}());

var GenericPersistedDTO = /** @class */ (function () {
    function GenericPersistedDTO(type) {
        if (type === void 0) { type = ""; }
        this.type = type;
    }
    return GenericPersistedDTO;
}());



/***/ }),

/***/ "./src/app/dto/table.dto.ts":
/*!**********************************!*\
  !*** ./src/app/dto/table.dto.ts ***!
  \**********************************/
/*! exports provided: TableDTO, TableConfigurationDTO */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TableDTO", function() { return TableDTO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TableConfigurationDTO", function() { return TableConfigurationDTO; });
/* harmony import */ var _bundle_dto__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./bundle.dto */ "./src/app/dto/bundle.dto.ts");
/* harmony import */ var _persisted_dto__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./persisted.dto */ "./src/app/dto/persisted.dto.ts");
/* harmony import */ var _entity_dto__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./entity.dto */ "./src/app/dto/entity.dto.ts");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();



var TableDTO = /** @class */ (function (_super) {
    __extends(TableDTO, _super);
    function TableDTO() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.label = new _bundle_dto__WEBPACK_IMPORTED_MODULE_0__["BundleDTO"]();
        _this.code = "";
        _this.configuration = new TableConfigurationDTO();
        return _this;
    }
    return TableDTO;
}(_entity_dto__WEBPACK_IMPORTED_MODULE_2__["EntityDTO"]));

var TableConfigurationDTO = /** @class */ (function (_super) {
    __extends(TableConfigurationDTO, _super);
    function TableConfigurationDTO() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.archived = false;
        return _this;
    }
    return TableConfigurationDTO;
}(_persisted_dto__WEBPACK_IMPORTED_MODULE_1__["PersistedDTO"]));



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
        this.culture = "FRA";
    }
    return UserConfigurationDTO;
}());



/***/ }),

/***/ "./src/app/internals/exceptions.handler.ts":
/*!*************************************************!*\
  !*** ./src/app/internals/exceptions.handler.ts ***!
  \*************************************************/
/*! exports provided: ExceptionsHandler */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ExceptionsHandler", function() { return ExceptionsHandler; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __extends = (undefined && undefined.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var ExceptionsHandler = /** @class */ (function (_super) {
    __extends(ExceptionsHandler, _super);
    function ExceptionsHandler() {
        return _super.call(this) || this;
    }
    ExceptionsHandler.prototype.handleError = function (error) {
        console.log(error);
        alert("Ouch !");
    };
    return ExceptionsHandler;
}(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ErrorHandler"]));



/***/ }),

/***/ "./src/app/internals/exceptions.interceptor.ts":
/*!*****************************************************!*\
  !*** ./src/app/internals/exceptions.interceptor.ts ***!
  \*****************************************************/
/*! exports provided: ExceptionsInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ExceptionsInterceptor", function() { return ExceptionsInterceptor; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
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




/** Gestion de l'indicateur de chargement */
var ExceptionsInterceptor = /** @class */ (function () {
    function ExceptionsInterceptor(router) {
        this.router = router;
        this.failures = new rxjs__WEBPACK_IMPORTED_MODULE_2__["Subject"]();
    }
    ExceptionsInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        return next
            .handle(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (response, data) {
            _this.failures.next(response.error);
            return rxjs__WEBPACK_IMPORTED_MODULE_2__["Observable"].create(function (observer) {
                observer.next(response.error);
                observer.complete();
            });
        }));
    };
    ExceptionsInterceptor.prototype.getFailures = function () {
        return this.failures.asObservable();
    };
    ExceptionsInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]])
    ], ExceptionsInterceptor);
    return ExceptionsInterceptor;
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

/***/ "./src/app/internals/references.interceptor.ts":
/*!*****************************************************!*\
  !*** ./src/app/internals/references.interceptor.ts ***!
  \*****************************************************/
/*! exports provided: ReferencesInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ReferencesInterceptor", function() { return ReferencesInterceptor; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



/** Gestion de l'indicateur de chargement */
var ReferencesInterceptor = /** @class */ (function () {
    function ReferencesInterceptor() {
    }
    ReferencesInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        return next
            .handle(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_2__["map"])(function (data) {
            try {
                if (data instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpResponse"]) {
                    var typed = data;
                    var index = {};
                    if (typed.body != null) {
                        _this.register(index, typed.body);
                        _this.attach(index, typed.body);
                    }
                }
                return data;
            }
            catch (ex) {
                throw new Error("References construction failed...");
            }
        }));
    };
    /**
     * Enregistre les identifiants d'un objet et de ses enfants.
     * @param index Index.
     * @param object Objet référencé.
     */
    ReferencesInterceptor.prototype.register = function (index, object) {
        var _this = this;
        if (object["$ref"] == null) {
            // Enregistrement
            if (object["$id"] != null) {
                index[object["$id"]] = object;
            }
            // Traitement des enfants
            Object.keys(object).forEach(function (key) {
                if (typeof object[key] === "object" && object[key] != null) {
                    _this.register(index, object[key]);
                }
            });
        }
    };
    /**
     *  Rattache les références avec les instances réelles.
     *  @param index Index.
     *  @param object Objet rattaché.
     */
    ReferencesInterceptor.prototype.attach = function (index, object) {
        var _this = this;
        if (object["$ref"] == null) {
            // Traitement des enfants
            Object.keys(object).forEach(function (key) {
                if (typeof object[key] === "object" && object[key] != null) {
                    var buffer = _this.attach(index, object[key]);
                    if (buffer != null) {
                        object[key] = buffer;
                    }
                }
            });
            return null;
        }
        else {
            return index[object["$ref"]];
        }
    };
    ReferencesInterceptor = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        })
    ], ReferencesInterceptor);
    return ReferencesInterceptor;
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
        this.viewsState = [];
        this.tables = new rxjs__WEBPACK_IMPORTED_MODULE_2__["BehaviorSubject"]([]);
        this.tablesState = [];
    }
    /** Retourne la liste des vues */
    StateService.prototype.getViews = function () {
        return this.views.asObservable();
    };
    /** Retourne la liste des tables */
    StateService.prototype.getTables = function () {
        return this.tables.asObservable();
    };
    /** Retourne la liste des champs */
    StateService.prototype.getFields = function () {
        return this.tables
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (data) {
            var result = [];
            for (var _i = 0, data_1 = data; _i < data_1.length; _i++) {
                var table = data_1[_i];
                for (var _a = 0, _b = table.fields; _a < _b.length; _a++) {
                    var field = _b[_a];
                    result.push(field);
                }
            }
            return result;
        }));
    };
    /**
     * Publie la liste des tables.
     * @param tables Tables publiées.
     */
    StateService.prototype.publishTables = function (tables) {
        this.tables.next(tables);
    };
    /**
     * Publie (ajout ou mise à jour) une table unitaire.
     * @param table Table publiée.
     */
    StateService.prototype.publishTable = function (table) {
        var pre = this.tablesState.filter(function (e) { return e.id == table.id; });
        if (pre.length == 0) {
            this.tablesState.push(table);
        }
        else {
            var idx = this.tablesState.indexOf(pre[0]);
            this.tablesState[idx] = table;
        }
        this.tables.next(this.tablesState);
    };
    /**
     * Publie (ajout ou mise à jour) un champ unitaire.
     *  @param field Champ publié.
     */
    StateService.prototype.publishField = function (field) {
        if (field.table == null) {
            throw new Error("Field has to be attached to a table in order to be published");
        }
        var table = this.tablesState.filter(function (e) { return e.id == field.table.id; })[0];
        var pre = table.fields.filter(function (e) { return e.id == field.id; });
        if (pre.length == 0) {
            table.fields.push(field);
            console.log("push");
        }
        else {
            var idx = table.fields.indexOf(pre[0]);
            console.log(idx);
            table.fields[idx] = field;
            console.log("flipflop");
            console.log(this.tablesState);
        }
        this.tables.next(this.tablesState);
    };
    /** Charge l'état complet de l'application */
    StateService.prototype.loadState = function () {
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["forkJoin"])(this.loadViews(), this.loadTables());
    };
    /** Recharge les vues */
    StateService.prototype.loadViews = function () {
        var _this = this;
        return this.http
            .get("views/list")
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (data) {
            _this.viewsState = data;
            _this.views.next(data);
            return data;
        }));
    };
    /** Recharge les tables */
    StateService.prototype.loadTables = function () {
        var _this = this;
        return this.http
            .get("tables/list")
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (data) {
            _this.tablesState = data;
            _this.tables.next(data);
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
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _authentication_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./authentication.service */ "./src/app/services/authentication.service.ts");
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
            _this.lang = data.user.configuration.culture;
        });
    }
    /** Retourne la langue de l'utilisateur */
    TranslatorService.prototype.getLang = function () {
        return this.authentication
            .getCredentials()
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_1__["map"])(function (data) {
            return data.user.configuration.culture;
        }));
    };
    /**
     * Retourne la traduction appropriée pour un lot de traductions.
     * @param bundle Lot de traductions
     */
    TranslatorService.prototype.translate = function (bundle) {
        return bundle.data[this.lang] ? bundle.data[this.lang] : "?";
    };
    TranslatorService.prototype.tr = function (bundle) {
        return this.translate(bundle);
    };
    /**
     * Modifie la valeur d'un lot de traductions correspondant à la culture de
     * l'utilisateur courant.
     * @param bundle Lot de traductions.
     * @param value Valeur affectée.
     */
    TranslatorService.prototype.edit = function (bundle, value) {
        bundle.data[this.lang] = value;
        return bundle;
    };
    TranslatorService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_authentication_service__WEBPACK_IMPORTED_MODULE_2__["AuthenticationService"]])
    ], TranslatorService);
    return TranslatorService;
}());



/***/ }),

/***/ "./src/app/services/validators.service.ts":
/*!************************************************!*\
  !*** ./src/app/services/validators.service.ts ***!
  \************************************************/
/*! exports provided: ValidatorsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValidatorsService", function() { return ValidatorsService; });
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




/** Services de validation */
var ValidatorsService = /** @class */ (function () {
    function ValidatorsService(http) {
        this.http = http;
    }
    /**
     * Fonction de validation d'une valeur via un service retournant un
     * booléen.
     * @param prefix Préfixe de l'URL appelée (concaténée avec la valeur).
     */
    ValidatorsService.prototype.check = function (prefix) {
        var _this = this;
        return function (control) {
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["timer"])(200)
                .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["switchMap"])(function (data) {
                return _this.http
                    .get(prefix + control.value)
                    .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (data) {
                    return data ? null : ["Check failed"];
                }));
            }));
        };
    };
    ValidatorsService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], ValidatorsService);
    return ValidatorsService;
}());



/***/ }),

/***/ "./src/app/utils/string.utils.ts":
/*!***************************************!*\
  !*** ./src/app/utils/string.utils.ts ***!
  \***************************************/
/*! exports provided: StringUtils */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "StringUtils", function() { return StringUtils; });
var StringUtils = /** @class */ (function () {
    function StringUtils() {
    }
    /**
     * Retraite une chaîne de caractère pour en faire un code pseudo-SQL correct.
     * @param value Valeur traitée.
     */
    StringUtils.StringToCode = function (value) {
        return value
            .replace(new RegExp("[^a-zA-Z0-9]+", "g"), "_")
            .toLowerCase();
    };
    return StringUtils;
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
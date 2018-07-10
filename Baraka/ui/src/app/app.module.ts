import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router"

import { LayoutPopinComponent } from './components/layout/popin.cpn';
import { LayoutRootComponent } from './components/layout/root.cpn';
import { PageHomeComponent } from './components/pages/home.cpn';
import { PageLoginComponent } from './components/pages/login.cpn';
import { PageViewComponent } from './components/pages/view.cpn';
import { PagesViewAdminComponent } from './components/pages/views/admin.cpn';
import { LoaderInterceptor } from './internals/loader.interceptor';
import { ExceptionsInterceptor } from './internals/exceptions.interceptor';
import { RootInterceptor } from './internals/root.interceptor';
import { TokenInterceptor } from './internals/token.interceptor';
import { ReferencesInterceptor } from './internals/references.interceptor';
import { PagesViewAdminTableEditComponent } from './components/pages/views/admin/table.edit.cpn';
import { AdminTableEditFormular } from './components/formulars/admin/tables/table.edit.form';

@NgModule({
  declarations: [
    AdminTableEditFormular,
    LayoutPopinComponent,
    LayoutRootComponent,
    PageHomeComponent,
    PageLoginComponent,
    PageViewComponent,
    PagesViewAdminComponent,
    PagesViewAdminTableEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'home', component: PageHomeComponent },
      { path: 'login', component: PageLoginComponent },
      { path: 'view/:view', component: PageViewComponent },
      { path: 'view/:view/admin', component: PagesViewAdminComponent },
      { path: 'view/:view/admin/tables/add', component: PagesViewAdminTableEditComponent },
      { path: 'view/:view/admin/tables/edit/:table', component: PagesViewAdminTableEditComponent },
      { path: '', redirectTo: '/home', pathMatch: 'full' }
    ])
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useExisting: LoaderInterceptor, /* useExisting pour utiliser une instance de service existante */
    multi: true
  }, {
    provide: HTTP_INTERCEPTORS,
    useExisting: ExceptionsInterceptor, /* useExisting pour utiliser une instance de service existante */
    multi: true
  }, {
    provide: HTTP_INTERCEPTORS,
    useClass: RootInterceptor,
    multi: true
  }, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }, {
    provide: HTTP_INTERCEPTORS,
    useClass: ReferencesInterceptor,
    multi: true
  }],
  bootstrap: [LayoutRootComponent]
})
export class AppModule { }

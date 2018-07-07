import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router"

import { LayoutRootComponent } from './components/layout.root.cpn';
import { PageLoginComponent } from './components/pages.login.cpn';

import { AuthenticationService } from './services/authentication.service'
import { TokenInterceptor } from './internals/token.interceptor';
import { PageHomeComponent } from './components/pages.home.cpn';
import { RootInterceptor } from './internals/root.interceptor';
import { LoaderInterceptor } from './internals/loader.interceptor';
import { PageViewComponent } from './components/pages.view.cpn';
import { ExceptionsInterceptor } from './internals/exceptions.interceptor';
import { LayoutPopinComponent } from './components/layout.popin.cpn';

@NgModule({
  declarations: [
    LayoutPopinComponent,
    LayoutRootComponent,
    PageHomeComponent,
    PageLoginComponent,
    PageViewComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'home', component: PageHomeComponent },
      { path: 'login', component: PageLoginComponent },
      { path: 'view/:id', component: PageViewComponent },
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
  }],
  bootstrap: [LayoutRootComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router"

import { LayoutRootComponent } from './components/layout.root.cpn';
import { PageLoginComponent } from './components/pages.login.cpn';

import { AuthenticationService } from './services/authentication.service'
import { TokenInterceptor } from './internals/headers.interceptor';
import { PageHomeComponent } from './components/pages.home.cpn';
import { RootInterceptor } from './internals/root.interceptor';
import { LoaderInterceptor } from './internals/loader.interceptor';

@NgModule({
  declarations: [
    LayoutRootComponent,
    PageHomeComponent,
    PageLoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'home', component: PageHomeComponent },
      { path: 'login', component: PageLoginComponent },
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: '**', component: PageLoginComponent }
    ])
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useExisting: LoaderInterceptor, /* useExisting pour utiliser une instance de service existante */
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

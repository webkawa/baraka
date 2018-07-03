import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";

import { AuthenticationService } from "../services/authentication.service";
import { AuthenticationSessionDTO } from "../dto/authentication.session.dto";
import { map } from "rxjs/operators";

/** Gestion du jeton */
@Injectable({
  providedIn: 'root'
})
export class TokenInterceptor implements HttpInterceptor {

  private credentials: AuthenticationSessionDTO;

  public constructor(private authentication: AuthenticationService) {
    this.authentication
      .getCredentials()
      .subscribe((data) => {
        this.credentials = data;
      });
  }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.credentials.connected) {
      const modified = request.clone({
        setHeaders: {
          'token': this.credentials.token
        }
      });
      return next.handle(modified);
    } else {
      return next.handle(request);
    }
  }

}

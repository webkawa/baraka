import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { Observable } from "rxjs";

import { AuthenticationService } from "../services/authentication.service";
import { AuthenticationSessionDTO } from "../dto/authentication.session.dto";

/* Redirection des requêtes sortantes vers "/services/.." */
@Injectable({
  providedIn: 'root'
})
export class RootInterceptor implements HttpInterceptor {

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const event = request.clone({
      url: "services/" + request.url
    });
    return next.handle(event);
  }

}

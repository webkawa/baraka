import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, Subject, BehaviorSubject, observable } from "rxjs";

import { AuthenticationService } from "../services/authentication.service";
import { AuthenticationSessionDTO } from "../dto/authentication.session.dto";
import { ErrorDTO } from "../dto/error.dto";

import { map } from "rxjs/operators";
import { catchError } from "rxjs/operators";

/** Gestion de l'indicateur de chargement */
@Injectable({
  providedIn: 'root'
})
export class ExceptionsInterceptor implements HttpInterceptor {

  private failures: Subject<ErrorDTO>;

  public constructor(
    private router: Router) {
    this.failures = new Subject()
  }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next
      .handle(request)
      .pipe(catchError((response: HttpErrorResponse, data: Observable<ErrorDTO>) => {
        this.failures.next(response.error);
        return Observable.create((observer) => {
          observer.next(response.error);
          observer.complete();
        });
      }));
  }

  public getFailures(): Observable<ErrorDTO> {
    return this.failures.asObservable();
  }
}

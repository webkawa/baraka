import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { Observable, Subject, BehaviorSubject } from "rxjs";

import { AuthenticationService } from "../services/authentication.service";
import { AuthenticationSessionDTO } from "../dto/authentication.session.dto";

import { map } from "rxjs/operators";

/** Gestion de l'indicateur de chargement */
@Injectable({
  providedIn: 'root'
})
export class LoaderInterceptor implements HttpInterceptor {

  private count: number;
  private loader: Subject<boolean>;

  public constructor() {
    this.count = 0;
    this.loader = new BehaviorSubject(false);
  }

  /** Retourne le statut courant du chargement */
  public getLoader(): Observable<boolean> {
    return this.loader.asObservable();
  }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next
      .handle(request)
      .pipe(map((data) => {
        console.log(data);
        if (data.type == 0) {
          /* Dafuq */
          this.count++;
          if (this.count == 1) {
            this.loader.next(true);
          }
        } else {
          this.count--;
          if (this.count == 0) {
            this.loader.next(false);
          }
        }
        return data;
      }));
  }

}

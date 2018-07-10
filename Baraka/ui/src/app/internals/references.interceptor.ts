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
export class ReferencesInterceptor implements HttpInterceptor {

  private index: {};

  public constructor() {
    this.index = {};
  }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next
      .handle(request)
      .pipe(map((data) => {
        if (data instanceof HttpResponse) {
          let typed = <HttpResponse<any>>data;
          if (typed.body != null) {
            this.register(typed.body);
            this.attach(typed.body);
            this.index = {};
          }
        }
        return data;
      }));
  }

  /**
   * Enregistre les identifiants d'un objet et de ses enfants.
   * @param object Objet référencé.
   */
  private register(object: any): void {
    if (object["$ref"] == null) {
      if (this.index[object["$id"]] == null) {
        // Enregistrement
        this.index[object.$id] = object;
      }

      // Traitement des enfants
      Object.keys(object).forEach((key) => {
        if (typeof object[key] === "object") {
          this.register(object[key]);
        }
      });
    }
  }

  /**
   *  Rattache les références avec les instances réelles.
   *  @param object Objet rattaché.
   */
  private attach(object: any): any {
    if (object["$ref"] == null) {
      // Traitement des enfants
      Object.keys(object).forEach((key) => {
        if (typeof object[key] === "object") {
          let buffer = this.attach(object[key]);
          if (buffer != null) {
            object[key] = buffer;
          }
        }
      });
      return null;
    } else {
      return this.index[object["$ref"]];
    }
  }
}

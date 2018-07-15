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


  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next
      .handle(request)
      .pipe(map((data) => {
        try {
          if (data instanceof HttpResponse) {
            let typed = <HttpResponse<any>>data;
            let index = {};
            if (typed.body != null) {
              this.register(index, typed.body);
              this.attach(index, typed.body);
            }
          }
          return data;
        } catch (ex) {
          throw new Error("References construction failed...");
        }
      }));
  }

  /**
   * Enregistre les identifiants d'un objet et de ses enfants.
   * @param index Index.
   * @param object Objet référencé.
   */
  private register(index: any, object: any): void {
    if (object["$ref"] == null) {
      // Enregistrement
      if (object["$id"] != null) {
        index[object["$id"]] = object;
      }

      // Traitement des enfants
      Object.keys(object).forEach((key) => {
        if (typeof object[key] === "object" && object[key] != null) {
          this.register(index, object[key]);
        }
      });
    }
  }

  /**
   *  Rattache les références avec les instances réelles.
   *  @param index Index.
   *  @param object Objet rattaché.
   */
  private attach(index: any, object: any): any {
    if (object["$ref"] == null) {
      // Traitement des enfants
      Object.keys(object).forEach((key) => {
        if (typeof object[key] === "object" && object[key] != null) {
          let buffer = this.attach(index, object[key]);
          if (buffer != null) {
            object[key] = buffer;
          }
        }
      });
      return null;
    } else {
      return index[object["$ref"]];
    }
  }
}

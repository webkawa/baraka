import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AsyncValidatorFn, AbstractControl, ValidationErrors } from "@angular/forms";

import { Observable, timer, from, Subject } from "rxjs";
import { debounce, distinctUntilChanged, map, delay, switchMap, combineLatest, first } from "rxjs/operators";

/** Services de validation */
@Injectable({
  providedIn: 'root'
})
export class ValidatorsService {

  public constructor(
    private http: HttpClient) {
  }

  /**
   * Fonction de validation d'une valeur via un service retournant un
   * booléen.
   * @param prefix Préfixe de l'URL appelée (concaténée avec la valeur).
   * @param init Valeur initiale.
   */
  public check(prefix: string, init: string = null): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return timer(500)
        .pipe(switchMap((data) => {
          if (init != null && control.value == init) {
            return Observable.create(null);
          } else {
            return this.http
              .get<boolean>(prefix + control.value)
              .pipe(map((data) => {
                return data ? null : ["Check failed"];
              }));
          }
        }));
    };
  }
}

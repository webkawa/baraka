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
      try {

        if (init != null && control.value == init) {
          console.log("go through !");
          return from([null]);
        } else {
          return timer(250)
            .pipe(switchMap((data) => {
              return this.http
                .get<boolean>(prefix + control.value)
                .pipe(map((data) => {
                  return data ? null : ["Check failed"];
                }));
            }));
        }
      }
      catch (ex) {
        throw new Error("Error validating code...");
      }
    };
  }
}

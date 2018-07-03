import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, forkJoin, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'


import { ViewDTO } from '../dto/view.dto';


/** Service d'état */
@Injectable({
  providedIn: 'root'
})
export class StateService {
  
  private views: Subject<ViewDTO[]>

  constructor(
    public http: HttpClient) {
    this.views = new BehaviorSubject([]);
  }

  /** Retourne la liste des vues */
  public getViews(): Observable<ViewDTO[]> {
    return this.views.asObservable();
  }

  /** Charge l'état complet de l'application */
  public loadState(): Observable<any> {
    return forkJoin(this.loadViews());
  }

  /** Recharge les vues */
  public loadViews(): Observable<ViewDTO[]> {
    return this.http
      .get<ViewDTO[]>("views/get")
      .pipe(map((data) => {
        this.views.next(data);
        return data;
      }));
  }
}

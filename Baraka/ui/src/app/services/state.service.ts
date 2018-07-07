import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, forkJoin, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'


import { ViewDTO } from '../dto/view.dto';
import { TableDTO } from '../dto/table.dto';


/** Service d'état */
@Injectable({
  providedIn: 'root'
})
export class StateService {
  
  private views: Subject<ViewDTO[]>
  private tables: Subject<TableDTO[]>

  constructor(
    public http: HttpClient) {
    this.views = new BehaviorSubject([]);
    this.tables = new BehaviorSubject([]);
  }

  /** Retourne la liste des vues */
  public getViews(): Observable<ViewDTO[]> {
    return this.views.asObservable();
  }

  /** Retourne la liste des tables */
  public getTables(): Observable<TableDTO[]> {
    return this.tables.asObservable();
  }

  /** Charge l'état complet de l'application */
  public loadState(): Observable<any> {
    return forkJoin(
      this.loadViews(),
      this.loadTables());
  }

  /** Recharge les vues */
  public loadViews(): Observable<ViewDTO[]> {
    return this.http
      .get<ViewDTO[]>("views/list")
      .pipe(map((data) => {
        this.views.next(data);
        return data;
      }));
  }

  /** Recharge les tables */
  public loadTables(): Observable<TableDTO[]> {
    return this.http
      .get<TableDTO[]>("tables/list")
      .pipe(map((data) => {
        this.tables.next(data);
        return data;
      }));
  }
}

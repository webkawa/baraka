import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, forkJoin, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'

import { ViewDTO, AbstractViewConfigurationDTO } from '../dto/view.dto';
import { TableDTO } from '../dto/table.dto';
import { FieldDTO } from '../dto/field.dto';

/** Service d'état */
@Injectable({
  providedIn: 'root'
})
export class StateService {

  private views: Subject<ViewDTO<AbstractViewConfigurationDTO>[]>
  private viewsState: ViewDTO<AbstractViewConfigurationDTO>[];
  private tables: Subject<TableDTO[]>
  private tablesState: TableDTO[];

  constructor(
    public http: HttpClient) {

    this.views = new BehaviorSubject([]);
    this.viewsState = [];
    this.tables = new BehaviorSubject([]);
    this.tablesState = [];
  }

  /** Retourne la liste des vues */
  public getViews(): Observable<ViewDTO<AbstractViewConfigurationDTO>[]> {
    return this.views.asObservable();
  }

  /** Retourne la liste des tables */
  public getTables(): Observable<TableDTO[]> {
    return this.tables.asObservable();
  }

  /** Retourne la liste des champs */
  public getFields(): Observable<FieldDTO[]> {
    return this.tables
      .pipe(map((data) => {
        let result: FieldDTO[] = [];
        for (let table of data) {
          for (let field of table.fields) {
            result.push(field);
          }
        }
        return result;
      }));
  }

  /**
   * Publie la liste des tables.
   * @param tables Tables publiées.
   */
  public publishTables(tables: TableDTO[]): void {
    this.tables.next(tables);
  }

  /**
   * Publie (ajout ou mise à jour) une table unitaire.
   * @param table Table publiée.
   */
  public publishTable(table: TableDTO): void {
    let pre = this.tablesState.filter(e => e.id == table.id);
    if (pre.length == 0) {
      this.tablesState.push(table);
    } else {
      let idx = this.tablesState.indexOf(pre[0]);
      this.tablesState[idx] = table;
    }
    this.tables.next(this.tablesState);
  }

  /** Charge l'état complet de l'application */
  public loadState(): Observable<any> {
    return forkJoin(
      this.loadViews(),
      this.loadTables());
  }

  /** Recharge les vues */
  public loadViews(): Observable<ViewDTO<AbstractViewConfigurationDTO>[]> {
    return this.http
      .get<ViewDTO<AbstractViewConfigurationDTO>[]>("views/list")
      .pipe(map((data) => {
        this.viewsState = data;
        this.views.next(data);
        return data;
      }));
  }

  /** Recharge les tables */
  public loadTables(): Observable<TableDTO[]> {
    return this.http
      .get<TableDTO[]>("tables/list")
      .pipe(map((data) => {
        this.tablesState = data;
        this.tables.next(data);
        return data;
      }));
  }
}

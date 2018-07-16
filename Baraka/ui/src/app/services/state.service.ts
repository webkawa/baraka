import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, forkJoin, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'

import { ViewDTO, AbstractViewConfigurationDTO } from '../dto/view.dto';
import { TableDTO } from '../dto/table.dto';
import { FieldDTO, AbstractFieldConfigurationDTO } from '../dto/field.dto';

/** Service d'état */
@Injectable({
  providedIn: 'root'
})
export class StateService {

  private viewsSubject: Subject<ViewDTO<AbstractViewConfigurationDTO>[]>
  private viewsState: ViewDTO<AbstractViewConfigurationDTO>[];
  private tablesSubject: Subject<TableDTO[]>
  private tablesState: TableDTO[];

  constructor(
    public http: HttpClient) {

    this.viewsSubject = new BehaviorSubject([]);
    this.viewsState = [];
    this.tablesSubject = new BehaviorSubject([]);
    this.tablesState = [];
  }

  /** Retourne la liste des vues */
  public getViews(): Observable<ViewDTO<AbstractViewConfigurationDTO>[]> {
    return this.viewsSubject.asObservable();
  }

  /** Retourne la liste des tables */
  public getTables(): Observable<TableDTO[]> {
    return this.tablesSubject.asObservable();
  }

  /** Retourne la liste des champs */
  public getFields(): Observable<FieldDTO<AbstractFieldConfigurationDTO>[]> {
    return this.tablesSubject
      .pipe(map((data) => {
        let result: FieldDTO<AbstractFieldConfigurationDTO>[] = [];
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
    this.tablesSubject.next(tables);
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
    this.tablesSubject.next(this.tablesState);
  }

  /**
   * Publie (ajout ou mise à jour) un champ unitaire.
   *  @param field Champ publié.
   */
  public publishField(field: FieldDTO<AbstractFieldConfigurationDTO>) {
    if (field.table == null) {
      throw new Error("Field has to be attached to a table in order to be published");
    }

    var table = this.tablesState.filter(e => e.id == field.table.id)[0];
    var pre = table.fields.filter(e => e.id == field.id);

    if (pre.length == 0) {
      table.fields.push(field);
    } else {
      let idx = table.fields.indexOf(pre[0]);
      table.fields[idx] = field;
    }
    this.tablesSubject.next(this.tablesState);
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
        this.viewsSubject.next(data);
        return data;
      }));
  }

  /** Recharge les tables */
  public loadTables(): Observable<TableDTO[]> {
    return this.http
      .get<TableDTO[]>("tables/list")
      .pipe(map((data) => {
        this.tablesState = data;
        this.tablesSubject.next(data);
        return data;
      }));
  }
}

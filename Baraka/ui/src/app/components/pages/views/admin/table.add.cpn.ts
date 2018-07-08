import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { PagesViewAbstractComponent } from '../../view.abs';
import { AdminViewDTO } from '../../../../dto/view.dto';
import { TableDTO } from '../../../../dto/table.dto';
import { TranslatorService } from '../../../../services/translator.service';
import { StateService } from '../../../../services/state.service';

/** Ajout d'une table */
@Component({
  selector: 'pages-view-admin-table-add',
  templateUrl: './table.add.cpn.html',
  styleUrls: ['./table.add.cpn.less']
})
export class PagesViewAdminTableAddComponent extends PagesViewAbstractComponent<AdminViewDTO> {

  public table: TableDTO;
  public lang: string;
  public loading: boolean;

  public constructor(
    public translator: TranslatorService,
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute,
    private http: HttpClient) {

    super(false, state, router, ar);
    this.table = new TableDTO();
    this.loading = false;

    ar.params.subscribe((params) => {
      // onInit broken
      this.translator
        .getLang()
        .subscribe((data) => {
          console.log(data);
          this.lang = data;
        });
    });
  }

  /** Ajout */
  public add(): void {
    this.loading = true;
    this.http
      .post<TableDTO[]>("tables/add", this.table)
      .subscribe((data) => {
        this.loading = false;
        this.state.publishTables(data);
        this.router.navigate(["/view", this.view.id]);
      });
  }

}

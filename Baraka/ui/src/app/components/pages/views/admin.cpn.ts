import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { PagesViewAbstractComponent } from '../view.abs';
import { AdminViewConfigurationDTO } from '../../../dto/view.dto';
import { TableDTO } from '../../../dto/table.dto';
import { TranslatorService } from '../../../services/translator.service';
import { StateService } from '../../../services/state.service';

/** Vue administrateur */
@Component({
  selector: 'pages-view-admin',
  templateUrl: './admin.cpn.html',
  styleUrls: ['./admin.cpn.less']
})
export class PagesViewAdminComponent extends PagesViewAbstractComponent<AdminViewConfigurationDTO> {

  public tables: TableDTO[];

  public constructor(
    public translator: TranslatorService,
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute) {

    super(false, state, router, ar);

    // onInit broken
    this.state
      .getTables()
      .subscribe((data) => {
        this.tables = data;
      });
  }

}

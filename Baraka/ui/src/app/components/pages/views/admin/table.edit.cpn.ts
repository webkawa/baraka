import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder, AsyncValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { PagesViewAbstractComponent } from '../../view.abs';
import { AdminViewConfigurationDTO } from '../../../../dto/view.dto';
import { TableDTO } from '../../../../dto/table.dto';
import { TranslatorService } from '../../../../services/translator.service';
import { StateService } from '../../../../services/state.service';
import { BundleDTO } from '../../../../dto/bundle.dto';
import { StringUtils } from '../../../../utils/string.utils';
import { ValidatorsService } from '../../../../services/validators.service';
import { FieldDTO } from '../../../../dto/field.dto';

/** Edition d'une table */
@Component({
  selector: 'pages-view-admin-table-edit',
  templateUrl: './table.edit.cpn.html',
  styleUrls: ['./table.edit.cpn.less']
})
export class PagesViewAdminTableEditComponent extends PagesViewAbstractComponent<AdminViewConfigurationDTO> {

  public action: string;
  public table: TableDTO;
  public field: FieldDTO;
  
  public constructor(
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute,
    private translator: TranslatorService) {

    super(false, state, router, ar);
    
    this.ar.params.subscribe((params) => {
      // onInit broken
      this.action = params["action"];

      this.state
        .getTables()
        .subscribe((data) => {
          switch (this.action) {
            case "edit-table":
            case "add-field":
              this.table = data.filter((t) => t.id == params["id"])[0];
              this.field = null;
              break;
          }
        });

      this.state
        .getFields()
        .subscribe((data) => {
          if (this.action == "edit-field") {
            this.field = data.filter((f) => f.id == params["id"])[0];
            this.table = this.field.table;
          }
        });
    });
  }
}

import { Component, OnInit, Inject, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder, AsyncValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ValidatorsService } from '../../../../services/validators.service';
import { StringUtils } from '../../../../utils/string.utils';
import { TableDTO } from '../../../../dto/table.dto';
import { TranslatorService } from '../../../../services/translator.service';
import { StateService } from '../../../../services/state.service';
import { AdminEditAbstractFormular } from '../edit.abs';
import { ViewDTO, AdminViewDTO } from '../../../../dto/view.dto';

/** Formulaire d'ajout ou de modification simple d'une table */
@Component({
  selector: 'admin-table-edit',
  templateUrl: './table.edit.form.html',
  styleUrls: ['./table.edit.form.less']
})
export class AdminTableEditFormular extends AdminEditAbstractFormular<TableDTO> implements OnInit {

  @Input()
  public view: ViewDTO<AdminViewDTO>;
  public tables: TableDTO[];

  public lang: string;

  public form: FormGroup;
  public name: FormControl;
  public code: FormControl;

  public constructor(
    public translator: TranslatorService,
    protected http: HttpClient,
    private state: StateService,
    private router: Router,
    private validators: ValidatorsService) {

    super(http, "tables");
  }

  public ngOnInit(): void {
    /* Création du formulaire */
    this.name = new FormControl('', [
      Validators.required,
      Validators.minLength(3)]);
    this.code = new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[a-z0-9_]+$/)
    ], [this.validators.check("tables/check-code?code=")]);
    this.form = new FormGroup({
      name: this.name,
      code: this.code
    });

    /* Instanciation */
    super.ngOnInit();

    /* Gestion du code */
    this.name
      .valueChanges
      .subscribe((data) => {
        if (!this.persisted && this.code.pristine) {
          let treated = StringUtils.StringToCode(this.name.value);
          this.code.setValue(treated);
        }
      });

    /* Gestion des tables */
    this.state
      .getTables()
      .subscribe((data) => this.tables = data);
  }

  protected init(): TableDTO {
    if (this.persisted) {
      this.name.setValue(this.translator.tr(this.entity.label));
      this.code.setValue(this.entity.code);
    }
    return new TableDTO();
  }

  protected pre(): boolean {
    if (this.form.valid) {
      this.entity.code = this.code.value;
      this.entity.label = this.translator.getNewBundle(this.name.value);
      return true;
    }
    return false;
  }

  protected postAdd(): void {
    this.tables.push(this.entity);
    this.router.navigate(["/view", this.view.id, "admin", "tables", "edit", this.entity.id]);
  }

  protected postSave(): void {
  }

  protected postAll(): void {
    this.state.publishTables(this.tables);
  }
}

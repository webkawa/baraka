import { Component, OnInit, Inject, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder, AsyncValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ValidatorsService } from '../../../../services/validators.service';
import { StringUtils } from '../../../../utils/string.utils';
import { TableDTO, TableConfigurationDTO } from '../../../../dto/table.dto';
import { TranslatorService } from '../../../../services/translator.service';
import { StateService } from '../../../../services/state.service';
import { ViewDTO, AdminViewConfigurationDTO } from '../../../../dto/view.dto';
import { PersitedAbstractFormular } from '../../persisted.abs';

/** Formulaire d'ajout d'une table */
@Component({
  selector: 'admin-table-add',
  templateUrl: './table.add.form.html',
  styleUrls: ['./table.add.form.less']
})
export class AdminTableAddFormular extends PersitedAbstractFormular<TableDTO> implements OnInit {

  @Input()
  public view: ViewDTO<AdminViewConfigurationDTO>;

  public lang: string;

  public form: FormGroup;
  public label: FormControl;
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
    this.label = new FormControl('', [
      Validators.required,
      Validators.minLength(3)]);
    this.code = new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[a-z0-9_]+$/)
    ], [this.validators.check("tables/check-code?code=")]);
    this.form = new FormGroup({
      label: this.label,
      code: this.code
    });

    /* Gestion du code */
    this.label
      .valueChanges
      .subscribe((data) => {
        if (!this.persisted && this.code.pristine) {
          let treated = StringUtils.StringToCode(this.label.value);
          this.code.setValue(treated);
        }
      });

    /* Instanciation */
    super.ngOnInit();
  }

  protected check(): boolean {
    return this.form.valid;
  }

  protected provide(): TableDTO {
    let result = this.persisted ? this.entity : new TableDTO();
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    result.configuration = new TableConfigurationDTO();
    return result;
  }

  protected digest(): void {
    this.label.setValue(this.translator.tr(this.entity.label));
    this.code.setValue(this.code.value);
  }

  protected postAdd(): void {
    this.state.publishTable(this.entity);
    this.router.navigate(["/view", this.view.id, "admin", "model", "edit-table", this.entity.id]);
  }

  /*









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
  }*/
}
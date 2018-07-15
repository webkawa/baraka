import { Component, OnInit, Inject, Input, OnChanges } from '@angular/core';
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
import { FieldDTO, AbstractFieldConfigurationDTO } from '../../../../dto/field.dto';

/** Formulaire d'ajout d'une table */
@Component({
  selector: 'admin-field-edit',
  templateUrl: './field.edit.form.html',
  styleUrls: ['./field.edit.form.less']
})
export class AdminFieldEditFormular extends PersitedAbstractFormular<FieldDTO<AbstractFieldConfigurationDTO>> implements OnInit {

  @Input()
  public set field(field: FieldDTO<AbstractFieldConfigurationDTO>) {
    this._field = field;
    if (this.form != null && this.field != null) {
      this.refresh();
    }
  };
  public get field(): FieldDTO<AbstractFieldConfigurationDTO> {
    return this._field;
  };
  public table: TableDTO;

  public tables: TableDTO[];
  public lang: string;

  public form: FormGroup;
  public label: FormControl;
  public code: FormControl;
  public archived: FormControl;
  public reference: FormControl;

  private _field: FieldDTO<AbstractFieldConfigurationDTO>;

  public constructor(
    public translator: TranslatorService,
    protected http: HttpClient,
    private state: StateService,
    private router: Router,
    private ar: ActivatedRoute,
    private validators: ValidatorsService) {

    super(http, "fields");
  }

  public ngOnInit(): void {
    /* Gestion des références */
    this.table = this.field.table;

    /* Création du formulaire */
    this.label = new FormControl(this.translator.tr(this.field.label), [
      Validators.required,
      Validators.minLength(3)]);
    this.code = new FormControl(this.field.code, [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[a-z0-9_]+$/)
    ], [this.validators.check("fields/check-code?table=" + this.table.id + "&code=")]);
    this.archived = new FormControl(this.field.configuration.archived, []);
    this.reference = new FormControl('', []);
    this.form = new FormGroup({
      label: this.label,
      code: this.code,
      archived: this.archived,
      reference: this.reference
    });

    /* Surveillance des tables */
    this.state
      .getTables()
      .subscribe((data) => this.tables = data);
  }

  protected check(): boolean {
    return this.form.valid;
  }

  protected provide(): FieldDTO<AbstractFieldConfigurationDTO> {
    let result = new FieldDTO();
    result.id = this.field.id;
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    result.configuration = this.field.configuration;
    result.configuration.archived = this.archived.value;
    result.table.id = this.table.id;
    return result;
  }

  protected digest(entity: FieldDTO<AbstractFieldConfigurationDTO>): void {
    entity.table = this.table;
    this.state.publishField(entity);
  }

  /** Rafraichit le contenu du formulaire. */
  private refresh(): void {
    if (this.form != null && this.field != null) {
      this.label.setValue(this.translator.tr(this.field.label));
      this.code.setValue(this.field.code);
      this.archived.setValue(this.field.configuration.archived);
    }
  }
}

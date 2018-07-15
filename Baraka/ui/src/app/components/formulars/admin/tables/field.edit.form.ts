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
import { FieldDTO, AbstractFieldConfigurationDTO } from '../../../../dto/field.dto';

/** Formulaire d'ajout d'une table */
@Component({
  selector: 'admin-field-edit',
  templateUrl: './field.edit.form.html',
  styleUrls: ['./field.edit.form.less']
})
export class AdminFieldEditFormular extends PersitedAbstractFormular<FieldDTO<AbstractFieldConfigurationDTO>> implements OnInit {

  public table: TableDTO;
  public tables: TableDTO[];
  public lang: string;

  public form: FormGroup;
  public label: FormControl;
  public code: FormControl;
  public archived: FormControl;
  public reference: FormControl;

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
    this.table = this.entity.table;

    /* Création du formulaire */
    this.label = new FormControl('', [
      Validators.required,
      Validators.minLength(3)]);
    this.code = new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[a-z0-9_]+$/)
    ], [this.validators.check("fields/check-code?table=" + this.table.id + "&code=")]);
    this.archived = new FormControl('', []);
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

    /* Instanciation */
    super.ngOnInit();
  }

  protected check(): boolean {
    return this.form.valid;
  }

  protected provide(): FieldDTO<AbstractFieldConfigurationDTO> {
    let result = new FieldDTO();
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    result.configuration = this.entity.configuration;
    result.configuration.archived = this.archived.value;
    result.table.id = this.table.id;
    return result;
  }

  protected digest(): void {
    this.label.setValue(this.translator.tr(this.entity.label));
    this.code.setValue(this.entity.code);
    this.archived.setValue(this.entity.configuration.archived);
  }

  protected postSave(): void {
    this.state.publishTable(this.table);
  }
}

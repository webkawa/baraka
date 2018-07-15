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
import { ViewDTO, AdminViewConfigurationDTO } from '../../../../dto/view.dto';
import { PersitedAbstractFormular } from '../../persisted.abs';
import { FieldDTO, AbstractFieldConfigurationDTO, StringFieldConfigurationDTO, BooleanFieldConfigurationDTO, DateFieldConfigurationDTO, NumericFieldConfigurationDTO, ReferenceFieldConfigurationDTO } from '../../../../dto/field.dto';

/** Formulaire d'ajout d'un champ */
@Component({
  selector: 'admin-field-add',
  templateUrl: './field.add.form.html',
  styleUrls: ['./field.add.form.less']
})
export class AdminFieldAddFormular extends PersitedAbstractFormular<FieldDTO<AbstractFieldConfigurationDTO>> implements OnInit {

  @Input()
  public table: TableDTO;

  public tables: TableDTO[];
  public lang: string;

  public form: FormGroup;
  public label: FormControl;
  public code: FormControl;
  public type: FormControl;
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
    /* Création du formulaire */
    this.label = new FormControl('', [
      Validators.required,
      Validators.minLength(3)]);
    this.code = new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern(/^[a-z0-9_]+$/)
    ], [this.validators.check("fields/check-code?table=" + this.table.id + "&code=")]);
    this.type = new FormControl('STRING', [Validators.required]);
    this.reference = new FormControl('', []);
    this.form = new FormGroup({
      label: this.label,
      code: this.code,
      type: this.type,
      reference: this.reference
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
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    switch (this.type.value) {
      case "STRING": result.configuration = new StringFieldConfigurationDTO(); break;
      case "BOOLEAN": result.configuration = new BooleanFieldConfigurationDTO(); break;
      case "DATE": result.configuration = new DateFieldConfigurationDTO(); break;
      case "NUMERIC": result.configuration = new NumericFieldConfigurationDTO(); break;
      case "REFERENCE": result.configuration = new ReferenceFieldConfigurationDTO(); break;
    }
    result.table.id = this.table.id;
    return result;
  }

  protected digest(entity: FieldDTO<AbstractFieldConfigurationDTO>): void {
    entity.table = this.table;

    this.table.fields.push(entity);
    this.state.publishTable(this.table);
    this.router.navigate(["../../edit-field", entity.id], { relativeTo: this.ar });
  }
}

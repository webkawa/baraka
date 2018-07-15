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
  selector: 'admin-table-edit',
  templateUrl: './table.edit.form.html',
  styleUrls: ['./table.edit.form.less']
})
export class AdminTableEditFormular extends PersitedAbstractFormular<TableDTO> implements OnInit {
  
  public lang: string;

  public form: FormGroup;
  public label: FormControl;
  public code: FormControl;
  public archived: FormControl;

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
    this.archived = new FormControl('', []);
    this.form = new FormGroup({
      label: this.label,
      code: this.code,
      archived: this.archived
    });

    /* Instanciation */
    super.ngOnInit();
  }

  protected check(): boolean {
    return this.form.valid;
  }

  protected provide(): TableDTO {
    let result = new TableDTO();
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    result.configuration = new TableConfigurationDTO();
    result.configuration.archived = this.archived.value;
    return result;
  }

  protected digest(): void {
    this.label.setValue(this.translator.tr(this.entity.label));
    this.code.setValue(this.entity.code);
    this.archived.setValue(this.entity.configuration.archived);
  }

  protected postSave(): void {
    this.entity.fields 
    this.state.publishTable(this.entity);
  }
}

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

  public lang: string;

  public form: FormGroup;
  public label: FormControl;
  public code: FormControl;

  public constructor(
    public translator: TranslatorService,
    protected http: HttpClient,
    private state: StateService,
    private router: Router,
    private validators: ValidatorsService,
    private ar: ActivatedRoute) {

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
  }

  protected check(): boolean {
    return this.form.valid;
  }

  protected provide(): TableDTO {
    let result = new TableDTO();
    result.label = this.translator.edit(result.label, this.label.value);
    result.code = this.code.value;
    result.configuration = new TableConfigurationDTO();
    return result;
  }

  protected digest(entity: TableDTO): void {
    this.state.publishTable(entity);
    this.router.navigate(["../edit-table", entity.id], { relativeTo: this.ar });
  }
}

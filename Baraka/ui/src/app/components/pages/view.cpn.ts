import { Component, AfterViewInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { StateService } from '../../services/state.service';
import { AbstractViewDTO } from '../../dto/view.dto';
import { PagesViewAbstractComponent } from './view.abs';

/** Affichage d'une vue */
@Component({
  selector: 'pages-view',
  templateUrl: './view.cpn.html',
  styleUrls: ['./view.cpn.less']
})
export class PageViewComponent extends PagesViewAbstractComponent<AbstractViewDTO> {
  
  public constructor(
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute) {

    super(true, state, router, ar);

    this.ar.params.subscribe((params) => {
      // onInit broken
    });
  }

}

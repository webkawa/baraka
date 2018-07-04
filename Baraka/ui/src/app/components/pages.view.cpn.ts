import { Component, AfterViewInit, Input } from '@angular/core';

import { AuthenticationService } from '../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { StateService } from '../services/state.service';
import { ViewDTO } from '../dto/view.dto';

/** Affichage d'une vue */
@Component({
  selector: 'pages-view',
  templateUrl: './pages.view.cpn.html',
  styleUrls: ['./pages.view.cpn.less']
})
export class PageViewComponent {

  public view: ViewDTO;

  public constructor(
    private state: StateService,
    private ar: ActivatedRoute) {

    ar.params.subscribe((params) => {
      // onInit broken
      this.state
        .getViews()
        .subscribe((views) => {
          for (let i = 0; i < views.length; i++) {
            if (views[i].id == params["id"]) {
              this.view = views[i];
            }
          }
        });
    });
  }

}

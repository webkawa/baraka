import { Component, AfterViewInit, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { StateService } from '../../services/state.service';
import { ViewDTO, AbstractViewDTO } from '../../dto/view.dto';
import { AuthenticationService } from '../../services/authentication.service';
import { TranslatorService } from '../../services/translator.service';

/** Page d'accueil */
@Component({
  selector: 'pages-home',
  templateUrl: './home.cpn.html',
  styleUrls: ['./home.cpn.less']
})
export class PageHomeComponent {

  public views: ViewDTO<AbstractViewDTO>[];

  public constructor(
    public state: StateService,
    public router: Router,
    public authentication: AuthenticationService,
    public translator: TranslatorService,
    private ar: ActivatedRoute) {

    this.views = [];

    ar.params.subscribe((params) => {
      // onInit broken
      this.state
        .getViews()
        .subscribe((views) => {
          this.views = views;
        });
    })
  }
}

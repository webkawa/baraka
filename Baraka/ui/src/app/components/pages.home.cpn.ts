import { Component, AfterViewInit, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { ViewDTO } from '../dto/view.dto';

import { AuthenticationService } from '../services/authentication.service';
import { StateService } from '../services/state.service';
import { TranslatorService } from '../services/translator.service';
import { BundleDTO } from '../dto/bundle.dto';

/** Page d'accueil */
@Component({
  selector: 'pages-home',
  templateUrl: './pages.home.cpn.html',
  styleUrls: ['./pages.home.cpn.less']
})
export class PageHomeComponent {

  public views: ViewDTO[];

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

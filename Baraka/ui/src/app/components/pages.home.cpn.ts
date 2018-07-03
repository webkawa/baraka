import { Component, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

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
  public tr: Function;

  public constructor(
    public authentication: AuthenticationService,
    public state: StateService,
    public router: Router,
    private translator: TranslatorService) {

    this.views = [];
    this.tr = translator.getTranslation;
    this.state
      .getViews()
      .subscribe((views) => {
        this.views = views;
      });
  }
}

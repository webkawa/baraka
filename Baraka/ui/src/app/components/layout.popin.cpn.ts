import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, NavigationStart } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { AuthenticationSessionDTO } from '../dto/authentication.session.dto';
import { LoaderInterceptor } from '../internals/loader.interceptor';

/** Racine de l'application */
@Component({
  selector: 'layout-popin',
  templateUrl: './layout.popin.cpn.html',
  styleUrls: ['./layout.popin.cpn.less']
})
export class LayoutPopinComponent implements OnInit {

  public ngOnInit(): void {
  }

}

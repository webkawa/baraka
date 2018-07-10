import { Component, AfterViewInit, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { StateService } from '../../services/state.service';

/** Mire de connexion */
@Component({
  selector: 'pages-login',
  templateUrl: './login.cpn.html',
  styleUrls: ['./login.cpn.less']
})
export class PageLoginComponent {

  public name: string;
  public password: string;
  
  public constructor(
    public authentication: AuthenticationService,
    private state: StateService,
    private router: Router,
    private ar: ActivatedRoute) {

    this.ar.params.subscribe((params) => {
      // onInit broken
      this.authentication
        .getCredentials()
        .subscribe((data) => {
          if (data.connected) {
            this.state
              .loadState()
              .subscribe((data) => {
                this.router.navigate(["home"]);
              });
          }
        });
    });
  }
}

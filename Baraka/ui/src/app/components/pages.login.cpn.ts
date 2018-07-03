import { Component, AfterViewInit } from '@angular/core';

import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { StateService } from '../services/state.service';

/** Mire de connexion */
@Component({
  selector: 'pages-login',
  templateUrl: './pages.login.cpn.html',
  styleUrls: ['./pages.login.cpn.less']
})
export class PageLoginComponent {

  public name: string;
  public password: string;
  
  public constructor(
    public authentication: AuthenticationService,
    private state: StateService,
    private router: Router) {

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
  }
}

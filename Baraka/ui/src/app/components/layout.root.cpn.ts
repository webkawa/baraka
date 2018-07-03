import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, NavigationStart } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { AuthenticationSessionDTO } from '../dto/authentication.session.dto';
import { LoaderInterceptor } from '../internals/loader.interceptor';

/** Racine de l'application */
@Component({
  selector: 'layout-root',
  templateUrl: './layout.root.cpn.html',
  styleUrls: ['./layout.root.cpn.less']
})
export class LayoutRootComponent {

  public credentials: AuthenticationSessionDTO;
  public loading: boolean;

  public constructor(
    private http: HttpClient,
    private router: Router,
    private loader: LoaderInterceptor,
    private authentication: AuthenticationService) {
    this.http.get("demo").subscribe();

    // Suivi des autorisations
    this.authentication
      .getCredentials()
      .subscribe((data) => {
        this.credentials = data;
        this.checkCredentials(this.router.url);
      });
    this.router
      .events
      .subscribe((data) => {
        if (data instanceof NavigationStart) {
          this.checkCredentials(data.url);
        }
      });

    // Suivi du chargement
    this.loader
      .getLoader()
      .subscribe((data) => {
        this.loading = data;
      });
  }

  /**
   * Vérifie les droits d'accès et redirige vers la page de login.
   * @param url URL courante.
   */
  private checkCredentials(url: string) {
    if (url != "/login" && !this.credentials.connected) {
      this.router.navigate(["login"]);
    }
  }
}

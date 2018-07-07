import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, NavigationStart } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { AuthenticationSessionDTO } from '../dto/authentication.session.dto';
import { LoaderInterceptor } from '../internals/loader.interceptor';
import { ErrorDTO } from '../dto/error.dto';
import { ExceptionsInterceptor } from '../internals/exceptions.interceptor';
import { TranslatorService } from '../services/translator.service';

/** Racine de l'application */
@Component({
  selector: 'layout-root',
  templateUrl: './layout.root.cpn.html',
  styleUrls: ['./layout.root.cpn.less']
})
export class LayoutRootComponent implements OnInit {

  public credentials: AuthenticationSessionDTO;
  public loading: boolean;
  public error: ErrorDTO;

  public constructor(
    public translator: TranslatorService,
    private http: HttpClient,
    private router: Router,
    private loader: LoaderInterceptor,
    private exceptions: ExceptionsInterceptor,
    private authentication: AuthenticationService) {

    this.credentials = new AuthenticationSessionDTO();
    this.loading = false;
    this.error = null;
  }

  public ngOnInit(): void {

    // Démo
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

    // Suivi des erreurs
    this.exceptions
      .getFailures()
      .subscribe((data) => {
        this.error = data;
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

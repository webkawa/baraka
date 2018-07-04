import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, forkJoin, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'

import { ViewDTO } from '../dto/view.dto';
import { AuthenticationService } from './authentication.service';
import { AuthenticationSessionDTO } from '../dto/authentication.session.dto';
import { BundleDTO } from '../dto/bundle.dto';

/** Service de traduction */
@Injectable({
  providedIn: 'root'
})
export class TranslatorService {

  private credentials: AuthenticationSessionDTO;

  constructor(
    private authentication: AuthenticationService) {

    this.authentication
      .getCredentials()
      .subscribe((data) => {
        this.credentials = data;
      });
  }

  /** Retourne la langue de l'utilisateur */
  public getLang(): string {
    return this.credentials.connected ? this.credentials.user.configuration.culture : "FRA";
  }

  /**
   * Retourne la traduction appropriée pour un lot de traductions.
   * @param bundle Lot de traductions
   */
  public translate(bundle: BundleDTO): string {
    return bundle.data[this.getLang()] ? bundle.data[this.getLang()] : "?";
  }
  public tr(bundle: BundleDTO): string {
    return this.translate(bundle);
  }

}

import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable, Subject, BehaviorSubject } from 'rxjs';

import { AuthenticationSessionDTO } from '../dto/authentication.session.dto';
import { UserDTO } from '../dto/user.dto';
import { StateService } from './state.service';

/** Service d'authentification */
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private credentials: Subject<AuthenticationSessionDTO>

  public constructor(
    private http: HttpClient,
    private state: StateService) {
    this.credentials = new BehaviorSubject(new AuthenticationSessionDTO());
  }

  /** Retourne le droits d'accès courants */
  public getCredentials(): Observable<AuthenticationSessionDTO> {
    return this.credentials.asObservable();
  }

  /**
   * Tente une connexion
   * @param name Login ou e-mail de l'utilisateur.
   * @param password Mot de passe.
   */
  public connect(name: string, password: string): void {
    if (name && password) {
      this.http
        .get<AuthenticationSessionDTO>("auth/connect?name=" + name + "&password=" + password)
        .subscribe((data) => {
          this.credentials.next(data);
          this.state.loadState();
        });
    } else {
      throw new Error("Missing argument");
    }
  }

  /** Procède à la déconnexion. */
  public disconnect(): void {
    this.credentials.next(new AuthenticationSessionDTO());
    this.http.get<AuthenticationSessionDTO>("auth/disconnect");
  }
}

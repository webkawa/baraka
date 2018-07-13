import { HttpClient } from "@angular/common/http";
import { Input, OnInit } from "@angular/core";

import { TableDTO } from "src/app/dto/table.dto";
import { EntityDTO } from "../../dto/entity.dto";

/** Classe abstraite descriptive d'un formulaire permettant l'ajout et/ou la mise à jour
 *  d'une entité persitante en base.
 *  L'objet embarque une copie de l'entitée persistée qui peut être nulle (dans le cas
 *  d'un ajout) ou définie (dans le cas d'une mise à jour). Les classes descendantes
 *  doivent implémenter les méthodes permettant la définition d'une entité vierge ou
 *  sur la base des directives de saisie et peuvent également définir des actions
 *  complémentaires.
 *  Les URL d'ajout et de mise à jour sont structurées de la manière suivante :
 *  {prefix}/[add|update] */
export abstract class PersitedAbstractFormular<TEntity extends EntityDTO> implements OnInit {

  @Input()
  public entity: TEntity;
  public persisted: boolean;

  public constructor(
    protected http: HttpClient,
    private prefix: string) {
  }

  public ngOnInit(): void {
    this.persisted = this.entity != null;
  }

  /** Réalise une action d'ajout. */
  public add(): void {
    this.sync(true);
  }

  /** Réalise une action de mise à jour. */
  public save(): void {
    this.sync(false);
  }

  /** Réalise une action d'ajout ou de mise à jour. */
  public submit(): void {
    this.sync(!this.persisted);
  }

  /** Indique si la synchronisation peut avoir lieu. */
  protected abstract check(): boolean;

  /** Génère et retourne une instance de l'entité correspondant au contenu du formulaire. */
  protected abstract provide(): TEntity;

  /** Intègre l'état courant de l'entité. */
  protected abstract digest(): void;

  /** Actions consécutives à l'ajout. */
  protected postAdd(): void { }

  /** Actions consécutives à la mise à jour. */
  protected postSave(): void { }

  /**
   * Synchronise l'entité avec le serveur.
   * @param add true pour réaliser un ajout, false sinon.
   */
  private sync(add: boolean): void {
    if (this.check()) {
      if (this.persisted == add) {
        throw new Error("Invalid state");
      }

      let action = add ? "add" : "update";
      let instance = this.provide();
      this.http
        .post<TEntity>(this.prefix + "/" + action, instance)
        .subscribe((data) => {
          this.entity = data;
          if (this.persisted) {
            this.postSave();
          } else {
            this.postAdd();
          }

          this.persisted = true;
          this.digest();
        });
    }
  }
}

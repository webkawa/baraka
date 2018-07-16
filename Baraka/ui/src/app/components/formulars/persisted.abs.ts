import { HttpClient } from "@angular/common/http";
import { Input, OnInit } from "@angular/core";

import { TableDTO } from "src/app/dto/table.dto";
import { EntityDTO } from "../../dto/entity.dto";
import { BehaviorSubject } from "rxjs";

/** Classe abstraite descriptive d'un formulaire permettant l'ajout et/ou la mise à jour
 *  d'une entité persitante en base.
 *  Le composant permet de réaliser des appels au serveur sur la base de deux modes :
 *  insertion (à l'URL '{prefix}/add') et mise à jour ('{prefix}/update'). Le préfixe
 *  utilisé est fixé directement par les classes héritantes.
 *  Par défaut, la classe réalise un premier appel au serveur (via la méthode 'submit()')
 *  en mode d'insertion et les suivants en mode de mise à jour. La classe fille peut toutefois
 *  forcer le comportement de chaque appel. */
export abstract class PersitedAbstractFormular<TEntity extends EntityDTO> {

  public persisted: boolean;

  public constructor(
    protected http: HttpClient,
    private prefix: string) {

    this.persisted = false;
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
  
  /** Génère et retourne une instance de l'entité portée par le formulaire reflétant le contenu
   *  attendu côté serveur pour permettre insertion ou mise à jour. */
  protected abstract provide(): TEntity;
  
  /**
   *  Intègre une instance de l'entité renvoyée par le serveur à la suite d'une insertion ou
   *  d'une mise à jour.
   *  @param entity Entité retournée par le serveur.
   *  @param add Action réalisée (ajout ou mise à jour).
   */
  protected abstract digest(entity: TEntity, add: boolean): void;

  /**
   * Synchronise l'entité avec le serveur.
   * @param add true pour réaliser un ajout, false sinon.
   */
  private sync(add: boolean): void {
    console.log("fu ?");
    if (this.check()) {
      console.log("fufu?");
      let action = add ? "add" : "update";
      let instance = this.provide();

      console.log(instance);
      this.http
        .post<TEntity>(this.prefix + "/" + action, instance)
        .subscribe((data) => {
          this.persisted = false;
          this.digest(data, add);
        });
    }
  }
}

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
export abstract class PersitedAbstractFormular<TEntity extends EntityDTO> implements OnInit {


  public persisted: boolean;

  /*
  private attribute: TEntity;
  private subject: BehaviorSubject<TEntity>;
  
  @Input()
  protected set entity(entity: TEntity) {
    this.persisted = entity != null;
    this.attribute = entity;
    this.subject.next(entity);
  };
  protected get entity(): TEntity {
    return this.attribute;
  }*/

  public constructor(
    protected http: HttpClient,
    private prefix: string) {
  }

  public ngOnInit(): void {
    this.subject.subscribe((data) => {
      if (data != null) {
        this.digest();
      }
    });
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

  /** Génère et retourne une instance neuve de l'entité correspondant au contenu du
   *  formulaire. */

  /** Génère et retourne une instance neuve de l'entité portée par le formulaire alimentée
   *  de manière à ce que son contenu reflête le contenu attendu, niveau serveur, par les
   *  services d'insertion ou de mise à jour. */
  protected abstract provide(): TEntity;
  
  /** Intègre les changements    */
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

      if (!add) {
        instance.id = this.entity.id;
      }

      this.http
        .post<TEntity>(this.prefix + "/" + action, instance)
        .subscribe((data) => {
          this.entity = data;
          if (add) {
            this.postAdd();
          } else {
            this.postSave();
          }
        });
    }
  }
}

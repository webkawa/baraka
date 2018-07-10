import { HttpClient } from "@angular/common/http";
import { Input, OnInit } from "@angular/core";

import { TableDTO } from "src/app/dto/table.dto";
import { EntityDTO } from "../../../dto/entity.dto";

/** Classe de base pour un formulaire permettant l'ajout ou la mise à jour d'une entité standard. */
export abstract class AdminEditAbstractFormular<TEntity extends EntityDTO> implements OnInit {

  @Input()
  public entity: TEntity;
  public persisted: boolean;

  public constructor(
    protected http: HttpClient,
    private url: string) {
  }

  public ngOnInit(): void {
    this.persisted = this.entity != null;
    if (!this.persisted) {
      this.entity = this.init();
    } else {
      this.init();
    }
  }

  /** Procède à l'ajout ou à la mise à jour. */
  public addOrSave(): void {
    this.sync(1);
  }

  /** Procède à l'ajout. */
  public add(): void {
    this.sync(2);
  }

  /** Procède à la mise à jour. */
  public save(): void {
    this.sync(3);
  }

  /**
   * Soumission du formulaire.
   * @param mode Mode d'utilisation (1: insertion et édition ; 2: insertion uniquement ; 3: édition uniquement.)
   */
  private sync(mode: number): void {
    if (mode == 2 && this.persisted) return;
    if (mode == 3 && !this.persisted) return;

    let action = this.persisted ? "edit" : "add";
    if (this.pre()) {
      this.http
        .post<TEntity>(this.url + "/" + action, this.entity)
        .subscribe((data) => {
          this.entity = data;
          if (this.persisted) {
            this.postSave();
          } else {
            this.persisted = true;
            this.postAdd();
          }
          this.postAll();
        });
    }
  }

  /** Méthode d'initialisation du formulaire (dans le corps) et de
   *  l'entité (en valeur de retour). */
  protected abstract init(): TEntity;

  /** Méthode procédant à la soumission du formulaire.
   *  Retourne true si les modifications sont validées, false sinon. */
  protected abstract pre(): boolean;

  /** Actions consécutives à la création d'une fiche. */
  protected abstract postAdd(): void;

  /** Actions consécutives à la modification d'une fiche. */
  protected abstract postSave(): void;

  /** Actions consécutives à l'un et l'autre des traitements. */
  protected abstract postAll(): void;
}

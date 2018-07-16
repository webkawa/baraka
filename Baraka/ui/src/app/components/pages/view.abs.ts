import { ActivatedRoute, Router, Params } from "@angular/router";

import { StateService } from "../../services/state.service";
import { AbstractViewConfigurationDTO, ViewDTO } from "../../dto/view.dto";
import { combineLatest } from "rxjs";
import { map } from "rxjs/operators";

/** Vue abstraite */
export abstract class PagesViewAbstractComponent<TView extends AbstractViewConfigurationDTO> {

  public views: ViewDTO<AbstractViewConfigurationDTO>[];
  public view: ViewDTO<TView>;

  public constructor(
    protected redirect: boolean,
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute) {

    combineLatest(this.ar.params, this.state.getViews())
      .subscribe(([params, views]) => {
        /* Récupération de la vue */
        this.views = views;
        this.view = <ViewDTO<TView>>views.filter((v) => v.id == params["view"])[0];

        /* Redirection */
        if (this.redirect) {
          this.router.navigate(
            ["/view", this.view.id, this.view.configuration.type.toLowerCase()],
            {
              skipLocationChange: true
            });
        }
      });
    
    /*
    this.ar.params.subscribe((params) => {
      // onInit broken
      this.state
        .getViews()
        .subscribe((views) => {
          /* Récupération de la vue *
          this.views = views;
          this.view = <ViewDTO<TView>>views.filter((v) => v.id == params["view"])[0];

          /* Redirection *
          if (this.redirect) {
            this.router.navigate(
              ["/view", this.view.id, this.view.configuration.type.toLowerCase()],
              {
                skipLocationChange: true
              });
          }
        });
    });*/
  }
}

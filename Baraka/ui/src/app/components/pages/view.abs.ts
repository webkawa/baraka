import { ActivatedRoute, Router } from "@angular/router";

import { StateService } from "../../services/state.service";
import { AbstractViewDTO, ViewDTO } from "../../dto/view.dto";

/** Vue abstraite */
export abstract class PagesViewAbstractComponent<TView extends AbstractViewDTO> {

  public views: ViewDTO<AbstractViewDTO>[];
  public view: ViewDTO<TView>;

  public constructor(
    protected redirect: boolean,
    protected state: StateService,
    protected router: Router,
    protected ar: ActivatedRoute) {
    
    this.ar.params.subscribe((params) => {
      // onInit broken
      this.state
        .getViews()
        .subscribe((views) => {
          /* Récupération de la vue */
          this.views = views;
          this.view = <ViewDTO<TView>>views.filter((v) => v.id == params["view"])[0];

          /* Redirection */
          if (this.redirect) {
            this.router.navigate(
              ["/view", this.view.id, this.view.model.type.toLowerCase()],
              {
                skipLocationChange: true
              });
          }
        });
    });
  }
}

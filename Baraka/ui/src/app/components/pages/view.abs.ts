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
    
    ar.params.subscribe((params) => {
      // onInit broken
      this.state
        .getViews()
        .subscribe((views) => {
          this.views = views;
          for (let i = 0; i < views.length; i++) {
            if (views[i].id == params["id"]) {
              this.view = <ViewDTO<TView>>views[i];
              if (this.redirect) {
                this.router.navigate(
                  ["/view", this.view.id, this.view.model.type.toLowerCase()],
                  {
                    skipLocationChange: true
                  });
              }
            }
          }
        });
    });
  }
}

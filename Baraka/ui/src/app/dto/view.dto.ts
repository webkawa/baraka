import { BundleDTO } from "./bundle.dto";
import { PersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class ViewDTO<TView extends AbstractViewDTO> extends EntityDTO {
  public label: BundleDTO = null;
  public model: TView = null;
}

export class AbstractViewDTO extends PersistedDTO {
}

export class AdminViewDTO extends AbstractViewDTO {
}

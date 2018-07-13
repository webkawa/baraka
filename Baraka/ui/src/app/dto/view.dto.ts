import { BundleDTO } from "./bundle.dto";
import { PersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class ViewDTO<TView extends AbstractViewConfigurationDTO> extends EntityDTO {
  public label: BundleDTO = null;
  public configuration: TView = null;
}

export class AbstractViewConfigurationDTO extends PersistedDTO {
}

export class AdminViewConfigurationDTO extends AbstractViewConfigurationDTO {
}

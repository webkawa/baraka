import { BundleDTO } from "./bundle.dto";
import { PersistedDTO, GenericPersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class ViewDTO<TView extends AbstractViewConfigurationDTO> extends EntityDTO {
  public label: BundleDTO = new BundleDTO;
  public configuration: TView = null;
}

export class AbstractViewConfigurationDTO extends GenericPersistedDTO {
}

export class AdminViewConfigurationDTO extends AbstractViewConfigurationDTO {
  public constructor() { super("ADMIN"); }
}

export class FileViewConfigurationDTO extends AbstractViewConfigurationDTO {
  public constructor() { super("FILE"); }
}

export class ListViewConfigurationDTO extends AbstractViewConfigurationDTO {
  public constructor() { super("LIST"); }
}

export class SqlViewConfigurationDTO extends AbstractViewConfigurationDTO {
  public constructor() { super("SQL"); }
}

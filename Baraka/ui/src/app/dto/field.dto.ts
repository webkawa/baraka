import { BundleDTO } from "./bundle.dto";
import { TableDTO } from "./table.dto";
import { PersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class FieldDTO extends EntityDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public configuration: AbstractFieldConfigurationDTO = new AbstractFieldConfigurationDTO();
  public table: TableDTO = new TableDTO();
}

export class AbstractFieldConfigurationDTO extends PersistedDTO {
}

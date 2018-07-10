import { BundleDTO } from "./bundle.dto";
import { FieldDTO } from "./field.dto";
import { PersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class TableDTO extends EntityDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public fields: FieldDTO[];
}

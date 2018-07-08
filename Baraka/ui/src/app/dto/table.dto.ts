import { BundleDTO } from "./bundle.dto";
import { FieldDTO } from "./field.dto";
import { PersistedDTO } from "./persisted.dto";

export class TableDTO extends PersistedDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public fields: FieldDTO[];
}

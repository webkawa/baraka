import { BundleDTO } from "./bundle.dto";
import { TableDTO } from "./table.dto";
import { PersistedDTO } from "./persisted.dto";

export class FieldDTO extends PersistedDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public table: TableDTO = new TableDTO();
}

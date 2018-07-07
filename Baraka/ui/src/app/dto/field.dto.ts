import { BundleDTO } from "./bundle.dto";
import { TableDTO } from "./table.dto";

export class FieldDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public table: TableDTO = new TableDTO();
}

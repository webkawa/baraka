import { BundleDTO } from "./bundle.dto";
import { FieldDTO } from "./field.dto";

export class TableDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public fields: FieldDTO[];
}

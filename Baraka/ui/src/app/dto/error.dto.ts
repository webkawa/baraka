import { BundleDTO } from "./bundle.dto";

export class ErrorDTO {
  public code: number = 200;
  public message: BundleDTO = new BundleDTO();
}

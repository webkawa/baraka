import { BundleDTO } from "./bundle.dto";
import { TableDTO } from "./table.dto";
import { PersistedDTO, GenericPersistedDTO } from "./persisted.dto";
import { EntityDTO } from "./entity.dto";

export class FieldDTO<TField extends AbstractFieldConfigurationDTO> extends EntityDTO {
  public label: BundleDTO = new BundleDTO();
  public code: string = "";
  public configuration: TField = null;
  public table: TableDTO = new TableDTO();
}

export class AbstractFieldConfigurationDTO extends GenericPersistedDTO {
  public archived: boolean = true;
}

export class StringFieldConfigurationDTO extends AbstractFieldConfigurationDTO {
  public constructor() { super("STRING"); }
}

export class BooleanFieldConfigurationDTO extends AbstractFieldConfigurationDTO {
  public constructor() { super("BOOLEAN"); }
}

export class NumericFieldConfigurationDTO extends AbstractFieldConfigurationDTO {
  public constructor() { super("NUMERIC"); }
}

export class DateFieldConfigurationDTO extends AbstractFieldConfigurationDTO {
  public constructor() { super("DATE"); }
}

export class ReferenceFieldConfigurationDTO extends AbstractFieldConfigurationDTO {
  public constructor() { super("REFERENCE"); }
}

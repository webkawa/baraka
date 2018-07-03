export class UserDTO {
  public login: string = "";
  public email: string = "";
  public configuration: UserConfigurationDTO = new UserConfigurationDTO();
}

export class UserConfigurationDTO {
  public culture: string = "";
}

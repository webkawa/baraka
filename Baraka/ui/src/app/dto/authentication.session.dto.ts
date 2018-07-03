import { UserDTO } from "./user.dto";

export class AuthenticationSessionDTO {
  public connected: boolean = false;
  public token: string = "";
  public user: UserDTO = new UserDTO();
}

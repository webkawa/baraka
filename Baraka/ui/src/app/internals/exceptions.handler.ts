import { ErrorHandler } from "@angular/core";

export class ExceptionsHandler extends ErrorHandler {
  public constructor() {
    super();
  }

  public handleError(error: any): void {
    console.log(error);
    alert("Ouch !");
  }
}

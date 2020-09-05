import { Token, cliente } from "../Interfaces/interfaces";

export class User {
  public _cliente: cliente
  public _token: string

  constructor(cliente: cliente, token: string,) {
    this._cliente = cliente;
    this._token = token;
  }

  get token() {
    return this.token;
  }
  set token(token: string) {
    this._token = token;
  }
}

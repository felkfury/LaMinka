export interface ILogin {
  Email: string;
  Password: string;
}

export interface IResponse {
  response: string;
}

export interface Token {
  token: string,
  expirationDate: Date,
}
export interface cliente {
  Id: number,
  Nombre: string,
  Apellido: string,
  Email: string,
  IdUserModif: number,
  IdUserAlta: number,
  FechaAlta: Date
  FechaModif: Date,
  Activo: boolean,
}

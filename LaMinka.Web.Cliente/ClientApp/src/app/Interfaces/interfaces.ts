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
  id: number,
  nombre: string,
  apellido: string,
  email: string,
  idUserModif: number,
  idUserAlta: number,
  fechaAlta: Date
  fechaModif: Date,
  activo: boolean,
}

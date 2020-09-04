import { Injectable, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { ILogin } from "../Interfaces/interfaces";
import { Subscription } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { User } from "../Models/user.model";

@Injectable({
  providedIn: "root",
})

export class AuthService {
  constructor(private router: Router, private http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string) { }

  subRes$: Subscription;
  LoggedUser: User;

  LogIn(user: string, pass: string) {
    const usuarioLogIn: ILogin = {
      Email: user,
      Password: pass,
    };
    console.log(usuarioLogIn);

    return new Promise((resolve, reject) => {
      this.subRes$ = this.http
        .post(this.baseUrl + "login/", usuarioLogIn, {
          observe: "response",
        })
        .subscribe(
          (result: any) => {
            console.log("token:", result.body.token);

            const token = result.body.token
            const user = result.body.user

            this.LoggedUser = new User(user, token)
            console.log(token);
            console.log(this.LoggedUser);
            sessionStorage.setItem("LoggedUser", JSON.stringify(this.LoggedUser));

            this.subRes$.unsubscribe();
            resolve();
          },
          (error) => console.error(error)
        );
    });
  }

  LogOut() {
    this.LoggedUser = null;
    sessionStorage.removeItem("LoggedUser");
    this.router.navigate(["/"]);
  }

  Register(user: string, pass: string) {
    const usuarioRegistro: any = {
      Email: user,
      Password: pass,
      Activo: true,
    };
    console.log(usuarioRegistro);

    return new Promise((resolve, reject) => {
      this.subRes$ = this.http
        .post(this.baseUrl + "clientes", usuarioRegistro, {
          observe: "response",
        })
        .subscribe(async (result: any) => {
          console.log("llego:", result.body);
          await this.LogIn(result.body.email, result.body.password)
          console.log(this.LoggedUser);
          resolve()
          this.subRes$.unsubscribe();
        },
          (error) => console.error(error)
        );
    });
  }

  isAuth() {
    if (this.LoggedUser) return true;
    else return false;
  }

  autoLogin() {
    this.LoggedUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  }
}

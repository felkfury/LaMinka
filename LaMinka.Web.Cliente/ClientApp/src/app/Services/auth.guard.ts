import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanDeactivate,
  Router,
  UrlTree,
} from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";
import { LoginComponent } from "../Pages/login/login.component";

@Injectable({ providedIn: "root" })
export class AuthGuard
  implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    router: RouterStateSnapshot
  ): boolean | Promise<boolean> | Observable<boolean> | UrlTree {
    if (this.authService.isAuth()) {
      if (route.url[0].path != "ingresar") return true;
      else return this.router.createUrlTree(["/home"]);
    } else {
      if (route.url[0].path == "ingresar") {
        return true;
      } else return this.router.createUrlTree(["/ingresar"]);
    }
  }
}

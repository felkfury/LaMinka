import { Component, OnInit, Inject, OnDestroy } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ILogin, IResponse } from "../../Interfaces/interfaces";
import { Subscription } from "rxjs";
import { environment } from "../../../environments/environment";
import { AppComponent } from "../../app.component";
import { AuthService } from "../../Services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit, OnDestroy {
  formLogin: FormGroup;
  subRes$: Subscription;

  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string,
    private formBuilder: FormBuilder,
    private router: Router,
    public appcomponent: AppComponent,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.formLogin = this.formBuilder.group({
      usuario: ["", Validators.required],
      password: ["", Validators.required],
    });
  }

  async LogIn() {
    await this.authService.LogIn(this.formLogin.value.usuario, this.formLogin.value.password)
    this.router.navigate(["/home"]);
  }

  ngOnDestroy() {
    if (this.subRes$) this.subRes$.unsubscribe();
  }
}

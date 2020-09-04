import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AppComponent } from "../../app.component";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { AuthService } from "../../Services/auth.service";

@Component({
  selector: "app-registro",
  templateUrl: "./registro.component.html",
  styleUrls: ["./registro.component.css"],
})
export class RegistroComponent implements OnInit {
  formRegister: FormGroup;
  subRes$: Subscription;
  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string,
    private formBuilder: FormBuilder,
    private router: Router,
    public appcomponent: AppComponent,
    public authService: AuthService
  ) {
    this.formRegister = formBuilder.group({
      mail: ["", Validators.required],
      password: ["", Validators.required],
      confirmPassword: ["", Validators.required],
    });
  }

  ngOnInit() {
  }

  async Register() {
    await this.authService.Register(this.formRegister.value.mail, this.formRegister.value.password)
    console.log(this.authService.LoggedUser);
    this.router.navigate(["/datosPersonales"]);
  }

  ngOnDestroy() {
    if (this.subRes$) this.subRes$.unsubscribe();
  }
}

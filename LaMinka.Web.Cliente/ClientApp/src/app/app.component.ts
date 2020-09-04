import { Component, OnInit } from "@angular/core";
import { AuthService } from "./Services/auth.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  title = "app";
  auth

  constructor(public authService: AuthService) {
  }

  ngOnInit() {
    this.authService.autoLogin();
  }
}

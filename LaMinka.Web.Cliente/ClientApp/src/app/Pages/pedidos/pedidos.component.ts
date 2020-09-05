import {
  Component,
  Inject,
  OnInit,
  AfterContentInit,
  AfterViewInit,
} from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AppComponent } from "../../app.component";
import Swiper from "swiper/bundle";
import { AuthService } from "../../Services/auth.service";

@Component({
  selector: "app-pedidos",
  templateUrl: "./pedidos.component.html",
  styleUrls: ["./pedidos.component.css"],
})
export class PedidosComponent implements OnInit, AfterViewInit {
  public strings: string[];

  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string, public authService: AuthService
  ) { }

  ngOnInit() { }

  ngAfterViewInit() {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .append('Authorization', "Bearer " + this.authService.LoggedUser._token)

    this.http
      .get<string[]>(this.baseUrl + "pedidos", {
        headers: headers,
      })
      .subscribe(
        (result) => {
          this.strings = result;
        },
        (error) => console.error(error)
      );

    let swiper = new Swiper(".swiper-container", {
      slidesPerView: 3,
      spaceBetween: 30,
      centeredSlides: true,
      pagination: {
        el: ".swiper-pagination",
        clickable: true,
      },
    });
  }
}

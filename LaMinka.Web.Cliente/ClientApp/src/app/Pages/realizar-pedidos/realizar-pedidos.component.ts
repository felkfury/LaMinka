import { Component, OnInit, AfterViewInit } from "@angular/core";
import Swiper from "swiper/bundle";
import { get } from 'scriptjs';


@Component({
  selector: "app-realizar-pedidos",
  templateUrl: "./realizar-pedidos.component.html",
  styleUrls: ["./realizar-pedidos.component.css"],
})
export class RealizarPedidosComponent implements OnInit, AfterViewInit {
  constructor() {}

  ngOnInit() {


  }

  ngAfterViewInit() {
    var swiper = new Swiper(".swiper-container", {
      slidesPerView: 4,
      spaceBetween: 30,

      pagination: {
        el: ".swiper-pagination",
        clickable: true,
      },
    });
  }
}

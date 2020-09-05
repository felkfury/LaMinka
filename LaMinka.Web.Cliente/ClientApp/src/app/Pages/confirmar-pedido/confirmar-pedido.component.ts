import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-confirmar-pedido",
  templateUrl: "./confirmar-pedido.component.html",
  styleUrls: ["./confirmar-pedido.component.css"],
})
export class ConfirmarPedidoComponent implements OnInit {
  lat;
  lng;
  constructor() { }

  ngOnInit() { }

  onMapReady(map) {
    //codigo para cargar el mapa,
    const geocoder = new google.maps.Geocoder();

    geocoder.geocode(
      {
        //aca se pone la direccion que viene del domicilio elegido en la pagina anterior
        address: "",
      },
      (results, status) => {
        if (status === "OK") {
        } else {
          console.log(
            "Geocode was not successful for the following reason: " + status
          );
        }
      }
    );
  }
}

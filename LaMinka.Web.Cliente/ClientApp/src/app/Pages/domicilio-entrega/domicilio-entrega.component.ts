import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Router } from "@angular/router";
import { AppComponent } from "../../app.component";

@Component({
  selector: "app-domicilio-entrega",
  templateUrl: "./domicilio-entrega.component.html",
  styleUrls: ["./domicilio-entrega.component.css"],
})
export class DomicilioEntregaComponent implements OnInit {
  formDatos: FormGroup;
  lat;
  lng;
  constructor(
    public http: HttpClient,
    @Inject("BASE_URL") public baseUrl: string,
    private formBuilder: FormBuilder,
    private router: Router,
    public appcomponent: AppComponent
  ) {
    this.formDatos = formBuilder.group({
      identificador: ["", Validators.required],
      nombre: ["", Validators.required],

      celular: ["", Validators.required],
      calle: ["", Validators.required],
      nro: ["", Validators.required],
      depto: ["", Validators.required],
      entreCalle: ["", Validators.required],
      segundaEntreCalle: ["", Validators.required],
      localidad: ["", Validators.required],
    });
  }

  ngOnInit() {
    this.setCurrentPosition();
  }

  onMapReady(map) {
    const geocoder = new google.maps.Geocoder();
    this.formDatos.valueChanges.subscribe((data) => {
      geocoder.geocode(
        {
          address: `${this.formDatos.controls["calle"].value}
        ${this.formDatos.controls["numero"].value} ,
        ${this.formDatos.controls["localidad"].value}`,
        },
        (results, status) => {
          if (status === "OK") {
            this.lat = results[0].geometry.location.lat;
            this.lng = results[0].geometry.location.lat;
          } else {
            console.log(
              "Geocode was not successful for the following reason: " + status
            );
          }
        }
      );
    });
  }

  private setCurrentPosition() {
    if ("geolocation" in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      });
    }
  }
}

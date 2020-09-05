import { Component, OnInit, Inject, OnChanges } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppComponent } from '../../app.component';
import { Router } from '@angular/router';
import { User } from '../../Models/user.model';
import { AuthService } from '../../Services/auth.service';
import { cliente } from '../../Interfaces/interfaces';

declare const google: any;

interface Location {
  latitude: number;
  longitude: number
}

@Component({
  selector: 'app-datos-personales',
  templateUrl: './datos-personales.component.html',
  styleUrls: ['./datos-personales.component.css']
})
export class DatosPersonalesComponent implements OnInit {
  formDatos: FormGroup
  lat
  lng

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, public formBuilder: FormBuilder, private router: Router, public appcomponent: AppComponent, public authService: AuthService) {
  }

  ngOnInit() {
    this.formDatos = this.formBuilder.group(
      {
        nombre: ["", Validators.required],
        apellido: ["", Validators.required],
        mail: ["", Validators.required],
        celular: ["", Validators.required],
        calle: ["", Validators.required],
        numero: ["", Validators.required],
        depto: ["", Validators.required],
        entreCalle: ["", Validators.required],
        segundaEntreCalle: ["", Validators.required],
        localidad: ["", Validators.required],
      });

    this.setCurrentPosition();
    console.log(this.authService.LoggedUser._cliente.email)
    this.formDatos.patchValue({ nombre: this.authService.LoggedUser._cliente.nombre, apellido: this.authService.LoggedUser._cliente.apellido, mail: this.authService.LoggedUser._cliente.email });
  }

  onMapReady(map) {
    const geocoder = new google.maps.Geocoder();
    //this.formDatos.valueChanges.subscribe(data => {
    //  geocoder.geocode({
    //    address: `${this.formDatos.controls["calle"].value}
    //    ${this.formDatos.controls['numero'].value} ,
    //    ${this.formDatos.controls["localidad"].value}`
    //  }, (results, status) => {
    //    if (status === "OK") {
    //      this.lat = results[0].geometry.location.lat;
    //      this.lng = results[0].geometry.location.lat;
    //    } else {
    //      console.log("Geocode was not successful for the following reason: " + status)
    //    }
    //  });
    //});
  }

  private setCurrentPosition() {
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      });
    }
  }

  onSave() {
    console.log(this.authService.LoggedUser)

    const user = this.authService.LoggedUser;
    user._cliente.nombre = this.formDatos.value.nombre
    user._cliente.apellido = this.formDatos.value.apellido
    user._cliente.email = this.formDatos.value.mail
    user._cliente.idUserModif = 1
    this.authService.LoggedUser._cliente.fechaModif = new Date(Date.now());
    this.authService.LoggedUser = user;
    this.authService.saveUserChanges();
    this.formDatos.patchValue({ nombre: this.authService.LoggedUser._cliente.nombre, apellido: this.authService.LoggedUser._cliente.apellido, mail: this.authService.LoggedUser._cliente.email });

    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .append('Authorization', "Bearer " + user._token)

    this.http
      .post<cliente>(this.baseUrl + "clientes/edit", user._cliente, {
        headers: headers,
      })
      .subscribe(
        (result) => {
          console.log("edito: ", result)
        },
        (error) => console.error(error)
      );
  }
}

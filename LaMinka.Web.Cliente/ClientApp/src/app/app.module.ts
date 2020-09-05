import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./Components/nav-menu/nav-menu.component";
import { HomeComponent } from "./Pages/home/home.component";
import { CounterComponent } from "./Pages/counter/counter.component";
import { PedidosComponent } from "./Pages/pedidos/pedidos.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FooterComponent } from "./Components/footer/footer.component";
import { LoginComponent } from "./Pages/login/login.component";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { DemoMaterialModule } from "./meterial-module";
import { RegistroComponent } from "./Pages/registro/registro.component";
import { AuthService } from "./Services/auth.service";
import { RealizarPedidosComponent } from "./pages/realizar-pedidos/realizar-pedidos.component";
import { AuthGuard } from "./Services/auth.guard";
import { DomicilioEntregaComponent } from "./Pages/domicilio-entrega/domicilio-entrega.component";
import { DatosPersonalesComponent } from "./Pages/datos-personales/datos-personales.component";
import { AgmCoreModule } from '@agm/core';
import { ConfirmarPedidoComponent } from './Pages/confirmar-pedido/confirmar-pedido.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    PedidosComponent,
    FooterComponent,
    LoginComponent,
    RegistroComponent,
    RealizarPedidosComponent,
    DatosPersonalesComponent,
    DomicilioEntregaComponent,
    ConfirmarPedidoComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: "",
        pathMatch: "full",
        redirectTo: "ingresar",
      },

      {
        path: "home",
        component: HomeComponent,
        canActivate: [AuthGuard],
      },

      {
        path: "ingresar",
        component: LoginComponent,
        canActivate: [AuthGuard],
      },

      {
        path: "misPedidos",
        component: PedidosComponent,
        canActivate: [AuthGuard],
      },

      { path: "registro", component: RegistroComponent },

      {
        path: "hacerPedido",
        component: RealizarPedidosComponent,
        canActivate: [AuthGuard],
      },

      {
        path: "domicilioEntrega",
        component: DomicilioEntregaComponent,
        canActivate: [AuthGuard],
      },

      {
        path: "datosPersonales",
        component: DatosPersonalesComponent,
        canActivate: [AuthGuard],
      },
      {
        path: "confirmarPedido",
        component: ConfirmarPedidoComponent,
        canActivate: [AuthGuard],
      },
    ]),

    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    DemoMaterialModule,
    AgmCoreModule.forRoot({
      apiKey: "",

      libraries: ["places", "drawing", "geometry",]
    })
  ],
  providers: [AuthService],
  bootstrap: [AppComponent],
})
export class AppModule { }

import { Component } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { HttpHeaders } from "@angular/common/http";
@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent {
  strings: ["2 bolsones", "2 docenas de huevo", "5 kilos de yerba"];
}

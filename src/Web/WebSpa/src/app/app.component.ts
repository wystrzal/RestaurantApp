import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent implements OnInit {
  title = "RestaurantSpa";

  ngOnInit() {
    const basket = JSON.parse(localStorage.getItem("basket"));
    if (basket == null) {
      localStorage.setItem("basket", JSON.stringify([]));
    }
  }
}

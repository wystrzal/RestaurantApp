import { Component, OnInit, HostListener } from "@angular/core";
import { BasketService } from "../shared/basket.service";
import { BasketItemModel } from "../shared/models/basketItem.model";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.scss"],
})
export class NavComponent implements OnInit {
  basketItems: BasketItemModel[];
  amountInBasket: number;
  navStyle = 25;

  @HostListener("window:scroll", ["$event"])
  doSomething(event) {
    if (window.pageYOffset > 0) {
      setTimeout(() => {
        this.navStyle = 10;
      }, 200);
    } else {
      setTimeout(() => {
        this.navStyle = 25;
      }, 200);
    }
  }

  constructor(private basketService: BasketService) {}

  ngOnInit() {
    this.amountInBasket = JSON.parse(localStorage.getItem("basket")).length;

    this.basketService.getBasketItems.subscribe((basketItems) => {
      this.basketItems = basketItems;
      this.amountInBasket = basketItems.length;
    });
  }
}

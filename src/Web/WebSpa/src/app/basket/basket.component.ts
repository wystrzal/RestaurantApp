import { Component, OnInit } from "@angular/core";
import { BasketItemModel } from "../shared/models/basketItem.model";
import { BasketService } from "../shared/basket.service";

@Component({
  selector: "app-basket",
  templateUrl: "./basket.component.html",
  styleUrls: ["./basket.component.scss"],
})
export class BasketComponent implements OnInit {
  basketItems: BasketItemModel[];
  totalPrice: number = 0;

  constructor(private basketService: BasketService) {}

  ngOnInit() {
    this.basketItems = JSON.parse(localStorage.getItem("basket"));
    this.countTotalPrice();
  }

  deleteItem(itemIndex: number) {
    this.basketItems.splice(itemIndex, 1);
    localStorage.setItem("basket", JSON.stringify(this.basketItems));
    this.basketService.getBasketItems.next(this.basketItems);
    this.countTotalPrice();
  }

  changeQuantity(itemIndex: number, action: string) {
    if (action == "plus") {
      this.basketItems[itemIndex].quantity += 1;
    } else {
      this.basketItems[itemIndex].quantity -= 1;
    }
    if (this.basketItems[itemIndex].quantity == 0) {
      this.basketItems.splice(itemIndex, 1);
      this.basketService.getBasketItems.next(this.basketItems);
    }
    this.countTotalPrice();
    localStorage.setItem("basket", JSON.stringify(this.basketItems));
  }

  countTotalPrice() {
    this.totalPrice = 0;
    this.basketItems.forEach((b) => {
      if (b.quantity > 1) {
        for (let i = 0; i < b.quantity; i++) {
          this.totalPrice += b.itemPrice;
        }
      } else {
        this.totalPrice += b.itemPrice;
      }
    });
  }
}

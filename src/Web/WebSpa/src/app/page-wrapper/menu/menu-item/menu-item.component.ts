import { Component, OnInit } from "@angular/core";
import { MenuService } from "../menu.service";
import { Paggination } from "../menu-models/paggination.model";
import { BasketItemModel } from "src/app/shared/models/basketItem.model";
import { BasketService } from "src/app/shared/basket.service";

@Component({
  selector: "app-menu-item",
  templateUrl: "./menu-item.component.html",
  styleUrls: ["./menu-item.component.scss"],
})
export class MenuItemComponent implements OnInit {
  basketItems: BasketItemModel[];
  menuItems: Paggination;
  type: number;

  constructor(
    private menuService: MenuService,
    private basketService: BasketService
  ) {}

  ngOnInit() {
    this.menuService.getMenu.subscribe((type) => {
      this.type = type;
      this.getMenuItems(type, 0);
    });

    this.basketItems = [];
    if (JSON.parse(localStorage.getItem("basket")) != null) {
      this.basketItems.push(...JSON.parse(localStorage.getItem("basket")));
    }
  }

  getMenuItems(typeId: number, pageIndex: number) {
    this.menuService.getMenuItems(typeId, pageIndex).subscribe((items) => {
      this.menuItems = items;
    });
  }

  changePage($event: any) {
    this.getMenuItems(this.type, $event.page - 1);
  }

  addToBasket(index: number) {
    const basketItemToAdd: BasketItemModel = {
      productId: this.menuItems.data[index].id,
      productName: this.menuItems.data[index].name,
      productPrice: this.menuItems.data[index].price,
      quantity: 1,
    };

    if (this.basketItems.length == 0) {
      this.basketItems.push(basketItemToAdd);
      localStorage.setItem("basket", JSON.stringify(this.basketItems));
    } else {
      let basketItem: any;

      basketItem = this.basketItems.find(
        (b) => b.productId == basketItemToAdd.productId
      );

      if (basketItem == null) {
        this.basketItems.push(basketItemToAdd);
        localStorage.setItem("basket", JSON.stringify(this.basketItems));
      } else {
        const basketIndex = this.basketItems.findIndex(
          (b) => b.productId == basketItemToAdd.productId
        );

        this.basketItems[basketIndex].quantity += 1;
        localStorage.setItem("basket", JSON.stringify(this.basketItems));
      }
    }
    alert("Successfully added!");
    this.basketService.getBasketItems.next(this.basketItems);
  }
}

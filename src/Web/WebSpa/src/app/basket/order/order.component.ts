import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { OrderService } from "./order.service";
import { OrderItemModel } from "./order-models/orderItem.model";
import { OrderModel } from "./order-models/order.model";
import { BasketService } from "src/app/shared/basket.service";
import { BasketItemModel } from "src/app/shared/models/basketItem.model";
import { ErrorService } from "src/app/shared/error.service";

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.scss"],
})
export class OrderComponent implements OnInit {
  @Input() totalPrice: number = 0;
  @Input() orderItems: OrderItemModel[] = [];
  order: OrderModel = {
    phoneNumber: "",
    address: "",
    totalPrice: 0,
    orderItems: [],
  };

  constructor(
    private orderService: OrderService,
    private basketService: BasketService,
    private errorService: ErrorService
  ) {}

  ngOnInit() {}

  submitOrder() {
    this.errorService.confirm("Are you sure you want buy?", () => {
      this.order.orderItems.push(...this.orderItems);
      this.order.totalPrice = this.totalPrice;
      this.orderService.submitOrder.next(false);

      this.orderService.newOrder(this.order).subscribe(
        () => {
          this.orderItems = [];

          localStorage.setItem(
            "basket",
            JSON.stringify(this.orderItems as BasketItemModel[])
          );

          this.basketService.getBasketItems.next(
            this.orderItems as BasketItemModel[]
          );
        },
        (error) => {
          this.errorService.newError(error);
        }
      );
    });
  }
}

import { Component, OnInit, Input } from "@angular/core";
import { OrderService } from "./order.service";
import { OrderItemModel } from "./order-models/orderItem.model";
import { OrderModel } from "./order-models/order.model";

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.scss"],
})
export class OrderComponent implements OnInit {
  @Input() orderItems: OrderItemModel[] = [];
  order: OrderModel = {
    phoneNumber: "",
    address: "",
    totalPrice: 0,
    orderItems: [],
  };

  constructor(private orderService: OrderService) {}

  ngOnInit() {}

  submitOrder() {
    this.order.orderItems.push(...this.orderItems);
    this.orderService.submitOrder.next(false);
  }
}

import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Subject } from "rxjs";
import { environment } from "src/environments/environment";
import { OrderModel } from "./order-models/order.model";

@Injectable({
  providedIn: "root",
})
export class OrderService {
  apiOrder = environment.apiOrder;
  submitOrder = new Subject<boolean>();

  constructor(private http: HttpClient) {}

  newOrder(order: OrderModel) {
    return this.http.post(this.apiOrder + "client", order);
  }
}

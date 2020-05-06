import { OrderItemModel } from "./orderItem.model";

export interface OrderModel {
  phoneNumber: string;
  address: string;
  totalPrice: number;
  orderItems: OrderItemModel[];
}

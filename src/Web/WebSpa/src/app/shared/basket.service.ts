import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { BasketItemModel } from "./models/basketItem.model";

@Injectable({
  providedIn: "root",
})
export class BasketService {
  getBasketItems = new Subject<BasketItemModel[]>();

  constructor() {}
}

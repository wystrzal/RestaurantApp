import { Injectable } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class OrderService {
  submitOrder = new Subject<boolean>();

  constructor(private http: HttpClientModule) {}
}

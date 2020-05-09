import { NgModule } from "@angular/core";
import { BasketComponent } from "./basket.component";
import { OrderComponent } from "./order/order.component";
import { BasketRoutes } from "./basket.routing";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [BasketComponent, OrderComponent],
  imports: [SharedModule, BasketRoutes],
})
export class BasketModule {}

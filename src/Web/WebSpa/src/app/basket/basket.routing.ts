import { Routes, RouterModule } from "@angular/router";
import { BasketComponent } from "./basket.component";

const routes: Routes = [{ path: "basket", component: BasketComponent }];

export const BasketRoutes = RouterModule.forChild(routes);

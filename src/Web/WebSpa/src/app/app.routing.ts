import { Routes } from "@angular/router";

import { BasketComponent } from "./basket/basket.component";

export const AppRoutes: Routes = [
  {
    path: "",
    loadChildren: "./page-wrapper/page-wrapper.module#PageWrapperModule",
  },
  {
    path: "basket",
    component: BasketComponent,
  },
];

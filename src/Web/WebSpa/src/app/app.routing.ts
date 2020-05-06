import { Routes } from "@angular/router";

export const AppRoutes: Routes = [
  {
    path: "",
    loadChildren: "./page-wrapper/page-wrapper.module#PageWrapperModule",
  },
  {
    path: "basket",
    loadChildren: "./basket/basket.module.ts#BasketModule",
  },
];

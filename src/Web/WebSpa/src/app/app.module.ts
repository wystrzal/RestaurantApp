import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { BasketComponent } from "./basket/basket.component";
import { AppRoutes } from "./app.routing";
import { PageWrapperModule } from "./page-wrapper/page-wrapper.module";

@NgModule({
  declarations: [AppComponent, NavComponent, BasketComponent],
  imports: [
    PageWrapperModule,
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

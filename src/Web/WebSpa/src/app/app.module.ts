import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppRoutes } from "./app.routing";
import { PageWrapperModule } from "./page-wrapper/page-wrapper.module";
import { BasketModule } from "./basket/basket.module";
import { SharedModule } from "./shared/shared.module";

@NgModule({
  declarations: [AppComponent, NavComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    HttpClientModule,
    PageWrapperModule,
    BasketModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

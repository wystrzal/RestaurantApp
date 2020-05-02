import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HomeComponent } from "./home/home.component";
import { AboutComponent } from "./about/about.component";
import { MenuComponent } from "./menu/menu.component";
import { ContactComponent } from "./contact/contact.component";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { MenuItemComponent } from "./menu/menu-item/menu-item.component";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    AboutComponent,
    MenuComponent,
    ContactComponent,
    MenuItemComponent,
  ],
  imports: [BrowserModule, PaginationModule.forRoot(), HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PageWrapperComponent } from "./page-wrapper.component";
import { HomeComponent } from "./home/home.component";
import { AboutComponent } from "./about/about.component";
import { MenuComponent } from "./menu/menu.component";
import { ContactComponent } from "./contact/contact.component";
import { MenuItemComponent } from "./menu/menu-item/menu-item.component";
import { StartRoutes } from "./start.routing";
import { FormsModule } from "@angular/forms";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [
    PageWrapperComponent,
    HomeComponent,
    AboutComponent,
    MenuComponent,
    ContactComponent,
    MenuItemComponent,
  ],
  imports: [SharedModule, StartRoutes, FormsModule, PaginationModule.forRoot()],
})
export class PageWrapperModule {}

import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "./home.component";

import { HomeRoutingModule } from "./home-routing.module";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, RouterModule, HomeRoutingModule, SharedModule],
})
export class HomeModule {}

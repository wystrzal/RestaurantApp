import { Component, OnInit } from "@angular/core";
import { MenuService } from "./menu.service";
import { MenuTypeModel } from "./menu-models/menuType.model";
import { ErrorService } from "src/app/shared/error.service";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.scss"],
})
export class MenuComponent implements OnInit {
  type: number;
  menuTypes: MenuTypeModel;

  constructor(
    private menuService: MenuService,
    private errorService: ErrorService
  ) {}

  ngOnInit() {
    this.getMenuTypes();
    this.type = 0;
  }

  getMenuTypes() {
    this.menuService.getMenuTypes().subscribe(
      (types) => {
        this.menuTypes = types;
      },
      (error) => {
        this.errorService.newError(error);
      }
    );
  }

  selectMenu() {
    this.menuService.getMenu.next(this.type);
  }
}

import { Component, OnInit, Input } from "@angular/core";
import { MenuService } from "../menu.service";
import { MenuItemModel } from "../menu-models/menuItem.model";
import { Paggination } from "../menu-models/paggination.model";

@Component({
  selector: "app-menu-item",
  templateUrl: "./menu-item.component.html",
  styleUrls: ["./menu-item.component.scss"],
})
export class MenuItemComponent implements OnInit {
  menuItems: Paggination;
  type: number;

  constructor(private menuService: MenuService) {}

  ngOnInit() {
    this.menuService.getMenu.subscribe((type) => {
      this.type = type;
      this.getMenuItems(type, 0);
    });
  }

  getMenuItems(typeId: number, pageIndex: number) {
    this.menuService.getMenuItems(typeId, pageIndex).subscribe((items) => {
      this.menuItems = items;
    });
  }

  changePage($event: any) {
    this.getMenuItems(this.type, $event.page - 1);
  }
}

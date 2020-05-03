import { MenuItemModel } from "./menuItem.model";

export interface Paggination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: MenuItemModel;
}

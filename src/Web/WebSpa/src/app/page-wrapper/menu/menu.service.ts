import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable, Subject } from "rxjs";
import { MenuItemModel } from "./menu-models/menuItem.model";
import { MenuTypeModel } from "./menu-models/menuType.model";
import { NgIf } from "@angular/common";
import { Paggination } from "./menu-models/paggination.model";

@Injectable({
  providedIn: "root",
})
export class MenuService {
  menuApi = environment.apiMenu;
  getMenu = new Subject<number>();

  constructor(private http: HttpClient) {}

  getMenuItems(typeId: number, pageIndex: number): Observable<Paggination> {
    let params = new HttpParams();
    params = params.append("pageIndex", pageIndex.toString());

    return this.http.get<Paggination>(this.menuApi + "type/" + typeId, {
      params,
    });
  }

  getMenuTypes(): Observable<MenuTypeModel> {
    return this.http.get<MenuTypeModel>(this.menuApi + "types");
  }
}

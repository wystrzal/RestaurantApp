import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class MenuService {
  menuApi = environment.apiMenu;

  constructor(private http: HttpClient) {}

  getMenuTypes(typeId: number) {
    this.http.get();
  }
}

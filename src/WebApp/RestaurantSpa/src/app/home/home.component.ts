import { Component, OnInit } from "@angular/core";
import { AuthService } from "../core/auth/auth.service";

@Component({
  selector: "app-index",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent implements OnInit {
  userLogin: any = {};

  constructor(private authService: AuthService) {}

  ngOnInit() {}
}

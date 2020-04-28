import { Component, OnInit } from "@angular/core";
import { AuthService } from "src/app/core/auth/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  title = "Login";

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login();
  }

  ngOnInit() {}
}

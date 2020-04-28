import { Component, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { AuthService } from "src/app/core/auth/auth.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"],
})
export class HeaderComponent implements OnInit {
  name: string;
  isAuthenticated: boolean;
  subscription: Subscription;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.subscription = this.authService.authNavStatus$.subscribe(
      (status) => (this.isAuthenticated = status)
    );
    this.name = this.authService.name;
  }

  async signout() {
    await this.authService.signout();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}

import { Component, OnInit } from "@angular/core";
import { AuthService } from "src/app/core/auth/auth.service";
import { UserRegistration } from "src/app/models/user.registration";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"],
})
export class RegisterComponent implements OnInit {
  success: boolean;
  error: string;
  userRegistration: UserRegistration = { name: "", email: "", password: "" };
  submitted: boolean = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {}

  onSubmit() {
    this.authService.register(this.userRegistration).subscribe(
      () => {
        {
          this.success = true;
        }
      },
      (error) => {
        this.error = error;
      }
    );
  }
}

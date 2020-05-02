import { Component, OnInit, HostListener } from "@angular/core";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.scss"],
})
export class NavComponent implements OnInit {
  navStyle = 25;
  @HostListener("window:scroll", ["$event"])
  doSomething(event) {
    if (window.pageYOffset > 0) {
      setTimeout(() => {
        this.navStyle = 10;
      }, 200);
    } else {
      setTimeout(() => {
        this.navStyle = 25;
      }, 200);
    }
  }

  constructor() {}

  ngOnInit() {}
}

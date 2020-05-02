import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.scss"],
})
export class MenuComponent implements OnInit {
  currentPage: number;

  ingriedent: string[] = ["1", "2", "3", "4", "5"];

  ingriedents: string[] = [
    "Tomato",
    "Meat",
    "Tomato",
    "Meat",
    "Chicken",
    "Tomato",
    "Meat",
  ];

  constructor() {}

  ngOnInit() {}
}

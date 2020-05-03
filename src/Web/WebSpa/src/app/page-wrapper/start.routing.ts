import { Routes, RouterModule } from "@angular/router";
import { PageWrapperComponent } from "./page-wrapper.component";

const routes: Routes = [{ path: "", component: PageWrapperComponent }];

export const StartRoutes = RouterModule.forChild(routes);

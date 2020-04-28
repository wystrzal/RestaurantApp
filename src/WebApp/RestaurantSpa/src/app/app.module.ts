import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { AuthCallbackComponent } from "./auth-callback/auth-callback.component";
import { CoreModule } from "./core/core.module";
import { HomeModule } from "./home/home.module";
import { AccountModule } from "./account/account.module";
import { ShellModule } from "./shell/shell.module";
import { SharedModule } from "./shared/shared.module";
import { AppRoutingModule } from "./app-routing.module";
import { TopSecretModule } from "./top-secret/top-secret.module";

@NgModule({
  declarations: [AppComponent, AuthCallbackComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    AccountModule,
    TopSecretModule,
    AppRoutingModule,
    ShellModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

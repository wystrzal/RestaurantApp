import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { ErrorInterceptorProvider } from "./error.interceptor";
import { ErrorModalComponent } from "./error-modal/error-modal.component";
import { ModalModule } from "ngx-bootstrap/modal";

@NgModule({
  declarations: [ErrorModalComponent],
  imports: [CommonModule, FormsModule, ModalModule.forRoot()],
  exports: [CommonModule, FormsModule, ModalModule],
  providers: [ErrorInterceptorProvider],
  entryComponents: [ErrorModalComponent],
})
export class SharedModule {}

import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ConfigService } from "../shared/config.service";

@Injectable({
  providedIn: "root",
})
export class TopSecretService {
  constructor(private http: HttpClient, private configService: ConfigService) {}

  fetchTopSecretData(token: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: token,
      }),
    };

    return this.http.get(
      this.configService.resourceApiURI + "/order",
      httpOptions
    );
    // .pipe(catchError(this.handleError));
  }
}

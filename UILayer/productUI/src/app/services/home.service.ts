import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  configUrl: any;
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient, private authService: AuthService) {
    this.configUrl = authService.getConfigUrl();
    this.headers = this.headers.set("Authorization", "Bearer " + authService.getToken());
   }

   public loginGet = () => {
    return this.http.get<string>(this.configUrl + "login/get?username=cuong&password=1", { headers: this.headers });
  }
}

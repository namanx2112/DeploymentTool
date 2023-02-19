import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthResponse } from '../interfaces/auth-response';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthRequest } from '../interfaces/auth-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  configUrl: string;
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient,private route:ActivatedRoute, public router: Router) { 
    this.configUrl = "./api/";
    localStorage.setItem("configUrl", this.configUrl);
  }

  public loginUser = (userName: string, userPassword: string) => {
    return this.http.get<AuthResponse>(this.configUrl + "token/Get?username=cuong&password=1");
  }

  signIn(user: AuthRequest) {
    return this.http.post<AuthResponse>(this.configUrl + "token/get", user, {headers: this.headers})
      .subscribe((res: AuthResponse) => {
        localStorage.setItem('access_token', res.Token);
        this.router.navigate(['./home'],{skipLocationChange: true, relativeTo:this.route});
      });
  }

  getHttpHeaders(): HttpHeaders{
    let tHeader = new HttpHeaders().set('Content-Type', 'application/json').set("Authorization", "Bearer " + this.getToken());
    return tHeader;
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  getConfigUrl(){
    return localStorage.getItem('configUrl');
  }
}

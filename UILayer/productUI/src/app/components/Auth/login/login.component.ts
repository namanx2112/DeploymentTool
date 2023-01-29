import { Component } from '@angular/core';
import { AuthResponse } from 'src/app/interfaces/auth-response';
import { AuthService } from 'src/app/services/auth.service';
import { AuthRequest } from 'src/app/interfaces/auth-request';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  authResp?: AuthResponse;
  auth: AuthRequest;
  constructor(private authService: AuthService){
    this.auth = {UserName: "test", Password: "test"};
  }

  logMeIn(){
    this.authService.signIn(this.auth);
  }
}

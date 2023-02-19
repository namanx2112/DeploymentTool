import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BrandModel } from '../interfaces/models';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class BrandServiceService {

  configUrl: any;
  constructor(private http: HttpClient, private authService: AuthService) { 
    this.configUrl = authService.getConfigUrl();
  }

  CreateBrand (request: any) {
    return this.http.post<BrandModel>(this.configUrl + "Brand/CreateBrand", request, { headers: this.authService.getHttpHeaders() });
  }
}

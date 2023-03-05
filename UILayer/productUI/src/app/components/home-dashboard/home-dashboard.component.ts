import { Component } from '@angular/core';
import { BrandModel } from 'src/app/interfaces/models';
import { BrandServiceService } from 'src/app/services/brand-service.service';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-home-dashboard',
  templateUrl: './home-dashboard.component.html',
  styleUrls: ['./home-dashboard.component.css']
})
export class HomeDashboardComponent {
  brands: BrandModel[];
  constructor(private homeService: HomeService, private brandService: BrandServiceService) {
    this.getBrands();
  }

  getBrands() {
    this.brands = this.brandService.GetAllBrands();
  }
}

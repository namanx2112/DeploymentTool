import { Component } from '@angular/core';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private homeService: HomeService){

  }

  getValue(){
      this.homeService.loginGet().subscribe((res: string) => {
          alert(res);
      });
  }
}

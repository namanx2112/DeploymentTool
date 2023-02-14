import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HomeTab } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-tab-body',
  templateUrl: './tab-body.component.html',
  styleUrls: ['./tab-body.component.css']
})
export class TabBodyComponent {
  @Input() curTab: HomeTab;
  secondPart: string;

  constructor(private route:ActivatedRoute, public router: Router){
    this.secondPart = "table";
  }

  OpenNew(){
    this.secondPart = "newEdit"
  }
}

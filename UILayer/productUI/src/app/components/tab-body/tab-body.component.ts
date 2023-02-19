import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Dictionary } from 'src/app/interfaces/commons';
import { HomeTab } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-tab-body',
  templateUrl: './tab-body.component.html',
  styleUrls: ['./tab-body.component.css']
})
export class TabBodyComponent {
  @Input() curTab: HomeTab;
  secondPart: string;
  curControlVals: Dictionary<string> = {};

  constructor(private route:ActivatedRoute, public router: Router){
    this.secondPart = "table";
  }

  OpenNew(){
    this.secondPart = "newEdit"
  }

  onSubmit(controlVals: FormGroup){

  }

  returnBack(resp: any){
    alert("Saved");
    this.secondPart = "table";
  }
}

import { Component, Input } from '@angular/core';
import { Fields, HomeTab } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.css']
})
export class ControlsComponent {
  @Input() curTab: HomeTab;
  constructor(){
    
  }

  getErrorMessage(){
    return "Error";
  }
}

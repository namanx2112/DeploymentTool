import { Component, Input } from '@angular/core';
import { HomeTab } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-new-edit-object',
  templateUrl: './new-edit-object.component.html',
  styleUrls: ['./new-edit-object.component.css']
})
export class NewEditObjectComponent {
  @Input() curTab: HomeTab;
  constructor(){
    
  }
}

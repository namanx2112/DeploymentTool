import { Component, Input } from '@angular/core';
import { HomeTab } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-tab-body',
  templateUrl: './tab-body.component.html',
  styleUrls: ['./tab-body.component.css']
})
export class TabBodyComponent {
  @Input() curTab: HomeTab;

  constructor(){}
}

import { Component, Input } from '@angular/core';
import { HomeTab } from 'src/app/interfaces/home-tab';
import { Dictionary } from 'src/app/interfaces/commons';
import { FormGroup } from '@angular/forms';
import { BrandServiceService } from 'src/app/services/brand-service.service';
import { BrandModel } from 'src/app/interfaces/models';

@Component({
  selector: 'app-new-edit-object',
  templateUrl: './new-edit-object.component.html',
  styleUrls: ['./new-edit-object.component.css']
})
export class NewEditObjectComponent {
  @Input() curTab: HomeTab;
  curControlVals: Dictionary<string> = {};
  constructor( private brandService: BrandServiceService){
    
  }

  onSubmit(controlVals: FormGroup){
    this.brandService.CreateBrand(controlVals.value).subscribe((resp: BrandModel)=>{
        console.log(resp);
    })
  }
}

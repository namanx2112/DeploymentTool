import { Component } from '@angular/core';
import { FieldType, HomeTab, TabType } from 'src/app/interfaces/home-tab';

@Component({
  selector: 'app-home-tab',
  templateUrl: './home-tab.component.html',
  styleUrls: ['./home-tab.component.css']
})
export class HomeTabComponent {

  tabsArray: HomeTab[];
  constructor(){
      this.tabsArray = [
        {
          tab_name: "Users",
          tab_header: "Users search",
          tab_type: TabType.Users,
          tab_unique_name: "",
          fields: [
            {
              field_name: "Name",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.text,
              field_placeholder: "Enter Name",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Mobile",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.text,
              field_placeholder: "Enter Name",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Email",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.email,
              field_placeholder: "Enter mail",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "User DOB",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.date,
              field_placeholder: "Enter DOB",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Created Time",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.time,
              field_placeholder: "Enter Created Time",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "User Time",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.dropdown,
              field_placeholder: "Enter User Roles",
              regex_validation: "",
              mandatory: false,
              options: [
                {
                  optionDisplayName: "Admin",
                  optionIndex: 0,
                  optionOrder: 1
                },
                {
                  optionDisplayName: "User",
                  optionIndex: 1,
                  optionOrder: 2
                },
                {
                  optionDisplayName: "Vendor",
                  optionIndex: 2,
                  optionOrder: 3
                }
              ]
            }
          ]
        },
        {
          tab_name: "Brands",
          tab_header: "Brands search",
          tab_type: TabType.Brands,
          tab_unique_name: "",
          fields: [
            {
              field_name: "Brands Name",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.text,
              field_placeholder: "Enter Brands Name",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Brands Mobile",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.text,
              field_placeholder: "Enter Brands mobile",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Brands Email",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.email,
              field_placeholder: "Enter Brands mail",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Brands DOB",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.date,
              field_placeholder: "Brands DOB",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Brands Created Time",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.time,
              field_placeholder: "Brands Created Time",
              regex_validation: "",
              mandatory: false
            },
            {
              field_name: "Brands Role",
              fieldUniqeName: "ABCD",
              invalid: false,
              field_type: FieldType.dropdown,
              field_placeholder: "Brands User Roles",
              regex_validation: "",
              mandatory: false,
              options: [
                {
                  optionDisplayName: "Admin",
                  optionIndex: 0,
                  optionOrder: 1
                },
                {
                  optionDisplayName: "User",
                  optionIndex: 1,
                  optionOrder: 2
                },
                {
                  optionDisplayName: "Vendor",
                  optionIndex: 2,
                  optionOrder: 3
                }
              ]
            }
          ]
        },
        {
          tab_name: "Franchises",
          tab_header: "Franchises search",
          tab_type: TabType.Franchise,
          tab_unique_name: "",
          fields: []
        },
        {
          tab_name: "Stores",
          tab_header: "Stores search",
          tab_type: TabType.Store,
          tab_unique_name: "",
          fields: []
        },
        {
          tab_name: "Tech Components",
          tab_header: "Tech Components search",
          tab_type: TabType.TechComponent,
          tab_unique_name: "",
          fields: []
        },
        {
          tab_name: "Vendors",
          tab_header: "Vendors search",
          tab_type: TabType.Vendor,
          tab_unique_name: "",
          fields: []
        },
        {
          tab_name: "Tech Component Tools",
          tab_header: "Tech Component Tools search",
          tab_type: TabType.TechComponentTools,
          tab_unique_name: "",
          fields: []
        },
        {
          tab_name: "Analytics",
          tab_header: "Analytics search",
          tab_type: TabType.Analytics,
          tab_unique_name: "",
          fields: []
        }
      ]
  }
}

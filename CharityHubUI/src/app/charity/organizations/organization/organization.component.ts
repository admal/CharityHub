import { Component, Input } from '@angular/core';
import { OrganizationType } from '../../../core/services/user-service/models/organization.enum';
import { OrganizationModel } from './../../../core/services/charity-service/models/organization-model.type';

@Component({  
  selector: 'organization',
  templateUrl: './organization.component.html', 
  styleUrls: ['./organization.component.scss', '../../charity.scss' ]
})
export class OrganizationComponent { 
  @Input() organizationModel: OrganizationModel;

  constructor() {
  } 

  getOrganizationType() {
      switch(this.organizationModel.organizationType) {
          case OrganizationType.Profit:
              return "Profit";
          case OrganizationType.NonProfit:
              return "Non profit";
      }
  }
}

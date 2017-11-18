import { Component } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { OrganizationModel } from './../../../core/services/charity-service/models/organization-model.type';
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';

@Component({
  selector: 'organization-list', 
  templateUrl: './organization-list.component.html',
  styleUrls: ['./orgranization-list.component.scss']  
})
export class OrganizationListComponent {  
  organizations: OrganizationModel[]; 

  isLoading = true;

  constructor(private readonly myCharityService: MyCharityService) {
  }

  ngOnInit() {
    this.myCharityService.getOrganizations()
      .then((organizations: OrganizationModel[]) => {
        this.organizations = organizations;
        this.isLoading = false;
      })
  }

}

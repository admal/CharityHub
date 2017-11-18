import { Component } from '@angular/core';
import { MyCharityService } from "../../../core/services/charity-service/myCharityService.service";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { OrganizationModel } from './../../../core/services/charity-service/models/organization-model.type';

@Component({
  selector: 'organization-list', 
  templateUrl: './organization-list.component.html',
  styleUrls: ['./orgranization-list.component.scss'] 
})
export class OrganizationListComponent {  
  organizations: OrganizationModel[]; 

  constructor(private readonly myCharityService: MyCharityService) {
  }

  ngOnInit() {
    this.myCharityService.getOrganizations()
      .then((organizations: OrganizationModel[]) => {
        this.organizations = organizations;
      })
  }

}

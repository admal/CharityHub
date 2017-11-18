import { Component } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { UserService } from '../../core/services/user-service/user.service';
import { MyCharityService } from '../../core/services/charity-service/my-charity.service';
import { OrganizationModel } from '../../core/services/charity-service/models/organization-model.type';
import { OrganizationType } from '../../core/services/user-service/models/organization.enum';

@Component({
    selector: 'my-organization',
    templateUrl: './my-organization.component.html',
    styleUrls: ['my-organization.component.scss']
})
export class MyOrganizationComponent implements OnInit{
    
    myOrganization: OrganizationModel;
    isLoading = true;
    
    constructor(
        private readonly myCharityService: MyCharityService,
        private readonly userService: UserService
    ) { } 

    ngOnInit() {
        let userCharityId = this.userService.user.organizationId;
        this.myCharityService.getCharity(userCharityId)
            .then(response => {
                this.myOrganization = response;
                this.isLoading = false;
            });
    }

    getCategory() {
        switch(this.myOrganization.organizationType) {
            case OrganizationType.Profit:
                return "Profit";
            case OrganizationType.NonProfit:
                return "Non profit";
        }
    }
}
 
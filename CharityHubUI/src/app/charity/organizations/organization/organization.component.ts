import { Component, Input } from '@angular/core';
import { OrganizationType } from '../../../core/services/user-service/models/organization.enum';
import { OrganizationModel } from './../../../core/services/charity-service/models/organization-model.type';
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';
import { UserService } from '../../../core/services/user-service/user.service';

@Component({
    selector: 'organization',
    templateUrl: './organization.component.html',
    styleUrls: ['./organization.component.scss', '../../charity.scss']
})
export class OrganizationComponent {
    @Input() organizationModel: OrganizationModel;

    constructor(
        private readonly myCharityService: MyCharityService,
        public readonly userService: UserService
    ) {
    }

    getOrganizationType() {
        switch (this.organizationModel.organizationType) {
            case OrganizationType.Profit:
                return "Profit";
            case OrganizationType.NonProfit:
                return "Non profit";
        }
    }

    observeOrganization() {
        let userId = this.userService.user.id;
        this.myCharityService.observeCharity(userId, this.organizationModel.id)
            .then(() => {
                this.organizationModel.isObserving = true;
            });
    }

    stopObserveOrganization() {
        let userId = this.userService.user.id;
        this.myCharityService.stopObserveCharity(userId, this.organizationModel.id)
            .then(() => {
                this.organizationModel.isObserving = false;
            });
    }
}

import { Component, ViewEncapsulation, Input } from '@angular/core';
import { MyCharityService } from "../../../core/services/charity-service/my-charity.service";
import { ManageEventModel } from "../../../core/services/charity-service/models/manage-event-model.type";

@Component({
  selector: 'user-management',
  templateUrl: './user-management.html',
  styleUrls: ['./user-management.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class UserManagementComponent {
  manageEventModel: ManageEventModel;

  @Input() eventId: number;

  constructor(private readonly charityService: MyCharityService) {

  }

  ngOnInit() {
    this.charityService.getEventDetails(this.eventId)
      .then((eventModel) => {
        this.manageEventModel = eventModel;
      });
  }
}

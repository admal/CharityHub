import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';
import { UserService } from '../../../core/services/user-service/user.service';

@Component({
  selector: '<new-event></new-event>',
  templateUrl: './new-event.html',
  styleUrls: ['../../charity.scss'] 
})
export class NewEventComponent {
  newEventModel: EventModel;

  constructor(
    private readonly myCharityService: MyCharityService,
    private readonly userService: UserService
  ) {
    this.newEventModel = new EventModel();
  }

  onSubmit(form: NgForm) {
      this.newEventModel.charityId = this.userService.user.organizationId;
      this.myCharityService.addEvent(this.newEventModel)
        .then(() => {
            console.log('event sie dodal djud');
        });
  }

  getModel() {
    return JSON.stringify(this.newEventModel);
  }
}

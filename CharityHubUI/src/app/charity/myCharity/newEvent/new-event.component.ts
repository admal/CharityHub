import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';
import { UserService } from '../../../core/services/user-service/user.service';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

@Component({
  selector: '<new-event></new-event>',
  templateUrl: './new-event.html',
  styleUrls: ['../../charity.scss'] 
})
export class NewEventComponent {
  newEventModel: EventModel; 

  constructor(
    private readonly myCharityService: MyCharityService,
    private readonly userService: UserService,
    public snackBar: MatSnackBar
  ) {
    this.newEventModel = new EventModel();
  }

  onSubmit(form: NgForm) {
      this.newEventModel.charityId = this.userService.user.organizationId;
      
      this.myCharityService.addEvent(this.newEventModel)
        .then(() => {
          this.newEventModel = new EventModel();
          let config = new MatSnackBarConfig();
          config.duration = 2000;
          this.snackBar.open('Wydarzenie zostało dodane', undefined, config);
          form.reset();
        });
  }

  getModel() {
    return JSON.stringify(this.newEventModel);
  }
}

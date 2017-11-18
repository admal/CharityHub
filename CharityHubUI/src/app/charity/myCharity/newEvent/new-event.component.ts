import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';
import { UserService } from '../../../core/services/user-service/user.service';
import { MatSnackBar } from '@angular/material';
import { AppComponent } from '../../../app.component';

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
          this.snackBar.openFromComponent(AppComponent, {
            duration: 1000,
          });
        });
  }

  getModel() {
    return JSON.stringify(this.newEventModel);
  }
}

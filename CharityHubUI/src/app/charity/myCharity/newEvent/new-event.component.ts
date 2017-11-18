import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from "../../../core/services/charity-service/myCharityService.service";

@Component({
  selector: '<new-event></new-event>',
  templateUrl: './new-event.html',
  styleUrls: ['../../charity.scss']
})
export class NewEventComponent {
  newEventModel: EventModel;

  constructor() {
    this.newEventModel = new EventModel();
  }

  onSubmit(form: NgForm) {
    console.log(this.newEventModel);
  }
}

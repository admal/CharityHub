import { Component } from '@angular/core';
import { NewEventModel } from "./new-event-model.type";
import { NgForm } from "@angular/forms/src/forms";

@Component({
  selector: '<new-event></new-event>',
  templateUrl: './new-event.html',
})
export class NewEventComponent {
  newEventModel: NewEventModel;

  constructor() {
    this.newEventModel = new NewEventModel();
  }

  onSubmit(form: NgForm) {
    console.log(this.newEventModel);
  }
}

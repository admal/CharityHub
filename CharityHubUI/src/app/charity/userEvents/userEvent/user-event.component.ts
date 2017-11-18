import { Component, Input } from "@angular/core";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";

@Component({
  selector: 'user-event',
  templateUrl: './user-event.html',
  styleUrls: ['../../charity.scss']
})
export class UserEventComponent {
  @Input() eventModel: EventModel;
  @Input() isSearchEvent: boolean;

  constructor() {

  }



}

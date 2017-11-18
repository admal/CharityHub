import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { EventType } from "../../../core/services/charity-service/models/event-type.type";

@Component({
  selector: 'event',
  templateUrl: './event.html',
})
export class EventComponent {
  @Input() eventModel: EventModel;

  constructor() {
  }
}

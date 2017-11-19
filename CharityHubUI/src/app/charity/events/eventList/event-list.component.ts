import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';

@Component({
  selector: 'event-list', 
  templateUrl: './event-list.html',
  styleUrls: ['../../charity.scss']
})
export class EventListComponent {
  
  @Input() userEvents: EventModel[];

  constructor(
    private readonly myCharityService: MyCharityService
  ) {

  }

}

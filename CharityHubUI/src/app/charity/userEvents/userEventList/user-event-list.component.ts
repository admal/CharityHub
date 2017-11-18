import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';

@Component({
  selector: 'user-event-list',
  templateUrl: './user-event-list.html',
  styleUrls: ['../../charity.scss']
})
export class UserEventListComponent {
  @Input() areSearchEvents: boolean;

  events: EventModel[];

  constructor(private readonly myCharityService: MyCharityService) {
  }

  ngOnInit() {
    this.myCharityService.getUserEvents()
      .then((events: EventModel[]) => {
        this.events = events;
      })
  }
}

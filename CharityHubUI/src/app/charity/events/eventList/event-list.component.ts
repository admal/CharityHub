import { Component } from '@angular/core';
import { MyCharityService } from "../../../core/services/charity-service/myCharityService.service";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";

@Component({
  selector: 'event-list', 
  templateUrl: './event-list.html'
  styleUrls: ['../../charity.scss']
})
export class EventListComponent {
  userEvents: EventModel[];

  constructor(private readonly myCharityService: MyCharityService) {

  }

  ngOnInit() {
    this.myCharityService.getUserEvents()
      .then((events: EventModel[]) => {
        this.userEvents = events;
      })
  }

}

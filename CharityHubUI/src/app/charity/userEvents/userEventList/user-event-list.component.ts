import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';
import { UserService } from '../../../core/services/user-service/user.service';

@Component({
  selector: 'user-event-list',
  templateUrl: './user-event-list.html',
  styleUrls: ['../../charity.scss']
})
export class UserEventListComponent {
  @Input() areSearchEvents: boolean;

  events: EventModel[];

  constructor(
    private readonly myCharityService: MyCharityService,
    private readonly userService: UserService
  ) {
  }

  ngOnInit() {
    let isLoggedIn = this.userService.isLoggedIn();
    if (isLoggedIn && this.areSearchEvents) {
      this.myCharityService.getUserEventsSigned(this.userService.user.id, this.areSearchEvents)
        .then((events: EventModel[]) => {
          this.events = events; 
        })
    } else if (isLoggedIn && this.areSearchEvents === false) {
      this.myCharityService.getUserAvailableEvents(this.userService.user.id)
        .then((events: EventModel[]) => {
          this.events = events;
        })
    } else {
      this.myCharityService.getEvents()
        .then((events: EventModel[]) => {
          this.events = events;
        })
    }
  }
}

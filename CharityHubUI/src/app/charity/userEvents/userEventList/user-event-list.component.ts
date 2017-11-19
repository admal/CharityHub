import { Component, Input, EventEmitter, Output } from '@angular/core';
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
  @Input() arePending: boolean;
  events: EventModel[];

  @Output() onRefreshEvents = new EventEmitter<void>();

  constructor(
    private readonly myCharityService: MyCharityService,
    private readonly userService: UserService
  ) {
  }

  onAddedEvent(event) {
    this.onEventAdded();
  }

  onEventAdded() {
    this.onRefreshEvents.emit();
  }

  ngOnInit() {
     this.initEvents();
  }

  initEvents() {
    let isLoggedIn = this.userService.isLoggedIn();
    if (isLoggedIn && this.areSearchEvents && !this.arePending) {
      this.myCharityService.getUserEventsSigned(this.userService.user.id, this.areSearchEvents)
        .then((events: EventModel[]) => {
          this.events = events;
          this.changeDateFormat();
        });
    } else if (isLoggedIn && !this.areSearchEvents && !this.arePending) {
      this.myCharityService.getUserAvailableEvents(this.userService.user.id)
        .then((events: EventModel[]) => {
          this.events = events;
          this.changeDateFormat();
        });
    } else if (isLoggedIn && !this.areSearchEvents && this.arePending) {
      this.myCharityService.getPendingEvents(this.userService.user.id)
        .then((events: EventModel[]) => {
          this.events = events;
          this.changeDateFormat();
        });
    } else {
      this.myCharityService.getEvents()
        .then((events: EventModel[]) => {
          this.events = events;
          this.changeDateFormat();
        });
    }
  }

  changeDateFormat() {
    for (let i = 0; i < this.events.length; i++) {
      this.events[i].startDate = new Date(this.events[i].startDate);
      this.events[i].endDate = new Date(this.events[i].endDate);
    }
  }
}

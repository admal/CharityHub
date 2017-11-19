import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { MyCharityService } from '../../core/services/charity-service/my-charity.service';
import { EventModel } from '../../core/services/charity-service/models/event-model.type';
import { UserService } from '../../core/services/user-service/user.service';

@Component({
  selector: 'my-charity',
  templateUrl: './my-charity.html',
  styleUrls: ['./my-charity.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class MyCharityComponent implements OnInit {

  userEvents: EventModel[];

  constructor(
    private readonly userService: UserService,
    private readonly myCharityService: MyCharityService
  ) {
    
  }

  ngOnInit() {
    this.onEventAdded();
  }

  onAddedEvent(event) {
    this.onEventAdded();
  }

  onEventAdded() {
    let charityId = this.userService.user.organizationId;
    let userId = this.userService.user.id;
    this.myCharityService.getUserEvents(charityId, userId)
      .then((events: EventModel[]) => {
        this.userEvents = events;
      });
  }
}

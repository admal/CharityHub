import { Component, Input } from "@angular/core";
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { UserService } from "../../../core/services/user-service/user.service";
import { MyCharityService } from "../../../core/services/charity-service/my-charity.service";

@Component({
  selector: 'user-event',
  templateUrl: './user-event.html',
  styleUrls: ['../../charity.scss']
})
export class UserEventComponent {
  @Input() eventModel: EventModel;
  @Input() isSearchEvent: boolean;

  constructor(
    private readonly myCharityService: MyCharityService,
    private readonly userService: UserService
  ) {

  }

  addToEvent(eventId:number) {
      let userId = 1; 
      this.myCharityService.addToEvent(userId, eventId)
        .then(() => {
          this.eventModel.id = -1;
        })
  }

}

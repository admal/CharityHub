import { Component, Input, Output, EventEmitter } from "@angular/core";
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
  @Input() isPending: boolean;

  @Output() onAddedEvent = new EventEmitter<void>();

  constructor(
    private readonly myCharityService: MyCharityService,
    public readonly userService: UserService
  ) {

  }

  addToEvent(eventId: number) {
    let userId;
    if (this.userService.isLoggedIn() && !this.isPending) {
      userId = this.userService.user.id;
    }
    this.myCharityService.addToEvent(userId, eventId)
      .then(() => {
        this.eventModel.id = -1;
        this.onAddedEvent.emit();
      });
  }

}

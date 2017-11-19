import { Component, ViewEncapsulation, Input, OnInit } from '@angular/core';
import { MyCharityService } from "../../../core/services/charity-service/my-charity.service";
import { ManageEventModel } from "../../../core/services/charity-service/models/manage-event-model.type";
import { ActivatedRoute } from '@angular/router';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { EventModel } from '../../../core/services/charity-service/models/event-model.type';
import { ParticipantModel } from './../../../core/services/charity-service/models/participant.type';

@Component({
  selector: 'user-management',
  templateUrl: './user-management.html',
  styleUrls: ['./user-management.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class UserManagementComponent implements OnInit, OnDestroy {
  manageEventModel: EventModel;
  isLoading: boolean;

  private eventId: number;

  private sub: any;

  constructor(
    private readonly charityService: MyCharityService,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.isLoading = true;

    this.sub = this.route.params.subscribe(params => {
      this.eventId = +params['eventId'];

      this.charityService.getEventDetails(this.eventId)
        .then((eventModel) => {
          this.manageEventModel = eventModel;
          this.isLoading = false;
        });
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  acceptUser(user: ParticipantModel) {
    this.charityService.acceptUserInEvent(user.userId, this.eventId)
      .then(() => {
          user.isAccepted = true;
      });
  }
}

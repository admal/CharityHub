import { Component, Input, ViewEncapsulation } from '@angular/core';
import { UserService } from '../../core/services/user-service/user.service';

@Component({
  selector: 'user-events', 
  templateUrl: './user-events.html',
  styleUrls: ['./user-events.component.scss'],
  encapsulation: ViewEncapsulation.None 
})
export class UserEventsComponent {

  constructor(
    public readonly userService: UserService
  ) {
  }
}

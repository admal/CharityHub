import { Component, Input, ViewEncapsulation } from '@angular/core';
import { UserService } from '../../core/services/user-service/user.service';

@Component({
  selector: 'user-events', 
  templateUrl: './user-events.html',
  styleUrls: ['./user-events.component.scss'],
  encapsulation: ViewEncapsulation.None 
})
export class UserEventsComponent {
  refresh = true;

  constructor(
    public readonly userService: UserService
  ) {
  }

  // hack, im sorry :C
  refreshEvents() {
    this.refresh = false;
    setTimeout(() => {
       this.refresh = true;
    })
  }
}

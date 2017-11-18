import { Component } from '@angular/core';
import { UserService } from '../services/user-service/user.service';

@Component({
    selector: 'toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
    constructor(
        public readonly userService: UserService,
    ) { }

    isCollapsed: boolean = false;
    
    toggleCollapse(): void {
      this.isCollapsed = !this.isCollapsed; 
    }

    logout() {
        this.userService.logout();
    }

    getUserName() {
        let user = this.userService.user; 
        return `${user.name} ${user.surname}`; 
    }
}

import { Component } from '@angular/core';
import { UserService } from '../services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
    constructor(
        public readonly userService: UserService,
        private readonly router: Router
    ) { }

    isCollapsed: boolean = false;
    
    toggleCollapse(): void {
      this.isCollapsed = !this.isCollapsed; 
    }

    logout() {
        this.userService.logout();
        this.router.navigate(['/']);
    }

    getUserName() {
        let user = this.userService.user; 
        return `${user.name} ${user.surname}`; 
    }
}

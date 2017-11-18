import { Component } from '@angular/core';

@Component({
    selector: 'toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
    constructor() { }

    isCollapsed: boolean = false;
    
    toggleCollapse(): void {
      this.isCollapsed = !this.isCollapsed; 
    }
}

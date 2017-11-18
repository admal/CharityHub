import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventListComponent } from "./events/eventList/event-list.component";
import { MyCharityComponent } from "./myCharity/my-charity.component";

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'list', component: EventListComponent },
    { path: 'myCharity', component: MyCharityComponent }
  ])],
  exports: [RouterModule]
})
export class CharityRoutingModule { } 

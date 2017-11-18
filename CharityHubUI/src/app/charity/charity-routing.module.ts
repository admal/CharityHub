import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventListComponent } from "./events/eventList/event-list.component";
import { MyCharityComponent } from "./myCharity/my-charity.component";
import { NewsComponent } from "./news/news.component";
import { OrganizationListComponent } from './organizations/organizationList/organization-list.component';
import { UserEventsComponent } from "./userEvents/user-events.component";
import { UserManagementComponent } from "./myCharity/userManagement/user-management.component";

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'list', component: UserEventsComponent },
    { path: 'myCharity', component: MyCharityComponent },
    { path: 'news', component: NewsComponent },
    { path: 'organizations', component: OrganizationListComponent },
    { path: 'event/:eventId', component: UserManagementComponent }
  ])],
  exports: [RouterModule]
})
export class CharityRoutingModule { } 

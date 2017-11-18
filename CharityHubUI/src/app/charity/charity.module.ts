import { SharedModule } from "../shared/shared.module";
import { NgModule } from "@angular/core";
import { EventListComponent } from "./events/eventList/event-list.component";
import { EventComponent } from "./events/event/event.component";
import { CharityRoutingModule } from "./charity-routing.module";
import { MyCharityComponent } from "./myCharity/my-charity.component";
import { NewEventComponent } from "./myCharity/newEvent/new-event.component";
import { NewsComponent } from "./news/news.component";
import { NewsDetailsComponent } from "./news/news-details/news-details.components";
import { OrganizationComponent } from './organizations/organization/organization.component';
import { OrganizationListComponent } from './organizations/organizationList/organization-list.component';

@NgModule({
  imports: [
    SharedModule,
    CharityRoutingModule
  ],

  declarations: [EventListComponent,
    EventComponent,
    MyCharityComponent,
    NewEventComponent,
    NewsComponent,
    NewsDetailsComponent,
    OrganizationComponent,
    OrganizationListComponent],
  exports: [],
  providers: [],
  schemas: []
})
export class CharityModule {

}

import { SharedModule } from "../shared/shared.module";
import { NgModule } from "@angular/core";
import { EventListComponent } from "./events/eventList/event-list.component";
import { EventComponent } from "./events/event/event.component";
import { CharityRoutingModule } from "./charity-routing.module";
import { MyCharityComponent } from "./myCharity/my-charity.component";
import { NewEventComponent } from "./myCharity/newEvent/new-event.component";
import { OrganizationComponent } from './events/organization/organization.component';


@NgModule({
  imports: [
    SharedModule,
    CharityRoutingModule
  ],
  declarations: [
    EventListComponent, 
    EventComponent, 
    MyCharityComponent, 
    NewEventComponent,
    OrganizationComponent],
  exports: [],
  providers: [],
  schemas: []
})
export class CharityModule {

}

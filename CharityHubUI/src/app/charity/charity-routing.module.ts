import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EventListComponent } from "./events/eventList/event-list.component";
import { MyCharityComponent } from "./myCharity/my-charity.component";
import { NewsComponent } from "./news/news.component";

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'list', component: EventListComponent },
    { path: 'myCharity', component: MyCharityComponent },
    { path: 'news', component: NewsComponent }
  ])],
  exports: [RouterModule]
})
export class CharityRoutingModule { } 

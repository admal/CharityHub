import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { EventModel } from "./models/event-model.type";
import { EventType } from "./models/event-type.type";

@Injectable()
export class MyCharityService {
  private apiRoot = 'http://localhost:5000/api/User/';
  constructor(private http: HttpClient) {
  }

  getUserEvents(): Promise<EventModel[]> {
    return new Promise<EventModel[]>(resolve => {
      resolve([{
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventType: EventType.Hospital,
        name: 'event 1'
      },
      {
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventType: EventType.Animals,
        name: 'event 2'
        },
      {
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventType: EventType.Animals,
        name: 'event 3'
      }
      ]);
    });
  }
}

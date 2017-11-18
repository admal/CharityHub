import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { EventModel } from "./models/event-model.type";
import { EventType } from "./models/event-type.type";
import { OrganizationModel } from './models/organization-model.type';
import { OrganizationType } from '../user-service/models/organization.enum';
import { ManageEventModel } from "./models/manage-event-model.type";

@Injectable()
export class MyCharityService {
  private apiRootEvent = 'http://localhost:5000/api/CharityEvent/';

  constructor(private http: HttpClient) {
  }

  addEvent(event: EventModel) {
    return this.http.post(`${this.apiRootEvent}`, event, { responseType: 'text' as 'json' })
      .toPromise();
  }

  getUserEvents(): Promise<EventModel[]> {
    return new Promise<EventModel[]>(resolve => {
      resolve([{
        id: 1,
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventCategory: EventType.Hospital,
        name: 'event 1',
        charityId: 0
      },
      {
        id: 2,
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventCategory: EventType.Animals,
        name: 'event 2',
        charityId: 0
      },
      {
        id: 3,
        description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque eu tortor in sapien suscipit ultricies vitae vel arcu. Morbi volutpat venenatis risus eu finibus. Ut dapibus felis at enim dignissim suscipit. Aliquam quis libero dolor. Ut ornare varius dolor, sit amet finibus nisi finibus sed. Aenean luctus at diam ac sollicitudin. Duis vitae placerat felis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Curabitur tincidunt commodo diam, eget gravida leo lobortis sit amet. Donec condimentum facilisis arcu a semper',
        endDate: new Date(),
        startDate: new Date(),
        eventCategory: EventType.Animals,
        name: 'event 3',
        charityId: 0
      }
      ]);
    });
  }

  getOrganizations(): Promise<OrganizationModel[]> {
    return new Promise<OrganizationModel[]>(resolve => {
      resolve([{
        id: 1,
        name: "Test name 1",
        description: "My short description of my favorite organization that I am in charge of",
        organizationType: OrganizationType.NonProfit,
        isObserving: false
      },
      {
        id: 2,
        name: "Test name 2",
        description: "My short description of my favorite organization that I am in charge of",
        organizationType: OrganizationType.Profit,
        isObserving: false
      },
      {
        id: 3,
        name: "Test name 3",
        description: "My short description of my favorite organization that I am in charge of",
        organizationType: OrganizationType.NonProfit,
        isObserving: false
      },
      {
        id: 4,
        name: "Test name 3",
        description: "My short description of my favorite organization that I am in charge of",
        organizationType: OrganizationType.NonProfit,
        isObserving: false
      },
      {
        id: 5,
        name: "Test name 3",
        description: "My short description of my favorite organization that I am in charge of",
        organizationType: OrganizationType.NonProfit,
        isObserving: false
      }]);
    });
  }

  getEventDetails(id: number): Promise<ManageEventModel> {
    return new Promise<ManageEventModel>(resolve => {
      resolve({
        id: 0,
        name: 'event 1',
        users: [{
          firstName: 'user',
          lastName: 'first',
          id: 0,
          isAccepted: true,
          mail: 'user.first@gmail.com'
        }, {
          firstName: 'user',
          lastName: 'second',
          id: 0,
          isAccepted: false,
          mail: 'user.second@gmail.com'
          }, {
            firstName: 'user',
            lastName: 'third',
            id: 0,
            isAccepted: true,
            mail: 'user.third@gmail.com'
        }, {
          firstName: 'user',
          lastName: 'fourth',
          id: 0,
          isAccepted: false,
          mail: 'user.fourth@gmail.com'
        }]
      });
    });
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { EventModel } from "./models/event-model.type";
import { EventType } from "./models/event-type.type";
import { OrganizationModel } from './models/organization-model.type';
import { OrganizationType } from '../user-service/models/organization.enum';
import { ManageEventModel } from "./models/manage-event-model.type";
import { SendNewsModel } from "./models/send-news-model.type";

@Injectable()
export class MyCharityService {
  private apiRootEvent = 'http://localhost:5000/api/CharityEvent/';
  private apiRootCharity = 'http://localhost:5000/api/Charity/';
  private apiEventNotification = 'http://localhost:5000/api/EventNotification/';
  constructor(private http: HttpClient) {
  }

  addEvent(event: EventModel) {
    return this.http.post(`${this.apiRootEvent}`, event, { responseType: 'text' as 'json' })
      .toPromise();
  }

  addToEvent(userId: number, charityEventId: number) {
    return this.http.post(`${this.apiRootEvent}SignInEvent?userId=${userId}&charityEventId=${charityEventId}`, { responseType: 'text' as 'json' })
      .toPromise();
  }

  getCharity(charityId: number) {
    return this.http.get<OrganizationModel>(`${this.apiRootCharity}${charityId}`)
      .toPromise();
  }

  getUserEvents(charityId: number, ownerId: number) {
    let params = new HttpParams();
    if (charityId !== null && typeof charityId !== 'undefined') {
      params = params.append('charityId', charityId.toString());
      params = params.append('ownerId', ownerId.toString());
    }

    return this.http.get<EventModel[]>(`${this.apiRootEvent}GetEventsForCharity`, { params: params })
      .toPromise()
      .then(response => {
        response.forEach(x => {
          x.startDate = new Date(x.startDate);
          x.endDate = new Date(x.endDate);
        });

        return response;
      });
  }

  getOrganizations(userId?: number, name?: string, categoryId?: OrganizationType) {
    let params = new HttpParams();
    if (userId !== null && typeof userId !== 'undefined') {
      params = params.append('userId', userId.toString());
    } else if (name !== null && typeof name !== 'undefined') {
      params = params.append('name', name);
    } else if (categoryId !== null && typeof categoryId !== 'undefined') {
      params = params.append('category', categoryId.toString());
    }

    return this.http.get<OrganizationModel[]>(`${this.apiRootCharity}`, { params: params })
      .toPromise();
  }

  getEvents(name?: string, categoryId?: EventType) {
    let params = new HttpParams();
    if (name !== null && typeof name !== 'undefined') {
      params = params.append('name', name);
    } else if (name !== null && typeof name !== 'undefined') {
      params = params.append('category', categoryId.toString());
    }

    return this.http.get<EventModel[]>(`${this.apiRootEvent}GetEvents`, { params: params })
      .toPromise()
      .then(response => {
        response.forEach(x => {
          x.startDate = new Date(x.startDate);
          x.endDate = new Date(x.endDate);
        });

        return response;
      });
  }

  getUserEventsSigned(userId: number, isSigned: boolean) {
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    params = params.append('isSigned', isSigned.toString());

    return this.http.get<EventModel[]>(`${this.apiRootEvent}GetEventsForUser`, { params: params })
      .toPromise()
      .then(response => {
        response.forEach(x => {
          x.startDate = new Date(x.startDate);
          x.endDate = new Date(x.endDate);
        });

        return response;
      });
  }

  getUserAvailableEvents(userId: number) {
    let params = new HttpParams();
    params = params.append('userId', userId.toString());

    return this.http.get<EventModel[]>(`${this.apiRootEvent}GetAvailableEventsForUser`, { params: params })
      .toPromise()
      .then(response => {
        response.forEach(x => {
          x.startDate = new Date(x.startDate);
          x.endDate = new Date(x.endDate);
        });

        return response;
      });
  }

  getEventDetails(id: number) {
    return this.http.get<EventModel>(`${this.apiRootEvent}${id}`)
      .toPromise();
  }

  sendEventNews(sendNewsModel: SendNewsModel) {
    return this.http.post(`${this.apiEventNotification}AddEmailEventNotification`, sendNewsModel, { responseType: 'text' as 'json' })
      .toPromise();
  }

  acceptUserInEvent(userId: number, charityEventId: number) {
    return this.http.post(`${this.apiRootEvent}AcceptUser?userId=${userId}&charityEventId=${charityEventId}`, { responseType: 'text' as 'json' })
      .toPromise();
  }
  
  getPendingEvents(userId: number) {
    return this.http.get(`${this.apiRootEvent}GetPendinEventsForUser?userId=${userId}`)
      .toPromise();
    
  }
  
  observeCharity(userId: number, charityEventId: number) {
    return this.http.post(`${this.apiRootCharity}Observe?userId=${userId}&charityId=${charityEventId}`, { responseType: 'text' as 'json' })
      .toPromise();
  }

  stopObserveCharity(userId: number, charityEventId: number) {
    return this.http.post(`${this.apiRootCharity}Observe?userId=${userId}&charityId=${charityEventId}`, { responseType: 'text' as 'json' })
      .toPromise();
  }
}

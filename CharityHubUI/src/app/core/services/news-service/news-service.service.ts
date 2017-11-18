import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { NewsModel } from "./models/news-model.type";

@Injectable()
export class NewsService {
  private apiRoot = 'http://localhost:5000/api/User/';
  private headers: HttpHeaders;

  constructor(private http: HttpClient) {
  }

  getNews(): Promise<NewsModel[]> {
    return new Promise<NewsModel[]>(resolve => {
      resolve([
        {
          date: new Date(),
          eventId: 1,
          eventName: 'event 1',
          id: 0,
          message: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam at tristique magna. Praesent vitae posuere odio. Quisque ac augue vitae odio lobortis aliquam. Suspendisse malesuada maximus mollis. Mauris gravida auctor quam. Ut lectus ipsum, elementum eu diam a, dapibus efficitur nulla. Praesent convallis posuere nisl, ut finibus velit commodo blandit. Etiam eleifend tortor molestie ipsum sodales, quis iaculis turpis congue. Nulla tempor lobortis tristique. Etiam blandit ligula finibus, imperdiet nibh id, ornare velit. Duis convallis et turpis quis tincidunt. Suspendisse fringilla, erat eu fringilla congue, eros turpis faucibus lacus, eget molestie erat magna eu mi. Phasellus accumsan felis eget libero posuere vestibulum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam sit amet neque semper, consectetur tortor ut, pharetra dolor. Donec feugiat justo et interdum interdum.',
          organizationName: 'organization 1',
          isNew: false
        },
        {
          date: new Date(),
          eventId: 1,
          eventName: 'event 2',
          id: 0,
          message: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam at tristique magna. Praesent vitae posuere odio. Quisque ac augue vitae odio lobortis aliquam. Suspendisse malesuada maximus mollis. Mauris gravida auctor quam. Ut lectus ipsum, elementum eu diam a, dapibus efficitur nulla. Praesent convallis posuere nisl, ut finibus velit commodo blandit. Etiam eleifend tortor molestie ipsum sodales, quis iaculis turpis congue. Nulla tempor lobortis tristique. Etiam blandit ligula finibus, imperdiet nibh id, ornare velit. Duis convallis et turpis quis tincidunt. Suspendisse fringilla, erat eu fringilla congue, eros turpis faucibus lacus, eget molestie erat magna eu mi. Phasellus accumsan felis eget libero posuere vestibulum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam sit amet neque semper, consectetur tortor ut, pharetra dolor. Donec feugiat justo et interdum interdum.',
          organizationName: 'organization 2',
          isNew: true
        },
        {
          date: new Date(),
          eventId: 1,
          eventName: 'event 3',
          id: 0,
          message: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam at tristique magna. Praesent vitae posuere odio. Quisque ac augue vitae odio lobortis aliquam. Suspendisse malesuada maximus mollis. Mauris gravida auctor quam. Ut lectus ipsum, elementum eu diam a, dapibus efficitur nulla. Praesent convallis posuere nisl, ut finibus velit commodo blandit. Etiam eleifend tortor molestie ipsum sodales, quis iaculis turpis congue. Nulla tempor lobortis tristique. Etiam blandit ligula finibus, imperdiet nibh id, ornare velit. Duis convallis et turpis quis tincidunt. Suspendisse fringilla, erat eu fringilla congue, eros turpis faucibus lacus, eget molestie erat magna eu mi. Phasellus accumsan felis eget libero posuere vestibulum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam sit amet neque semper, consectetur tortor ut, pharetra dolor. Donec feugiat justo et interdum interdum.',
          organizationName: 'organization 1',
          isNew: false
        }
      ]);
    });
  }

}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { NewsModel } from "./models/news-model.type";

@Injectable()
export class NewsService {
  private apiNewsRoot = 'http://localhost:5000/api/EventNotification/GetUserNotifications';
  private headers: HttpHeaders;

  constructor(private http: HttpClient) {
  }

  getNews(userId: number) {
    return this.http.get<NewsModel[]>(`${this.apiNewsRoot}?userId=${userId}`)
      .toPromise();
  }

}

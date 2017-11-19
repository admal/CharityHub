import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { NewsModel } from "../../core/services/news-service/models/news-model.type";
import { NewsService } from "../../core/services/news-service/news-service.service";
import { UserService } from '../../core/services/user-service/user.service';

@Component({
  selector: '<home></home>',
  templateUrl: './news.html',
  styleUrls: ['../charity.scss']
})
export class NewsComponent {
  news: NewsModel[];
  isLoading: boolean;

  constructor(private readonly newsService: NewsService,
    private readonly userService: UserService) {

  }

  ngOnInit() {
    this.isLoading = true;
    let userId = this.userService.user.id;

    this.newsService.getNews(userId)
      .then((news: NewsModel[]) => {
        for (let i = 0; i < news.length; i++) {
          news[i].date = new Date(news[i].date);
        }
        this.news = news;
        this.isLoading = false;
      });
  }
}

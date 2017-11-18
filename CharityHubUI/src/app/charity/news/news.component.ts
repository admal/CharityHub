import { Component } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { NewsModel } from "../../core/services/news-service/models/news-model.type";
import { NewsService } from "../../core/services/news-service/news-service.service";

@Component({
  selector: '<home></home>',
  templateUrl: './news.html',
  styleUrls: ['../charity.scss']
})
export class NewsComponent {
  news: NewsModel[];

  constructor(private readonly newsService: NewsService) {

  }

  ngOnInit() {
    this.newsService.getNews()
      .then((news: NewsModel[]) => {
        this.news = news;
      })
  }
}

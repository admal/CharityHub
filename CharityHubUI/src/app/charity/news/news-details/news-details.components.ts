import { Component, Input } from '@angular/core';
import { NgForm } from "@angular/forms/src/forms";
import { NewsModel } from "../../../core/services/news-service/models/news-model.type";

@Component({
  selector: 'news',
  templateUrl: './news-details.html',
  styleUrls: ['../../charity.scss']
})
export class NewsDetailsComponent {
  @Input() newsModel: NewsModel;
}

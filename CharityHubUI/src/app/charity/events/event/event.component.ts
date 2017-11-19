import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { SendNewsModel } from "../../../core/services/charity-service/models/send-news-model.type";
import { MyCharityService } from '../../../core/services/charity-service/my-charity.service';

@Component({
  selector: 'event',
  templateUrl: './event.html',
  styleUrls: ['../../charity.scss']
})
export class EventComponent {
  @Input() eventModel: EventModel;
  newsText: string;
  subjectText: string;
  eventId: number;
  modalRef: any;
  constructor(private modalService: NgbModal, private myCharityService: MyCharityService) {
  }

  showNewsDialog(content, id: number) {
    this.modalRef = this.modalService.open(content);
    console.log(id);
    this.eventId = id;
  }

  sendMessage() {
    let sendNewsModel = <SendNewsModel>{
      charityEventId: this.eventId,
      content: this.newsText,
      subject: this.subjectText
    };

    this.myCharityService.sendEventNews(sendNewsModel).then();

    this.newsText = null;
    this.eventId = null;
    this.subjectText = null;

    this.modalRef.close();
  }
}

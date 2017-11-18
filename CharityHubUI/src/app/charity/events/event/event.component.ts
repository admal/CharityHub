import { Component, Input } from '@angular/core';
import { EventModel } from "../../../core/services/charity-service/models/event-model.type";
import { MatDialog } from '@angular/material';
import { EventNewsDialogComponent } from "./event-news-dialog.component";

@Component({
  selector: 'event',
  templateUrl: './event.html',
  styleUrls: ['../../charity.scss']
})
export class EventComponent {
  @Input() eventModel: EventModel;

  constructor(public dialog: MatDialog) {
  }

  showNewsDialog(id: number) {
    this.dialog.open(EventNewsDialogComponent, null);
  }
}

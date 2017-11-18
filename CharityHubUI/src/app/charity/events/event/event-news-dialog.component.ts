import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'event-news-dialog',
  templateUrl: './event-news-dialog.html',
  styleUrls: ['../../charity.scss']
})
export class EventNewsDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<EventNewsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}

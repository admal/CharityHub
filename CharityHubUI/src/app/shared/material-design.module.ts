import { NgModule } from '@angular/core';
import { 
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatCheckboxModule,
  MatSelectModule,
  MatCardModule,
  MatSnackBarModule,
  MatListModule,
  MatDialogModule
 } from '@angular/material';
import { MatTabsModule } from '@angular/material/tabs';

@NgModule({
  imports: [],
  exports: [
    MatButtonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
	  MatSelectModule,
    MatCheckboxModule,
    MatNativeDateModule,
    MatCardModule,
    MatSnackBarModule,
    MatListModule,
    MatDialogModule
    ]
}) 
export class MaterialDesignModule { }  

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
  MatSnackBarModule
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
    MatSnackBarModule
    ]
}) 
export class MaterialDesignModule { }  

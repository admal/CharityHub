import { NgModule } from '@angular/core';
import { 
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatDatepickerModule,
  MatNativeDateModule
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
    MatNativeDateModule
    ]
}) 
export class MaterialDesignModule { }  

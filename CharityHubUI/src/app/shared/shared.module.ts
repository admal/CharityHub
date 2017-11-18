import { NgModule }            from '@angular/core';
import { CommonModule }        from '@angular/common';
import { FormsModule }         from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MaterialDesignModule } from './material-design.module';  

@NgModule({
  imports: [MaterialDesignModule],
  declarations: [],
  exports: [
    CommonModule,
    FormsModule,
    NgbModule,
    MaterialDesignModule
  ]
})
export class SharedModule { } 

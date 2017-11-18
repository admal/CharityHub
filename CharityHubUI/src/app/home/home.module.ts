import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { SharedModule } from './../shared/shared.module';

import { HomeRoutingModule } from './home-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent
  ],
  imports: [ HomeRoutingModule, SharedModule ]
})
export class HomeModule { } 

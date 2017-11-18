import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginModel } from './../../core/services/user-service/models/login-model.type';

@Component({
    selector: '<login></login>',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {

    loginModel = new LoginModel();
    
    constructor(
    ) {
    }

    onSubmit(form: NgForm) {
    }

    getModel() {
        return JSON.stringify(this.loginModel);
    }
}

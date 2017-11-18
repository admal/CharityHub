import { RegisterModel } from './../../core/services/user-service/models/register-model.type';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
    selector: '<register></register>',
    templateUrl: './register.component.html',
    styleUrls: ['/register.component.scss']
})
export class RegisterComponent { 
    registerModel = new RegisterModel();

    checked = true;

    constructor(
    ) {
    }

    onSubmit(form: NgForm) {
    }

    getModel() {
        return JSON.stringify(this.registerModel);
    }
}
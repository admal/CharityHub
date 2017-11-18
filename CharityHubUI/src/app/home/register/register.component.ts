import { RegisterModel } from './../../core/services/user-service/models/register-model.type';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserService } from '../../core/services/user-service/user.service';

@Component({
    selector: '<register></register>',
    templateUrl: './register.component.html',
    styleUrls: ['/register.component.scss']
})
export class RegisterComponent { 
    registerModel = new RegisterModel();

    checked = true;

    constructor(
        private readonly userService: UserService,
        public router: Router
    ) {
    }

    onSubmit(form: NgForm) {
        this.userService.registerUser(this.registerModel)
            .then(() => {
                this.router.navigate(['/user/login']);
            })
    }

    getModel() {
        return JSON.stringify(this.registerModel);
    }
}
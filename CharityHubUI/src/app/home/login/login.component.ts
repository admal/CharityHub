import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginModel } from './../../core/services/user-service/models/login-model.type';
import { UserService } from '../../core/services/user-service/user.service';

@Component({
    selector: '<login></login>',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {

    loginModel = new LoginModel();

    constructor(
        private readonly userService: UserService,
        public router: Router
    ) { 
    }

    onSubmit(form: NgForm) {
        this.userService.login(this.loginModel)
            .then(() => {
                this.router.navigate(['/charity/events']);
            });
    }

    getModel() {
        return JSON.stringify(this.loginModel);
    }
}

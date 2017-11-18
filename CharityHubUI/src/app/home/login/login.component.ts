import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: '<login></login>',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    constructor(
    ) {
    }

    onSubmit(form: NgForm) {
    }
}

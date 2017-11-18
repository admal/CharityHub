import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
    selector: '<register></register>',
    templateUrl: './register.component.html'
})
export class RegisterComponent { 

    constructor(
    ) {
    }

    onSubmit(form: NgForm) {
    }
}
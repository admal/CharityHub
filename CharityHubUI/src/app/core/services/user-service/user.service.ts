import { Injectable } from '@angular/core';
import { RegisterModel } from "./models/register-model.type";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from './models/login-model.type';
import { Observable } from 'rxjs/Observable';
import { User } from './models/user.type';
import 'rxjs/add/operator/map'

@Injectable()
export class UserService {
    private apiRoot = 'http://localhost:5000/api/User/';
    private user: User;

    constructor(private http: HttpClient) {
    }

    isLoggedIn() {
        return this.user !== null;
    }

    login(loginModel: LoginModel) {
        return this.http.post<User>(`${this.apiRoot}/SignIn`, loginModel) 
            .toPromise()
            .then(response => { 
                this.user = response;
            });
    }

    logout() {
        this.user = null;
    }

    registerUser(user: RegisterModel) {
        return this.http.post(`${this.apiRoot}/SignIn`, user, { responseType: 'text' as 'json' })
            .toPromise(); 
    }
}

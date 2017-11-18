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
    public user: User;
    private headers: HttpHeaders;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders();
        this.headers.append('Accept', 'application/json');
        this.headers.append('Access-Control-Allow-Origin', '*');
        this.headers.append('Access-Control-Allow-Headers', '*');
    }

    isLoggedIn() {
        return this.user !== null && typeof this.user !== 'undefined';
    }

    login(loginModel: LoginModel) {
        return this.http.post<User>(`${this.apiRoot}SignIn`, loginModel, { headers: this.headers }) 
            .toPromise()
            .then(response => { 
                this.user = new User();
                this.user.id = response.id;
                this.user.name = response.name;
                this.user.surname = response.surname;
            });
    }

    logout() {
        this.user = null;
    }

    registerUser(user: RegisterModel) {
        return this.http.post(`${this.apiRoot}SignUp`, user, { responseType: 'text' as 'json' })
            .toPromise(); 
    }
}

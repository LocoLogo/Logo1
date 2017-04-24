import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { HttpModule } from '@angular/http'; 
import { Http, Headers, Response } from '@angular/http';
import { RequestOptions, Request, RequestMethod} from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Component({
    
    selector: 'login',
    templateUrl: './app/components/login/login.component.html'
})

export class LoginComponent {
    title = "Login";
    loginForm;
    loginError = false;
    result : ILogin;

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private http: Http) {

        this.http.get("/api/login")
            .map(response => response.json())
            .subscribe(result => {
                this.result = result;
                this.loginForm = fb.group({
                    username: [result.username, Validators.required],
                    password: [result.password, Validators.required]
                });
            });

        this.loginForm = fb.group({
            username: ["", Validators.required],
            password: ["", Validators.required]
        });
    }

    performLogin(e) {
        var username = this.loginForm.value.username;
        var password = this.loginForm.value.password;
        
        var body = { "UserName": username, "Password": password};
        let bodyString = JSON.stringify(body); 
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' }); 
        let options = new RequestOptions({ headers: headers });
        
        return this.http.post("/api/profile/", bodyString, options)
            .map(response => response.status)
            .subscribe(result => {
                if (result < 200 || result >= 300) {
                    alert("Failed to login. Please check the database connection.");
                } else {
                    alert("Your login is successufla.");
                    this.router.navigate(['/project']);
                }
            });
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : 'unknown server error';
        console.error(errMsg);
        return Promise.reject(errMsg);
    }
    
}

export interface ILogin {
    username: string,
    password: string
}
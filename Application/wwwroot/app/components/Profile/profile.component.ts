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
    selector: 'profile',
    templateUrl: './app/components/profile/profile.component.html'
})

export class ProfileComponent {
    title = "Profile";
    profileForm;
    profileError = false;
    result : IUser;

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private http: Http) {

        this.http.get("/api/profile")
            .map(response => response.json())
            .subscribe(result => {
                this.result = result;
                this.profileForm = fb.group({
                    username: [result.userName, Validators.required],
                    email: [result.emailAddress, Validators.required],
                    interests: [result.interests, Validators.required],
                    role: [result.role, Validators.required],
                    about: [result.about, Validators.required]
                });
            });

        this.profileForm = fb.group({
            username: ["", Validators.required],
            email: ["", Validators.required],
            interests: ["", Validators.required],
            role: ["", Validators.required],
            about: ["", Validators.required]
        });
    }

    performProfile(e) {
        var username = this.profileForm.value.username;
        var email = this.profileForm.value.email;
        var interests = this.profileForm.value.interests;
        var role = this.profileForm.value.role;
        var about = this.profileForm.value.about;
        
        var body = { "UserName": username, "EmailAddress": email, "Interests": interests, "Role": role, "About": about};
        let bodyString = JSON.stringify(body); 
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' }); 
        let options = new RequestOptions({ headers: headers });
        
        return this.http.post("/api/profile/", bodyString, options)
            .map(response => response.status)
            .subscribe(result => {
                if (result < 200 || result >= 300) {
                    alert("Failed to save your profile. Please check the database connection.");
                } else {
                    alert("Your Profile has been saved.");
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

export interface IUser {
    UserName: string,
    EmailAddress: string,
    Interests: string,
    Role: string,
    About: string
}
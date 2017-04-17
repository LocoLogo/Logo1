import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { HttpModule } from '@angular/http'; 
import { Http, Response } from '@angular/http';
import {RequestOptions, Request, RequestMethod} from '@angular/http';

import { Injectable }              from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'profile',
    templateUrl: './app/components/profile/profile.component.html'
})

export class ProfileComponent {
    UrlToEdit: "";
    title = "Profile";
    //profileForm = null;
    profileForm;
    profileError = false;

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private http: Http) {
        
        this.profileForm = fb.group({
            /*get firstname from db, get function should go
            in between the ""*/
            username: ["", Validators.required],
            email: ["", Validators.required],
            interests: ["", Validators.required],
            role: ["", Validators.required],
            about: ["", Validators.required]
        });
    }
    performProfile(e) {
        /*updates firstname from db*/
        var username = this.profileForm.value.username;
        var email = this.profileForm.value.email;
        var interests = this.profileForm.value.interests;
        var role = this.profileForm.value.role;
        var about = this.profileForm.value.about;


/*http://stackoverflow.com/questions/40046257/typescript-angular-2-http-post-to-c-sharp-mvc
        var body = {"username": username, "email": email, "interests": interests, "role": role, "about": about};
        let bodyString = JSON.stringify(body); 
        let headers = new Headers({ 'Content-Type': 'application/json' }); 
        let options = new RequestOptions({ headers: headers }); 

        return this.http.post(this.UrlToEdit, body, options)
            .map((res: Response) => res.json())
            .catch((error: any) => console.log("Edited value did not been saved"));
            */
}

    
}
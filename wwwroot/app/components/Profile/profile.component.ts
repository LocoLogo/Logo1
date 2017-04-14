import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'profile',
    templateUrl: './app/components/profile/profile.component.html'
})

export class ProfileComponent {
    title = "Profile";
    //profileForm = null;
    profileForm;
    profileError = false;

    constructor(
        private fb: FormBuilder,
        private router: Router) {
        
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

        alert("First Name: " + username);
    } 

    
}
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormControl }            from '@angular/forms';

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
            firstname: ["", Validators.required],
            lastname: ["", Validators.required],
            phone: ["", Validators.required],
            interests: ["", Validators.required],
            role: ["", Validators.required],
            about: ["", Validators.required]
        });
    }
    performProfile(e) {
        var firstname = this.profileForm.value.firstname;
        var lastname = this.profileForm.value.lastname;
        var phone = this.profileForm.value.phone;
        var interests = this.profileForm.value.interests;
        var role = this.profileForm.value.role;
        var about = this.profileForm.value.about;
        alert("First Name: " + firstname);
    } 
}
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormControl }            from '@angular/forms';

@Component({
    
    selector: 'upload',
    templateUrl: './app/components/upload/upload.component.html'
})

export class UploadComponent {
    title = "Upload";
    //profileForm = null;
    uploadForm;
    uploadError = false;
    constructor(
        private fb: FormBuilder,
        private router: Router) {
        
        this.uploadForm = fb.group({
            projectname: ["", Validators.required],
            projectdepartment: ["", Validators.required],
            description: ["", Validators.required]
        });
    }
    performUpload(e) {
        var projectname = this.uploadForm.value.projectname;
        var projectdepartment = this.uploadForm.value.projectdepartment;
        var description = this.uploadForm.value.description;
        alert("Project Name is: " + projectname);
    }    
}
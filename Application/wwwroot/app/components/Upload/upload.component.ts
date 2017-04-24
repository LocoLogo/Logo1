import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';

import { UploadService } from '../Upload/upload.service'

// api url
const URL = '/api/upload';

@Component({
    selector: 'upload',
    templateUrl: './app/components/upload/upload.component.html',
    providers: [UploadService]
})

export class UploadComponent {
    filesToUpload: Array<File>;
    title = "Upload";
    uploadForm;
    uploadError = false;1

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private service: UploadService) {
        
        this.uploadForm = fb.group({
            projectname: ["", Validators.required],
            projectdepartment: ["", Validators.required],
            description: ["", Validators.required]
        });

        this.service.progress$.subscribe(
            data => {
                console.log('progress = ' + data);
            }
        );
    }

    onChange(event) {
        this.filesToUpload = event.srcElement.files;
        
    }

    performUpload(e) {
        var projectname = this.uploadForm.value.projectname;
        var projectdepartment = this.uploadForm.value.projectdepartment;
        var description = this.uploadForm.value.description;

        this.service.makeFileRequest(URL, [], this.filesToUpload, projectname, projectdepartment, description).subscribe(() => {
            console.log('sent');
            alert("Project " + projectname + " has been uploaded!");
            this.router.navigate(['/project']);
        });
        
    }    
}
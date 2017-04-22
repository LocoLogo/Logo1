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
    
    selector: 'upload',
    templateUrl: './app/components/upload/upload.component.html'
})

export class UploadComponent {
    title = "Upload";
    uploadForm;
    uploadError = false;
    result : IUpload;

    constructor(
        private fb: FormBuilder,
        private router: Router,
        private http: Http) {

        this.http.get("/api/project")
            .map(response => response.json())
            .subscribe(result => {
                this.result = result;
                this.uploadForm = fb.group({
                    uploadfiles: [result.uploadfiles, Validators.required],
                    projectname: [result.projectname, Validators.required],
                    projectdepartment: [result.department, Validators.required],
                    description: [result.description, Validators.required],
                });
            });

        this.uploadForm = fb.group({
            uploadfiles: ["", Validators.required],
            projectname: ["", Validators.required],
            projectdepartment: ["", Validators.required],
            description: ["", Validators.required]
        });
    }

    performUpload(e) {
        var uploadfiles = this.uploadForm.value.uploadfiles;
        var projectname = this.uploadForm.value.projectname;
        var projectdepartment = this.uploadForm.value.projectdepartment;
        var description = this.uploadForm.value.description;
        
        var body = { "Uploaded Files": uploadfiles, "Project Name": projectname, "Project Department" : projectdepartment, "Description" : description};
        let bodyString = JSON.stringify(body); 
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' }); 
        let options = new RequestOptions({ headers: headers });
        
        return this.http.post("/api/project/", bodyString, options)
            .map(response => response.status)
            .subscribe(result => {
                if (result < 200 || result >= 300) {
                    alert("Failed to save your project. Please check the database connection.");
                } else {
                    alert("Your Project has been saved.");
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

export interface IUpload {
    uploadfiles: string,
    projectname: string,
    projectdepartment: string,
    description: string
}
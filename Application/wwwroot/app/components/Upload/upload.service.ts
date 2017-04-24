import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
@Injectable()
export class UploadService {
    progress$: any;
    progress: any;
    progressObserver: any;
    constructor() {
        this.progress$ = Observable.create(observer => {
            this.progressObserver = observer
        }).share();
    }

    makeFileRequest(url: string, params: string[], files: File[], name: string, department: string, description: string): Observable<any> {
        return Observable.create(observer => {
            let formData: FormData = new FormData(),
                xhr: XMLHttpRequest = new XMLHttpRequest();

            formData.append("projectName", name);
            formData.append("projectDepartment", department);
            formData.append("projectDescription", description);

            for (let i = 0; i < files.length; i++) {
                formData.append("uploads[]", files[i], files[i].name);
            }

            xhr.onreadystatechange = () => {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200 || xhr.status === 201) {
                        observer.next(JSON.parse(xhr.response));
                        observer.complete();
                    } else {
                        observer.error(xhr.response);
                    }
                }
            };

            xhr.upload.onprogress = (event) => {
                this.progress = Math.round(event.loaded / event.total * 100);

                this.progressObserver.next(this.progress);
            };

            xhr.open('POST', url, true);
            var serverFileName = xhr.send(formData);
            return serverFileName;
        });
    }
}
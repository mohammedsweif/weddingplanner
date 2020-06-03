import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent implements OnInit {
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();
  // @Input() public test;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    console.log(fileToUpload)
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.onUploadFinished.emit(formData);

    // this.http.post('https://localhost:5001/api/upload', formData, {reportProgress: true, observe: 'events'})
    //   .subscribe(event => {
    //     if (event.type === HttpEventType.UploadProgress)
    //       this.progress = Math.round(100 * event.loaded / event.total);
    //     else if (event.type === HttpEventType.Response) {
    //       this.message = 'Upload success.';
    //       this.onUploadFinished.emit(event.body);
    //     }
    //   });
  }
}
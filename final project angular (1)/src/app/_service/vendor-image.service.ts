import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import {Image} from '../_models/image';

@Injectable({
  providedIn: 'root'
})
export class VendorImageService {

  constructor(private http:HttpClient) { }
  header={
    headers:new HttpHeaders({
        "Content-Type":"Application/Json"
    })
  }
  UploadImae(image:Image){
    return this.http.post("http://localhost:50414/VendorSetting/UploadImage",image,this.header);
  }
}

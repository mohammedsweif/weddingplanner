import { Injectable } from '@angular/core';
import { ApplicationUser}from '../_Models/application-user';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Image} from '../_models/image';
import { from } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApplicationUserSittingService {

  constructor(private http:HttpClient) { }
  header={
    headers:new HttpHeaders({
"Content-Type":"Application/Json"
    })
  }
  UploadImae(image:Image){
    return this.http.post("http://localhost:50414/User/UploadImage",image,this.header);
  }
  GetUser(id:string){
    return this.http.get<ApplicationUser>("http://localhost:50414/User/GetUser/"+id,this.header);
  }
  UpdateUser(user:ApplicationUser){
    return this.http.post("http://localhost:50414/User/EditUser",user,this.header);
  }
  DeleteUser(id:string){
    return this.http.delete("http://localhost:50414/User/deleteUser"+id,this.header);
  }
}

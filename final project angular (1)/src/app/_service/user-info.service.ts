import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class UserInfoService {
  header={
    headers:new HttpHeaders({
      "Content-Type":"Application/Json"
    })
  }
  constructor(private http:HttpClient) { }
  getUserInfo(id:string){
    return this.http.get(`http://localhost:50414/User/GetUser/${id}`,this.header);
  }
}

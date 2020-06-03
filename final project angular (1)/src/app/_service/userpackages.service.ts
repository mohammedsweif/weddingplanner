import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class UserpackagesService {

  header={
    headers:new HttpHeaders({
      "Content-Type":"Application/Json"
    })
  }
    constructor(private http:HttpClient) { }
    getPackage(id:string){
      return this.http.get("http://localhost:50414/User/GetPackage/"+id,this.header);
    }
    GetSpecificPackage(id:number){
      return this.http.get("http://localhost:50414/User/GetSpecificPackage/"+id,this.header);
    }
}

import { Injectable } from '@angular/core';
import {HttpHeaders, HttpClient} from '@angular/common/http';
 
import { Observable } from 'rxjs';
import { Registerr } from '../_Models/Register';
import { RegisterVendor } from '../_Models/RegisterVendor';
import loginClass from '../_Models/loginClass';
 
 
@Injectable({
  providedIn: 'root'
})
export class RegisterServiceService {
urlcon:string="http://localhost:50414/account/";
header={
  headers:new HttpHeaders({
"Content-Type":"application/json"
  })
}
header2={
  headers:new HttpHeaders({
"Content-Type":"application/json",
"Authorization": "bearer "+localStorage.getItem("token")
  })
}
  constructor( public http:HttpClient) { }
  register(obj:Registerr,role:number):Observable<Registerr>{
    return this.http.post<Registerr>(this.urlcon+"Register/"+role,obj,this.header).pipe();
  } 
  registerven(obj:RegisterVendor):Observable<RegisterVendor>{
    return this.http.post<RegisterVendor>(this.urlcon+"Register",obj,this.header).pipe();
  } 
   login(obj:loginClass):Observable<loginClass>{
    return this.http.post<loginClass>(this.urlcon+"Login",obj,this.header).pipe();
  }
  test(){
    console.log(this.header2);
    return this.http.get("http://localhost:50414/weatherforecast",this.header2).pipe();
  }
  logout(){
    return this.http.get("http://localhost:50414/account/logout",this.header).pipe();
  }
}

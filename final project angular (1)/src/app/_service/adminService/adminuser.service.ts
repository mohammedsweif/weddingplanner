import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { adminuser } from 'src/app/_models/Adminclasses/adminusers';


@Injectable({
  providedIn: 'root'
})
export class AdminuserService {
   header={
    headers:new HttpHeaders({
      "Content-Type":"application/json"
    })
  }

  constructor(private http:HttpClient) { }
  getall(){
   return this.http.get<adminuser[]>("http://localhost:50414/admin/allusers",this.header)
  }
  senddata(e){
    return this.http.post("http://localhost:50414/admin/sendmessage",e,this.header)
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserBooks } from '../_models/UserBooks';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http:HttpClient) { }

  GetClientBooks(id:string){
    return this.http.get<UserBooks[]>("http://localhost:50414/User/ClientBooks/"+id)
  }

  // CheckDate(id:number){
  //   return this.http.get<boolean>("http://localhost:50414/User/CheckDate/"+id)
  // }

  DeleteBooking(id:number){
    const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
    return this.http.delete("http://localhost:50414/User/"+id,httpOptions)
  }

}

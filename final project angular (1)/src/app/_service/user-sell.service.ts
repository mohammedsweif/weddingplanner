import { Injectable } from '@angular/core';
import { UserUsed } from '../_models/user-used';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserSellService {
  url:string="http://localhost:50414/UserProducts/PostUserProduct";
 toDoes:UserUsed[];

  constructor(private http:HttpClient) { }
  getAllUsed()
 {
   return this.http.get<UserUsed[]>("http://localhost:50414/UserProducts");
   // .toPromise().then(
   //   result=>
   //   this.calend=result as Calendar[]
   // )
 }
  addselled(does)
  {
    const httpOption={
      headers:new HttpHeaders({
        "Content-Type":"application/json"
      })
    };
    console.log(does);
   return this.http.post(this.url,does,httpOption);
  }
}

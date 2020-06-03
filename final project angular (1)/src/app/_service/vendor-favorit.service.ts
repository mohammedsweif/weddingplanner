import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class VendorFavoritService {

  header={
    headers:new HttpHeaders({
      "Content-Type":"Application/Json"
    })
  }
  constructor(private http :HttpClient) { }
  GetFavoritVendor(id:string){
   return this.http.get(`http://localhost:50414/User/GetAllFavorit/${id}`);
  }
  RemoveFromFavorit(id:number){
    return this.http.delete(`http://localhost:50414/User/RemovefromFavorit/${id}`,this.header);
  }
}

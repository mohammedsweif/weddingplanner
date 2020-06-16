import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { FavAdd } from '../_models/getFavorit';
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
  AddToFavorit(Fav:FavAdd){
    return this.http.post("http://localhost:50414/User/AddToFavorit",Fav,this.header);
  }

}

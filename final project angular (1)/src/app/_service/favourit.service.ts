import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { VendorFavourites } from '../_models/vendor-favourites';


@Injectable({
  providedIn: 'root'
})
export class FavouritService {
  url:string="http://localhost:50414/Favorits";
  favourites:VendorFavourites[]
  
 
  constructor(private http:HttpClient) { }
  getfavourites()
 {
   return this.http.get<VendorFavourites[]>(this.url);
   
 }
}

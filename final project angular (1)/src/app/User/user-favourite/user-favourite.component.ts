import { Component, OnInit } from '@angular/core';
import {VendorFavoritService} from '../../_service/vendor-favorit.service';
import {FavoritVendors} from '../../_models/getFavorit';
@Component({
  selector: 'app-user-favourite',
  templateUrl: './user-favourite.component.html',
  styleUrls: ['./user-favourite.component.css']
})
export class UserFavouriteComponent implements OnInit {

  id:string="497a2b25-b878-42ed-9554-678ace76fdaa";
  Favorit:FavoritVendors[]=[];
  AllFavorit:FavoritVendors[]=[];
  Cat:string[]=[];
  Category:string;
  constructor(private FavServ:VendorFavoritService) { }

  ngOnInit(): void {
    this.FavServ.GetFavoritVendor(this.id).subscribe(response=>{
      this.AllFavorit=response as FavoritVendors[];
      this.Favorit=this.AllFavorit
      this.Cat=[...new Set (this.Favorit.map(a=>a.category))];
      console.log(this.Cat);
      console.log(this.Favorit);
    })
  }
  RemoveFromFavorit(index:number){
    let deletedVendor=this.Favorit[index];
    let id= deletedVendor.id;
    
    this.FavServ.RemoveFromFavorit(id).subscribe(a=>{this.Favorit.splice(index,1)});
  }
  makeFilter(cat:any){
    if(cat=="All"){
      this.Favorit=this.AllFavorit;
    }else{
      this.Favorit=this.AllFavorit.filter(a=>a.category== cat);
    }
  }
}

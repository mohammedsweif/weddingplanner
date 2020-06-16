import { Component, OnInit } from '@angular/core';
import {VendorFavoritService} from '../../_service/vendor-favorit.service';
import {FavoritVendors} from '../../_models/getFavorit';
@Component({
  selector: 'app-user-favourite',
  templateUrl: './user-favourite.component.html',
  styleUrls: ['./user-favourite.component.css']
})
export class UserFavouriteComponent implements OnInit {

  id:string="937be65d-b7dc-4dd8-8939-2fe6798aedc4";
  Favorit:FavoritVendors[]=[];
  AllFavorit:FavoritVendors[]=[];
  Cat:string[]=[];
  config:any
  catt:string;
 
  constructor(private FavServ:VendorFavoritService) {
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
   }

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
  makeFilter(tt:string){
    if(tt=="All"){
      this.Favorit=this.AllFavorit;
    }else{
      this.Favorit=this.AllFavorit.filter(a=>a.category== tt);
      console.log( this.Favorit);
    }
  }
  clientname:string="";
    search(f){
      this.clientname = f.value;
      console.log(f.value);
      console.log(this.clientname);
    }
    pageChanged(event){
    this.config.currentPage = event;
   }
}

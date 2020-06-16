import { Component, OnInit } from '@angular/core';
import { gelleryclass } from '../service_classes/gelleryClass';
import { GelleryserService } from '../service_classes/gelleryser.service';
import { catagor } from '../service_classes/catigor';
import { FavAdd } from 'src/app/_models/getFavorit';
import { VendorFavoritService } from 'src/app/_service/vendor-favorit.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent implements OnInit {
  gellery:gelleryclass[]=[];
  catigr:catagor[]=[];
  FavAdd:FavAdd=new FavAdd();
  constructor(private ser:GelleryserService ,private FavServ:VendorFavoritService) { }
  numderdisapper:number;
 
counter(i:number){
  this.numderdisapper = 5-i;
  return new Array(i);
}
counter1(i:number){
  return new Array(i); 
}
cat:number=0;
change(v){
  this.cat=v;
  console.log(v);
}
vendorname:string="";
search(n){
  console.log(n.value);
  this.vendorname=n.value;
  console.log(this.vendorname);
}
  ngOnInit(): void {
    this.ser.getallgalory().subscribe(
      succ=>{console.log(succ);
      this.gellery=succ;
      console.log(this.gellery);},err=>{console.log(err)}
    );
    this.ser.getallcatagory().subscribe(suc=>{
    this.catigr=suc;
    },err=>{
      console.log(err)
    })
  }
AddToFavorit(id:string){
  this.FavAdd.vendorId=id;
  this.FavAdd.userId="937be65d-b7dc-4dd8-8939-2fe6798aedc5";
  this.FavServ.AddToFavorit(this.FavAdd).subscribe(a=>{console.log("Added")},error=>{console.log("error")})
}
}

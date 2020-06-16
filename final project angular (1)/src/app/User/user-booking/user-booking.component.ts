import { Component, OnInit } from '@angular/core';
import {UserBookingService} from '../../_service/user-booking.service'
import { ToastrService } from 'ngx-toastr';
import {GetBooking} from '../../_models/bookings';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { Subscription } from 'rxjs';
import { category } from 'src/app/CategoryModel/category';



@Component({
  selector: 'app-user-booking',
  templateUrl: './user-booking.component.html',
  styleUrls: ['./user-booking.component.css']
})
export class UserBookingComponent implements OnInit {

id:string="937be65d-b7dc-4dd8-8939-2fe6798aedc4";
BookList:GetBooking[]=[];
Books:GetBooking[]=[];

config:any;
Id:number;
TotalNumber:number
subs:Subscription
page:number=1
categories:category[]=[]
  constructor(private BookServ:UserBookingService,private toast:ToastrService,private ser:MyserviceService) { 
    this.BookList= new Array<any>()
    this.config = {
      itemsPerPage: 3,
      currentPage: 1}
}

  ngOnInit(): void {
    this.BookServ.GetBooking(this.id).subscribe(response=>{
      
      this.BookList= response as GetBooking[];
      this.Books=this.BookList
      console.log(this.BookList)
      console.log(this.BookList.length);
    });
    this.subs=this.ser.GetVenUserCategories(this.id).subscribe(
      a=>{this.categories=a;
        console.log(this.categories);}
    )
   
    

  }
CancelBook(i:number){
   let index=this.BookList.findIndex(a=>a.id==i);
  this.BookServ.CancelBook(i).subscribe(r=>{this.toast.success("Ok","Your Bookings is canceled");
   this.BookList.splice(index,1);
 },error=> {console.log(error); this.toast.error("no",error.error)});
}
pageChanged(event){
  this.config.currentPage = event;
 }

 makeFilter(tt:string){
  if(tt=="All"){
    this.Books=this.BookList;
  }else{
    this.Books=this.BookList.filter(a=>a.category== tt);
    console.log( this.Books);
  }
 
 }
}

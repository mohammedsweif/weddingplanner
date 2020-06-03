import { Component, OnInit } from '@angular/core';
import {AdminBookingService} from '../../_service/adminService/admin-booking.service';
import {CategoryService} from '../../_service/category.service';
import {Category} from '../../_models/category';
import {BookingDetails} from '../../_models/Adminclasses/BookondDetails';
@Component({
  selector: 'app-bookingdetails',
  templateUrl: './bookingdetails.component.html',
  styleUrls: ['./bookingdetails.component.css']
})
export class BookingdetailsComponent implements OnInit {

  categryList :Category[]=[];
Cat:Category = new Category();
  bookDetails: BookingDetails[]=[];
  bookDetailsList: BookingDetails[]=[];
  date:Date;
  constructor(private AdminServ:AdminBookingService,private CatServ:CategoryService){ }

  ngOnInit(): void {
    this.CatServ.getallcategories().subscribe(Response=>{this.categryList = Response as Category[],console.log(this.categryList)})
    this.AdminServ.getBookDeatils().subscribe(a=>{
      this.bookDetailsList= a as BookingDetails[];
      this.bookDetails=this.bookDetailsList;
      console.log(this.bookDetails)});
  }
  makeFilter(ID:any){
    if(ID == "0"){
      this.bookDetails=this.bookDetailsList;
    }else{
      this.bookDetails= this.bookDetailsList.filter(a=>a.cat_Id==ID);
    }
  }
  DateFilter(){
    console.log(this.date);
    this.bookDetails = this.bookDetailsList.filter(a=>a.realdate==this.date);
  }



}

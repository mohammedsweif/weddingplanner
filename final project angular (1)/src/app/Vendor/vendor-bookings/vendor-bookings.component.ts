import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/_service/booking.service';
import { CategoryService } from 'src/app/_service/category.service';
import { Booking } from 'src/app/model/booking';
import { Category } from 'src/app/model/category';
import { MyserviceService } from 'src/app/_service/myservice.service';
//import { ApplicationsusersService } from 'src/app/_service/applicationsusers.service';



@Component({
  selector: 'app-vendor-bookings',
  templateUrl: './vendor-bookings.component.html',
  styleUrls: ['./vendor-bookings.component.css']
})
export class VendorBookingsComponent implements OnInit {
  bookings:Booking[];
  cats:Category[];
  todayDate:Date = new Date();
  catnum:number;
  getclient:Booking =new Booking();
  //topagination
  config: any;
  modalBookId:number=0

  //vendor to get his booking
 
  VendorNo:string ="98909ee6-aa65-400d-8587-ab06e92b4717" 
 
  
  constructor(private s:BookingService,private ser:MyserviceService) {
    //topagination
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
  }
  
  ngOnInit(): void {
    this.s.getallbooking(this.VendorNo).subscribe(
    a=>{this.bookings=a;
      console.log(a)
    })
 
   this.ser.GetVenCategories(this.VendorNo).subscribe(
    a=>{this.cats=a;
      console.log(this.cats);})
  //to filter catagory "All"
    this.catnum=0; 
}
   //comparedate to set status

checkdate(time: Date){
var timeDiff = Math.abs(Date.now() - new Date(time).getTime());
 if(new Date(time).getTime() > Math.abs(Date.now())){
   return true;
 }
 else{
  return false;
 }
}

//for client details
getuser(n:number){
  this.modalBookId=n
console.log(n);
this.s.getClient(n).subscribe(a=>{this.getclient=a;
console.log(a);})
return this.getclient;
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


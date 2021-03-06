import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {UserpackagesService} from '../../_service/userpackages.service';
import {Bookings} from '../../_models/bookings';
import {UserBookingService} from '../../_service/user-booking.service';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {BusyDate} from '../../_models/BusyDates';
import{Packages} from '../../_models/Packages';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-book-package',
  templateUrl: './book-package.component.html',
  styleUrls: ['./book-package.component.css']
})
export class BookPackageComponent implements OnInit {
  //as
  minDate: Date;
  i:number;
  colorTheme = 'theme-orange';
  bsConfig: Partial<BsDatepickerConfig>;
  //as
  constructor(private router:Router, private PackageServ :UserpackagesService, private BookServ:UserBookingService,private _activatedroute:ActivatedRoute,private toast:ToastrService) {
  //as
    this.minDate = new Date();
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
    
//as
   }
  package: Packages;
  Bookings:Bookings = new Bookings();
  dateNow= new Date();
  DateBusy:BusyDate[]=[];
  dates:string[];
  show:boolean =  false;
  //as to disable date
  datess:Date[]=[];
  
  ngOnInit(): void {
    let id:number=0;
    this._activatedroute.paramMap.subscribe(params=>{
       id=+params.get("id");
       this.getPackage(id);
    })
    
console.log(this.DateBusy)

//as to get disable date
  this.BookServ.GetBusyDates("e75335e1-23f7-44c7-bac0-e6c35f5bd732").subscribe(data=>{
    this.DateBusy= data as BusyDate[]
  console.log(this.DateBusy[1].busyDate);
  console.log(this.DateBusy)
  for(this.i=0;this.i<this.DateBusy.length;this.i++){
    this.datess.push(new Date (this.DateBusy[this.i].busyDate))
  }
  console.log(this.datess);
  });
   
  }
  
getPackage(id:number){
  this.PackageServ.GetSpecificPackage(id).subscribe(response =>{
    console.log(response)
    this.package= response as Packages;
    console.log(this.package.categoryId);
    this.Bookings.BookDate= this.dateNow;
    this.Bookings.CategoryId=this.package.categoryId;
    this.Bookings.vendorId=this.package.vendorId;
    this.Bookings.Cost=this.package.cost;
    this.Bookings.BookingId=0;
    this.Bookings.pack_id= this.package.packageId ,
    this.Bookings.UserId="937be65d-b7dc-4dd8-8939-2fe6798aedc4";
    console.log(this.Bookings);
    this.getBusyDate(this.Bookings.vendorId);
  })
}
getBusyDate(id:string){
  this.BookServ.GetBusyDates(id).subscribe(data=>{
    this.DateBusy= data as BusyDate[]
  console.log(this.DateBusy[1].busyDate);
  });
}
MakeBook(){
  if(this.Bookings.RealDate){ 
   

    console.log("ttt" + this.Bookings.RealDate);
 
    this.show= this.DateBusy.some(item=> item.busyDate===this.Bookings.RealDate);
  if(!this.show){
     
    console.log(this.Bookings);
    this.BookServ.AddBook(this.Bookings).subscribe(Response =>{this.DateBusy.push(Response as BusyDate)
      this.toast.success("Your Book Done","WOW");
      this.router.navigate(['User/Booking']);}
    ,error=>{this.toast.error("Filed To Book you select Invalid Date","Sorry")});
    
  }
  
 }else{
   this.toast.error("you must select date ","no")
 }
}

}




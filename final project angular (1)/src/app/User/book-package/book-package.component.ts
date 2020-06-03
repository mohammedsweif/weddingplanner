import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {UserpackagesService} from '../../_service/userpackages.service';
import {Bookings} from '../../_models/bookings';
import {UserBookingService} from '../../_service/user-booking.service';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import {BusyDate} from '../../_models/BusyDates';
import{Packages} from '../../_models/Packages';
@Component({
  selector: 'app-book-package',
  templateUrl: './book-package.component.html',
  styleUrls: ['./book-package.component.css']
})
export class BookPackageComponent implements OnInit {

  constructor(private router:Router, private PackageServ :UserpackagesService, private BookServ:UserBookingService,private _activatedroute:ActivatedRoute,private toast:ToastrService) { }
  package: Packages;
  Bookings:Bookings = new Bookings();
  dateNow= new Date();
  DateBusy:BusyDate[]=[];
  dates:string[];
  show:boolean =  false;
  ngOnInit(): void {
    let id:number=0;
    this._activatedroute.paramMap.subscribe(params=>{
       id=+params.get("id");
       this.getPackage(id);
    })
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
    this.Bookings.UserId="497a2b25-b878-42ed-9554-678ace76fdaa";
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
  this.show= this.DateBusy.some(item=> item.busyDate===this.Bookings.RealDate);
  if(!this.show){
    this.BookServ.AddBook(this.Bookings).subscribe(Response =>{this.DateBusy.push(Response as BusyDate)
      this.toast.success("Your Book Done","WOW");
      this.router.navigate(['User/Booking']);}
    ,error=>{this.toast.error("Filed To Book you select Invalid Date","Sorry")});
    console.log("ready to book")
  }
  
 }else{
   this.toast.error("you must select date ","no")
 }
}

}




import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router'
import {UserBookingService} from '../../_service/user-booking.service';
import { Bookings } from 'src/app/_models/bookings';
import {ToastrService} from 'ngx-toastr';
import {Router} from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';
@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit {
  ////as
  rdate: Date;
  minDate: Date;
  colorTheme = 'theme-orange';
  bsConfig: Partial<BsDatepickerConfig>;
  datess:Date[]=[];
  i:number;
  
 //as

  BookDetails:any;
  DateBusy:Array<any>;
  Bookings:Bookings = new Bookings();
  show:boolean =  false;
  constructor(private route:Router,private _route:ActivatedRoute,private BookServ:UserBookingService,private toast:ToastrService) {
   //as
    this.minDate = new Date();
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   //as
   }

  ngOnInit(): void {
    let id:number=0;
    this._route.paramMap.subscribe(params=>{
      id =+ params.get("id");
      this.BookServ.getSpecficBook(id).subscribe(Response=> {
        this.BookDetails=Response;
        this.getBusyDate(this.BookDetails.vendorId);
        this.Bookings.BookingId=this.BookDetails.bookingId;
        this.Bookings.BookDate=this.BookDetails.bookDate;
        this.Bookings.CategoryId= this.BookDetails.categoryId;
        this.Bookings.UserId=this.BookDetails.userId;
        this.Bookings.vendorId=this.BookDetails.vendorId;
        this.Bookings.pack_id=this.BookDetails.pack_id;
        this.Bookings.Cost=this.BookDetails.cost;
        this.Bookings.Status=this.BookDetails.status;
        console.log(this.BookDetails);
        //as
       this.rdate=new Date(this.BookDetails.realDate)
      //as to get disable date
  this.BookServ.GetBusyDates("e75335e1-23f7-44c7-bac0-e6c35f5bd732").subscribe(data=>{
    this.DateBusy= data as Array<any>
  console.log(this.DateBusy[1].busyDate);
  console.log(this.DateBusy)
  for(this.i=0;this.i<this.DateBusy.length;this.i++){
    this.datess.push(new Date (this.DateBusy[this.i].busyDate))
  }
  console.log(this.datess);
  });

       


      });
    })
    
  }
  getBusyDate(id:string){
    this.BookServ.GetBusyDates(id).subscribe(data=>{
      this.DateBusy= data as Array<any> 
    console.log(this.DateBusy[1].busyDate);
    });
  }
  EditBook(){
    if(this.Bookings.RealDate){
      
    
    this.show= this.DateBusy.some(item=> item.busyDate===this.Bookings.RealDate);
    if(!this.show){
        this.BookServ.EditBook(this.Bookings).subscribe(a=>{
          this.DateBusy.push(a);
          this.toast.success("Your Book Edited","WOW")
        },error=>{this.toast.error("Filed To Edit you select Invalid Date","Sorry")});
    
    }
  }else{
      this.toast.error("You must Seelect Valid Date","No")
  }}
  CancelEdit(){
    this.route.navigate(['User/Booking']);
  }
}

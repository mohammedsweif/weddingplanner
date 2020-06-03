import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/_service/booking.service';
import { Bookings } from 'src/app/_models/bookings';
import { LastBookingService } from 'src/app/_service/last-booking.service';
import { LastBooking } from 'src/app/_models/last-booking';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
book:LastBooking[];
books:LastBooking;
 public barChartOptions={
   scaleShowVerticalLines:false,
   responsive:true

 }
 public barChartLabels=['January','February','March','April','May','June','July','August'];
 public barChartType='bar';
 public barChartLegend=true;
 public barCharData=[
   {data:[65,95,55,81,66,120,45,76],label:"user"},
   {data:[16,75,55,51,96,70,105,90],label:"Vendor"}
 ];
 public doughnutChartLabels=['makeup','photographer','decoration','hotel'];
 public doughnutChartData=[2,1,2,1];
 public doughnutChartType='pie';
 public doughnutChartLabels1=['summer','New year','winter'];
 public doughnutChartData1=[330,90,190];
 public doughnutChartType1='pie';
  constructor(public s:LastBookingService){ }

  ngOnInit(): void {
    this.books=new LastBooking();
    this.getall();

  }
  getall(){
   
    this.s.getBookings().subscribe(
      a=>{
        this.book=a;
        console.log("aaaaaaaaaa");
      console.log(a)},
      err=>{
        console.log(err);
      });
  }
  update(){
    this.s.update(this.books).subscribe(a=>
      {
        this.s.getBookings().subscribe(
          a=>{
            this.book=a;
            console.log("uuuuuu");
          console.log(a)});
        console.log(a);
        this.s.getBookings();;
      },
     err=> {
       console.log(err);
     }
      )
  }
  getByNumber(x)
  {
    x as string;
    var y = +x;
    console.log(typeof(y));
    this.s.getByNumber(y).subscribe(
      a=> {
        this.s.getBookings().subscribe(
          a=>{
            this.book=a;
            console.log("uuuuuu");
          console.log(a)});
        console.log(a);
        this.s.getBookings();;
      },
     err=> {
       console.log(err);
     }
    )
    

  }

}

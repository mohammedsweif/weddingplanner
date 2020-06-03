import { Component, OnInit } from '@angular/core';
import { CalendarService } from 'src/app/_service/calendar.service';
import { Calendar } from 'src/app/_models/calendar';
import { Booking } from 'src/app/_models/booking';
import { BookingService } from 'src/app/_service/booking.service';

@Component({
  selector: 'app-vendor-calendar',
  templateUrl: './vendor-calendar.component.html',
  styleUrls: ['./vendor-calendar.component.css']
})
export class VendorCalendarComponent implements OnInit {
  calend:Calendar[];
  cal:Calendar;
  // book:Booking[];
  id:number;
  constructor(private s:CalendarService) {
   

   }
getall(){
  this.s.getCalendar().subscribe(
    a=>{
      this.calend=a;
      console.log("aaaaaaaaaa");
    console.log(a)});
}
  ngOnInit(): void {
   this.cal==new Calendar();
   this.getall();
   this.cal={
    Id: 0, 
    vendor_id: "11A", 
  BookingId: null,
 BusyDay: new Date ("2020-02-02T00:00:00"),
 Reason:  null,
  Status: null

 }
     
  }
  delete(id)
  {
    this.s.deleteDate(id).subscribe(
      
      a=>{
        this.getall();
        console.log("ddddddd");
        console.log(a)
  });
  }
  datafill(it){
    // this.cal.Id=it.Id;
    // this.cal.vendor_id=it.vendor_id;
    // this.cal.BookingId=it.BookingId;
    this.cal.BusyDay=it.busyDay;
    this.cal.Reason=it.Reason;
    this.cal.Status=it.status;
  }
  update(){
    this.s.update(this.cal).subscribe(a=>
      {
        this.s.getCalendar().subscribe(
          a=>{
            this.calend=a;
            console.log("uuuuuu");
          console.log(a)});
        console.log(a);
        this.s.getCalendar();
      },
     err=> {
       console.log(err);
     }
      )
  }
  save()
  {
    this.s.addCalendar(this.cal).subscribe(a=>
      {
        this.s.getCalendar().subscribe(
          a=>{
            this.calend=a;
            console.log("sssssssss");
          console.log(a)});
        console.log(a);
        this.s.getCalendar();
      },
     err=> {
       console.log(err);
     }
      )
  }
  
  // save()
  // {
  //   this.s.addCalendar(this.cal).subscribe(a=>
  //     console.log(a))
  // }

}

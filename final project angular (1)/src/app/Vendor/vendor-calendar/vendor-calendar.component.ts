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
  calenders:Calendar[];
  cal:Calendar=new Calendar();
  newCal:Calendar=new Calendar()
  id:number;
  calStatus:boolean;
  constructor(private s:CalendarService) {
   

   }
getall(){
  this.s.getCalendar().subscribe(
    a=>{
      this.calenders=a;
    console.log(a)});
}
  ngOnInit(): void {
  this.getall();
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
 
  update(){
    this.s.update(this.cal).subscribe(a=>
      {
        this.s.getCalendar().subscribe(a=>{this.calenders=a});

        console.log(this.cal)
        this.s.getCalendar();
      })
  }


  save()
  {
    this.s.addCalendar(this.newCal).subscribe(a=>
      {
        this.s.getCalendar().subscribe(
          a=>{
            this.calenders=a;
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
  
  getCal(id:number){
    this.s.getCal(id).subscribe(a=>{this.cal=a;})
    console.log(this.cal)
  }

  change(value:number){
    console.log(value);
    if(value==0){
      this.calStatus=false;
    }
    
    else{
      this.calStatus=true;
    }
    
    this.cal.status =this.calStatus;
    
    }

    changeAdd(value:number){
      console.log(value);
      if(value==0){
        this.calStatus=false;
      }
      
      else{
        this.calStatus=true;
      }
      
      this.newCal.status =this.calStatus;
    }

    

}

import { Component, OnInit } from '@angular/core';
import {UserBookingService} from '../../_service/user-booking.service'
import { ToastrService } from 'ngx-toastr';
import {GetBooking} from '../../_models/bookings';



@Component({
  selector: 'app-user-booking',
  templateUrl: './user-booking.component.html',
  styleUrls: ['./user-booking.component.css']
})
export class UserBookingComponent implements OnInit {

id:string="497a2b25-b878-42ed-9554-678ace76fdaa";
BookList:GetBooking[]=[];
Id:number;
TotalNumber:number
page:number=1
  constructor(private BookServ:UserBookingService,private toast:ToastrService) { 
    this.BookList= new Array<any>()
}

  ngOnInit(): void {
    this.BookServ.GetBooking(this.id).subscribe(response=>{
      
      this.BookList= response as GetBooking[];
      console.log(this.BookList)
      console.log(this.BookList.length);
    });
  }
CancelBook(i:number){
  let deleted:GetBooking=this.BookList[i];
  let id:number=deleted.id;
  this.BookServ.CancelBook(id).subscribe(r=>{this.toast.success("Ok","Your Bookings is canceled");
  this.BookList.splice(i,1);
},error=> {console.log(error); this.toast.error("no",error.error)});
}
}

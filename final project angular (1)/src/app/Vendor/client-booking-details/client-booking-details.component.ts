import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/_service/booking.service';
import { Subscription } from 'rxjs';
import { Bookings } from 'src/app/_models/bookings';
import { ClientVendorsViewModel } from 'src/app/BookingModel/ClientVendors';

@Component({
  selector: 'app-client-booking-details',
  templateUrl: './client-booking-details.component.html',
  styleUrls: ['./client-booking-details.component.css']
})
export class ClientBookingDetailsComponent implements OnInit {
bookingId:number=0
book:ClientVendorsViewModel=new ClientVendorsViewModel
sub:Subscription
  constructor(private ar:ActivatedRoute,private ser:BookingService,
    private route:Router) { }

  ngOnInit(): void {
    this.ar.params.subscribe(a=>{this.bookingId=a['id'];console.log(a['id'])});
    this.sub=this.ser.GetbookingbyId(this.bookingId).subscribe(a=>{this.book=a;console.log(a)})
  }

}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LastBooking } from '../_models/last-booking';
import { Booking } from '../model/booking';

@Injectable({
  providedIn: 'root'
})

export class LastBookingService {
  url:string="http://localhost:50414/api/bookings";

  constructor(private http:HttpClient) { }
  getBookings(){
    return this.http.get<LastBooking[]>("http://localhost:50414/api/bookings/GetBookings")  
  }
  
  update(book:LastBooking)
  {
    const httpOption={
      headers:new HttpHeaders({
        "Content-Type":"application/json"
      })

    };

   return this.http.put<boolean>("http://localhost:50414/api/bookings/PutBooking",book,httpOption)
  }
  getByNumber(x:number)
  {
    return this.http.get<LastBooking[]>("http://localhost:50414/api/bookings/getByNumber/"+x);
  }

}

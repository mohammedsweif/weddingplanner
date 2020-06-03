import { Injectable } from '@angular/core';
import { Booking } from '../model/booking';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BookingService {
  url:string="http://localhost:50414/api/bookings";
  
  constructor(private http:HttpClient) { }
  
  getallbooking(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<Booking[]>("http://localhost:50414/api/bookings/Getbooking/"+id,httpOptions)  
  }
  getClient(id:Number){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<Booking>("http://localhost:50414/api/bookings/GetClients/"+id,httpOptions)
  }

}

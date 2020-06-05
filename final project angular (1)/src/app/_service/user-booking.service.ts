import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Bookings} from '../_models/bookings';
@Injectable({
  providedIn: 'root'
})
export class UserBookingService {

  
  header={
    headers:new HttpHeaders({
        "Content-Type":"Application/Json"
    })
  }
  constructor(private http:HttpClient) {

   }
   GetBooking(id:string){
     return this.http.get(`http://localhost:50414/User/GetBooking/${id}`,this.header);
   }
   GetBusyDates(id:string){
    return this.http.get(`http://localhost:50414/User/GetDaysBlocked/${id}`,this.header);
   }
   AddBook(booking:Bookings){
    return this.http.post("http://localhost:50414/User/AddBook",booking,this.header);
   }
   CancelBook(id:number){
     return this.http.delete(`http://localhost:50414/User/CancelBooking/${id}`);
   }
   getSpecficBook(id:number){
     return this.http.get(`http://localhost:50414/User/GetSpecficBook/${id}`);
   }
   EditBook(book:Bookings){
      return this.http.post("http://localhost:50414/User/EditBook",book,this.header);
   }
}

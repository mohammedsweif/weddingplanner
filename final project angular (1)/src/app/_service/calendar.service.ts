import { Injectable } from '@angular/core';
import { Calendar } from '../_models/calendar';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import{HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {
 url:string="http://localhost:50414/vendorBusies";
 calend:Calendar[];

 id:number;
  constructor(private http:HttpClient) { }
  getCalendar()
  {
    return this.http.get<Calendar[]>(this.url);
  
  }
  addCalendar(cal)
  {
    const httpOption={
      headers:new HttpHeaders({
        "Content-Type":"application/json"
      })
    };
   return this.http.post("http://localhost:50414/vendorBusies/PostVendorBusy",cal,httpOption);
  }
  update(cal)
  {
    const httpOption={
      headers:new HttpHeaders({
        "Content-Type":"application/json"
      })

    };

   return this.http.put<boolean>(this.url+"/PutVendorBusy",cal,httpOption)
  }
  deleteDate(id:number)
  {
   return this.http.delete<boolean>("http://localhost:50414/vendorBusies/"+id)
  }
}

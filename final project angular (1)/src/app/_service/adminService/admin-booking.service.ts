import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AdminBookingService {

  header={
    headers:new HttpHeaders({
    "Content-Type":"Application/Json"
    })
  }
  constructor(private http:HttpClient) { }
  getBookDeatils(){
    return this.http.get("http://localhost:50414/Admin/bookdetails");
  }
}

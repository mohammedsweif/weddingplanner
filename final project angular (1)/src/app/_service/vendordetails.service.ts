import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VendordetailsService {

  constructor(private http:HttpClient) { }
   getvendordetails(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get("http://localhost:50414/Vendors/Getvendor/"+id,httpOptions)  
  }
}

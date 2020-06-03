import { Injectable } from '@angular/core';
import{Vendor} from '../_Models/vendor';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class VendorSiitingService {

  constructor( private http :HttpClient) { }
  header={
    headers:new HttpHeaders({
"Content-Type":"Application/Json"
    })
  }

  getVendor(id:string){
    return this.http.get("http://localhost:50414/Vendors/GetVendor/"+id,this.header);
  }
  getVendorInfo(id:string){
    
  }


  AddVendor(vendor:Vendor){
    
    return this.http.post("http://localhost:50414/Vendors/postvendor",vendor,this.header);
  }
  UpdateVendor(id:string, vendor:Vendor){
    return this.http.put<boolean>("http://localhost:50414/Vendors/"+id,vendor,this.header);
  }
  deleteVendor(id:string){
    return this.http.delete<boolean>("http://localhost:50414/Vendors/"+id);
  }
}

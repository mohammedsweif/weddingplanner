import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { gelleryclass} from './gelleryClass';
import {  retry    } from 'rxjs/operators';
import { catagor } from './catigor';
@Injectable({
  providedIn: 'root'
})
export class GelleryserService {
url="http://localhost:50414/weatherforecast/getall";
header={
  headers:new HttpHeaders({
    "Content-Type":"application/json"
  })
}
  constructor(private http:HttpClient) { }
getallgalory(){
  return this.http.get<gelleryclass[]>(this.url,this.header) 
}
getallcatagory(){
  return this.http.get<catagor[]>("http://localhost:50414/weatherforecast/getallcatagory",this.header) 
}
}

import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Package } from '../PackageModel/Package';
import {  Eveent} from'../EventModel/Eveent'
import {season} from '../SeasonModel/season'
import{packagefeatures} from '../FeatureModel/Packagefeatures'



@Injectable({
  providedIn: 'root'
})
export class PackageServiceService {

  constructor(private http:HttpClient) { }

  url:string="http://localhost:50414/package";

 

  getallpackages(){
   return  this.http.get<Package[]>("http://localhost:50414/package")
  }

  postpackage(Package:Package){
   const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
   
    return this.http.post("http://localhost:50414/package/PostPackage",Package,httpOptions);
  }
  deletepackage(id){
    const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
    return this.http.delete(this.url+"/"+id,httpOptions);
  }
   putpackage(ppu:Package){
    const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
    return this.http.put(this.url+"/PutPackage",ppu,httpOptions);
   }


   getEvent(id:string){
      
     const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
    return this.http.get<Eveent[]>("http://localhost:50414/package/GetVenEvents/"+id,httpOptions)

   }

   getSeason(id:string){
   
    const httpOptions={
      headers :new HttpHeaders({
        "content-type":"application/json",
      })};
    return this.http.get<season[]>("http://localhost:50414/package/GetVenSeasons/"+id,httpOptions)

   }

  //  getFeatures(id:string){
   
  //   const httpOptions={
  //     headers :new HttpHeaders({
  //       "content-type":"application/json",
  //     })};
  //   return this.http.get<packagefeatures[]>("http://localhost:50414/package/GetVenFeatures/"+id,httpOptions)

  //  }

   getOnePackage(id:number){
    return this.http.get<Package>("http://localhost:50414/package/GetbyId/"+id)
  }

}

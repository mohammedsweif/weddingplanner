import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { adminuser } from 'src/app/_models/Adminclasses/adminusers';
import { Category } from 'src/app/_models/category';
import topall from 'src/app/admin/top-data/topall';
import topcat from 'src/app/admin/top-data/topcat';


@Injectable({
  providedIn: 'root'
})
export class AdminuserService {
   header={
    headers:new HttpHeaders({
      "Content-Type":"application/json"
    })
  }

  constructor(private http:HttpClient) { }
  getall(){
   return this.http.get<adminuser[]>("http://localhost:50414/admin/allusers",this.header)
  }
  senddata(idss,msg:string){
    var content={
      ids:idss,
      messagee:msg
    }
    return this.http.post("http://localhost:50414/admin/sendmessage",content,this.header)
  }
    deleteuser(id:string){
     return this.http.delete("http://localhost:50414/admin/deleteuser/"+id,this.header)
  }
  getallcategories(){
  
        return this.http.get<Category[]>("http://localhost:50414/api/catagories")    
        
      }
      gettopvendor(){
        return this.http.get<topall[]>("http://localhost:50414/admin/getTopUser") ;
      }
      gettopuser(){
        return this.http.get<topall[]>("http://localhost:50414/admin/getTopVendors") ;
      }
      gettopcatagory(){
        return this.http.get<topcat[]>("http://localhost:50414/admin/getTopCategories") ;
      }
 
}

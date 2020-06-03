import { Injectable, Type } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { VWorks } from '../VendorWorksModel/VWorks';
import { identifierModuleUrl } from '@angular/compiler';
import { category } from '../CategoryModel/category';
import { venBudgets } from '../VendorDataModel/venBudgets';
import {VendorClientViewModel} from '../BookingModel/VendorClientViewModel'
import { ClientVendorsViewModel } from '../BookingModel/ClientVendors';
import { Rating } from '../RatingModel/Rating';
import { Countvendor } from '../model/countvendor';
import { Countevent } from '../model/countevent';
import { Countseason } from '../model/countseason';
import { Vendor } from '../_models/vendor';
import { Eveent } from '../EventModel/Eveent';
import { season } from '../SeasonModel/season';


@Injectable({
  providedIn: 'root'
})
export class MyserviceService {

  constructor(private http:HttpClient) { }

 

   
  getWorks(){
    return this.http.get<VWorks[]>("http://localhost:50414/VendorWork/Index")
  }
//asmaa
  getCategories(){
    return this.http.get<category[]>("http://localhost:50414/api/catagories")
  }

  getcountvendor(){
    return this.http.get<Countvendor[]>("http://localhost:50414/countvendor")
  }
  getcountevent(){
    return this.http.get<Countevent[]>("http://localhost:50414/countevent")
  }
  getcountseason(){
    return this.http.get<Countseason[]>("http://localhost:50414/countseason")
  }
  

  deletecatagory(id:number){
    const httpOptions={
       headers:new HttpHeaders({
         'Content-Type':'application/json',
         
       })
     }
     return this.http.delete("http://localhost:50414/countvendor/"+id,httpOptions)
   }
   deleteseason(id:number){
    const httpOptions={
       headers:new HttpHeaders({
         'Content-Type':'application/json',
         
       })
     }
     return this.http.delete("http://localhost:50414/countseason/"+id,httpOptions)
   }
   deletevent(id:number){
    const httpOptions={
       headers:new HttpHeaders({
         'Content-Type':'application/json',
         
       })
     }
     return this.http.delete("http://localhost:50414/countevent/"+id,httpOptions)
   }

   addcat(c:category){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/countvendor/Postcat",c,httpOptions)
  }

  GetVendor(id:number){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get<Vendor[]>("http://localhost:50414/countvendor/"+id,httpOptions)
  }
  addevent(e:Eveent){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/countevent/Postevent",e,httpOptions)
  }

  addseason(s:season){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/countseason/Postseason",s,httpOptions)
  }
  
 GetVenrate(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get("http://localhost:50414/Rating/Getrate/"+id,httpOptions)
  }

  getOne(id:number){
    return this.http.get<VWorks>("http://localhost:50414/VendorWork/GetbyId/"+id)
  }

  getOneBudgetData(id:string,id1:number){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<venBudgets>("http://localhost:50414/VendorWork/Getbudget/"+id+"/"+id1,httpOptions)
  }
  deleteWork(id:number){
   const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.delete("http://localhost:50414/VendorWork/Delete/"+id,httpOptions)
  }

  editWork(work:VWorks){
    
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/VendorWork/Edit",work,httpOptions)
  }

  addWork(work:VWorks){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/VendorWork/Add",work,httpOptions)
  }

  GetVenCategories(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get<category[]>("http://localhost:50414/VendorWork/GetVenCategories/"+id,httpOptions)
  }

  

  GetNoBudgetCateg(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get<category[]>("http://localhost:50414/VendorWork/GetNoBudgetCateg/"+id,httpOptions)
  }

  getVenData(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get<venBudgets[]>("http://localhost:50414/VendorWork/getVenData/"+id ,httpOptions)
  }

 
  addInVendor(vendor:venBudgets){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/VendorWork/addInVendor",vendor,httpOptions)
  }

  putBudget(budgetdata:venBudgets){
    
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
     return this.http.post("http://localhost:50414/VendorWork/EditBudgetData",budgetdata,httpOptions)
  }


  GetTotalBudget(id:string,id1:number){

    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<number>("http://localhost:50414/VendorWork/GetTotalBudget/"+id+"/"+id1 ,httpOptions)
  }

  GetTotalBudgetPaid(id:string,id1:number){

    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<number>("http://localhost:50414/VendorWork/GetTotalBudgetPaid/"+id+"/"+id1 ,httpOptions)
  }

  GetTotalBudgetPending(id:string,id1:number){

    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<number>("http://localhost:50414/VendorWork/GetTotalBudgetPending/"+id+"/"+id1 ,httpOptions)
  }

  // MyClientsin vendor component 

  getVenClients(id:string){
    return this.http.get<VendorClientViewModel[]>("http://localhost:50414/VendorClient/getVenClients/"+id)
  }

  getClientVen(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<ClientVendorsViewModel[]>("http://localhost:50414/VendorClient/getClientVen/"+id,httpOptions)
  }

  GetRate(id:string){

    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
      })
    }
    return this.http.get<Rating[]>("http://localhost:50414/VendorClient/GetRate/"+id ,httpOptions)
  }

  
  GetVenUserCategories(id:string){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.get<category[]>("http://localhost:50414/VendorClient/GetVenUserCategories/"+id,httpOptions)
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { product } from 'src/app/_models/product';
import { productType } from 'src/app/_models/productType';

@Injectable({
  providedIn: 'root'
})
export class AdminProductServiceService {

  constructor(private http:HttpClient) { }

  getProducts(){
    return this.http.get<product[]>("http://localhost:50414/Admin/getProducts")
  }

  getTypes(){
    return this.http.get<productType[]>("http://localhost:50414/Admin/getTypes")
  }

  addType(type :productType){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.post<productType>("http://localhost:50414/Admin/addType",type,httpOptions)
  }
  getOneProduct(id:number){
    return this.http.get<product>("http://localhost:50414/Admin/getOneProduct/"+id)
  }

  deleteProduct(id:number){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.delete<product>("http://localhost:50414/Admin/deleteProduct/"+id,httpOptions)
  }

  editProduct(product:product){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.post<product>("http://localhost:50414/Admin/editProduct",product,httpOptions)
  }

  addProduct(product:product){
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json',
        
      })
    }
    return this.http.post<product>("http://localhost:50414/Admin/addProduct",product,httpOptions)
  }
}

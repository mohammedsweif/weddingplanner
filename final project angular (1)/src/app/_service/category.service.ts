import { Injectable } from '@angular/core';
import { Category } from '../model/category';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  url:string="http://localhost:50414/api/catagories";
  categories:Category[];

  constructor(private http:HttpClient) { }
  getallcategories(){
    // this.http.get(this.url).toPromise().then(
    //   res=>{
    //     this.categories= res as Category[];
        return this.http.get<Category[]>("http://localhost:50414/api/catagories")    
        
      }
    
  
}

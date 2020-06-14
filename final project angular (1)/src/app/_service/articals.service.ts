import { Injectable } from '@angular/core';
import {Articals, AddArticals} from '../_models/articals';
import {HttpClient,HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticalsService {

  header={
    headers:new HttpHeaders({
      "Content-Type":"Application/Json"
    })
}
  constructor(private http:HttpClient) { }
  GetArticals(){
    return this.http.get("http://localhost:50414/Articals/GetAllArticals");
  }
  GetArticalDetails(id:number){
    return this.http.get(`http://localhost:50414/Articals/GetArticalDetails/${id}`)
  }
  EditArtical(artical:AddArticals){
    return this.http.post("http://localhost:50414/Articals/EditArticals",artical,this.header);
  }
  AddArticals(artical:AddArticals){
    return this.http.post("http://localhost:50414/Articals/AddArtical",artical,this.header);
  }
  DeleteArtical(id:number){
    return this.http.delete(`http://localhost:50414/Articals/DeleteArtical/${id}`,this.header);
  }
}

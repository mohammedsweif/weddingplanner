import { Injectable } from '@angular/core';
import {ToDo} from '../_models/to-do'
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ToDoService {
  url:string="http://localhost:50414/toDoes";
 toDoes:ToDo[];


 constructor(private http:HttpClient) { }
 getToDo()
 {
   return this.http.get<ToDo[]>(this.url);
   // .toPromise().then(
   //   result=>
   //   this.calend=result as Calendar[]
   // )
 }
 addToDo(does)
 {
   const httpOption={
     headers:new HttpHeaders({
       "Content-Type":"application/json"
     })
   };
  return this.http.post("http://localhost:50414/toDoes/PosttoDo",does,httpOption);
 }
 update(dos)
 {
   const httpOption={
     headers:new HttpHeaders({
       "Content-Type":"application/json"
     })

   };

  return this.http.put<boolean>(this.url+"/PuttoDo",dos,httpOption)
 }
 delete(id:number)
 {
  return this.http.delete<boolean>("http://localhost:50414/toDoes/"+id)
 }
}

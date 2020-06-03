import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Review } from '../model/review';
import { Reviewadd } from '../model/reviewadd';
import { Reviewreplay } from '../model/reviewreplay';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
reviews:Review[];
replays:Reviewreplay[];
  constructor( private http:HttpClient) { }

  getallreviews(id:string){
    const httpOptions={
      headers :new HttpHeaders({
        'Content-Type':'application/json',
      })};
    return this.http.get<Review[]>("http://localhost:50414/review/Getureviews/"+id,httpOptions).subscribe(
      a=>{this.reviews=a;
      console.log(this.reviews);
      });
  }
  postreview(r:Reviewadd){
    const httpOptions={
       headers :new HttpHeaders({
         "content-type":"application/json",
       })};
     return this.http.post("http://localhost:50414/review/Postreviews",r,httpOptions);
   }

////////////////////////////


   getallreplays(){
    const httpOptions={
      headers :new HttpHeaders({
        'Content-Type':'application/json',
      })};
  return this.http.get<Reviewreplay[]>("http://localhost:50414/replay",httpOptions).subscribe(
     a=>{this.replays=a;
   console.log(this.replays);
     });
   }


   s:Reviewreplay=new Reviewreplay();
   postreplay(r:Reviewreplay){
      const httpOptions={
        headers:new HttpHeaders({
          'Content-Type':'application/json',
        })
      }
       return this.http.post("http://localhost:50414/replay/Add",r,httpOptions)
    }



  } 
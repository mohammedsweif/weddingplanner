import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import { RevPost } from '../_models/review';

@Injectable({
  providedIn: 'root'
})
export class UserReviewService {
  header={
    headers:new HttpHeaders({
      "Content-Type":"Application/Json"
    })
  }

  constructor(private http:HttpClient) { }
  GetReviews(id:string){

    return this.http.get(`http://localhost:50414/User/AllReviews/${id}`);
  }
  DeleteReview(id:number){
    return this.http.delete(`http://localhost:50414/User/DeleteReview/${id}`);
  }
  GetReviewsv(id:string){

    return this.http.get(`http://localhost:50414/User/AllReviewsv/${id}`);
  }
  Getworks(id:string){

    return this.http.get(`http://localhost:50414/User/AllWorks/${id}`);
  }
  AddReview(RevPost:RevPost){
    return  this.http.post("http://localhost:50414/User/AddReview",RevPost,this.header);
  }

}

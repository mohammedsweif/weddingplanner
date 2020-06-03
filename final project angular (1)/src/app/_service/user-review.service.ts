import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class UserReviewService {

  constructor(private http:HttpClient) { }
  GetReviews(id:string){

    return this.http.get(`http://localhost:50414/User/AllReviews/${id}`);
  }
  DeleteReview(id:number){
    return this.http.delete(`http://localhost:50414/User/DeleteReview/${id}`);
  }
}

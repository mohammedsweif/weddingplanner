import { Component, OnInit } from '@angular/core';
import {UserReviewService} from '../../_service/user-review.service';
import {Reviews} from '../../_models/review';
@Component({
  selector: 'app-all-reviews',
  templateUrl: './all-reviews.component.html',
  styleUrls: ['./all-reviews.component.css']
})
export class AllReviewsComponent implements OnInit {

  reviews:Reviews[]=[]
  RevId:number;
  id:string="497a2b25-b878-42ed-9554-678ace76fdaa";
  FilterBase:string;
  Cat:Array<any>;
  AllReview:Reviews[]=[];
  constructor(private UserRevServ:UserReviewService) { }

  ngOnInit(): void {
    this.UserRevServ.GetReviews(this.id).subscribe(a=>{
      console.log(a)
      this.AllReview= a as Reviews[]
      this.reviews=this.AllReview;
      this.Cat=[... new Set(this.AllReview.map(a=>a.category))]
    //console.log(this.reviews);
    });
  }
  delete(i:number){
    let DeletedReview= this.reviews[i];
    let id = DeletedReview.id;
    
     this.UserRevServ.DeleteReview(id).subscribe(a=>{this.reviews.splice(i,1)});
  }
  makeFilter(cat){
    if(cat="All"){
      this.reviews=this.AllReview;
    }else{
      this.reviews=this.AllReview.filter(a=>a.category==cat);
    }
  }  
}

import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ClientVendorsViewModel } from 'src/app/BookingModel/ClientVendors';
import { category } from 'src/app/CategoryModel/category';
import { Subscription } from 'rxjs';
import { MyserviceService } from 'src/app/_service/myservice.service';
import{ NgInitDirective} from '../ng-init-directive'
import { Rating } from 'src/app/RatingModel/Rating';
import { UserReviewService } from 'src/app/_service/user-review.service';
import { RevPost } from 'src/app/_models/review';


@Component({
  selector: 'app-favorit-vendor',
  templateUrl: './favorit-vendor.component.html',
  styleUrls: ['./favorit-vendor.component.css']
})
export class FavoritVendorComponent implements OnInit {

  
    
  ClientVendors:ClientVendorsViewModel[]=[]
  flag:number=0
  catnum:number=0
  Ratinglist:Rating[]

  categories:category[]=[]
  subs:Subscription
  UserNo:string ="937be65d-b7dc-4dd8-8939-2fe6798aedc4" 
  TotalNumber:number
  page:number=1
  config:any;
  review:RevPost=new RevPost();

  constructor(private ser:MyserviceService,private s:UserReviewService) {
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
   }

  ngOnInit(): void {
    
    
    this.subs=this.ser.getClientVen(this.UserNo).subscribe(
      a=>{
        this.ClientVendors=a;
        console.log(a);
        
      }
      )

      this.subs=this.ser.GetVenUserCategories(this.UserNo).subscribe(
        a=>{this.categories=a;
          console.log(this.categories);}
      )

  }

  changeCat(value:number){
    console.log(value);
    this.catnum=value;
    
    }
    vendorName:string="";
    search(f){
      this.vendorName = f.value;
      console.log(f.value);
      console.log(this.vendorName);
    }

    GetRate(id:string){
      this.ser.GetRate(id).subscribe(a=>{
        console.log(a)
        this.Ratinglist=a;
      })
    }

    ToArray(stars:number){
      
        return new Array(stars)
        
    }
    addreview(id:string){
this.review.vedorId=id;
this.review.userId="937be65d-b7dc-4dd8-8939-2fe6798aedc5"
console.log(this.review);
if(this.review.Comment.length>2){
this.s.AddReview(this.review).subscribe(a=>{console.log("Added")
this.review.Comment=""
},error=>{console.log("error")

})}
    }
    pageChanged(event){
      this.config.currentPage = event;
     }
}

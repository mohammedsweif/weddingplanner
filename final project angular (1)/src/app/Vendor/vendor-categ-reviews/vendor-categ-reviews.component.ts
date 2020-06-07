import { Component, OnInit } from '@angular/core';
import { ReviewService } from 'src/app/_service/review.service';
import { Review } from 'src/app/model/review';
import { CategoryService } from 'src/app/_service/category.service';
import { Reviewadd } from 'src/app/model/reviewadd';
import { Reviewreplay } from 'src/app/model/reviewreplay';
import { Category } from 'src/app/model/category';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { Rate } from 'src/app/model/rate';

@Component({
  selector: 'app-vendor-categ-reviews',
  templateUrl: './vendor-categ-reviews.component.html',
  styleUrls: ['./vendor-categ-reviews.component.css']
})


export class VendorCategReviewsComponent implements OnInit {
reviews:Review[];
newreplay:Reviewreplay=new Reviewreplay();
revnum:number;
cats:Category[];
catnum:number=0;
config:any;
//sabt rate
venrate:Rate;
//vendor to get his booking
VendorNo:string ="323db842-2cda-49e3-9092-a8d2bad55e38" 

  constructor(public r:ReviewService,private ser:MyserviceService) { 
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
    
  }
 
  ngOnInit(): void {
    this.r.getallreviews(this.VendorNo).subscribe(a=>{this.reviews=a;console.log(a)});
    this.r.getallreplays();
    this.ser.GetVenCategories(this.VendorNo).subscribe(
      a=>{this.cats=a;
        console.log(a)
        this.catnum=this.cats[0].cat_Id;})

  // this.ser.GetVenrate(this.VendorNo).subscribe(a=>{this.venrate=a;
  // console.log(this.venrate)})
          
  }
  
  qqq(q:number){
    console.log(q);
    this.revnum=q;
    console.log(this.revnum);
  }
add(){
this.newreplay.Review_Id=this.revnum;
this.newreplay.PostDate=new Date().toString();
this.newreplay.User_Id="1251612f-0aff-414c-a1fc-8fa489472b64";
this.newreplay.Vendor_Id="1251612f-0aff-414c-a1fc-8fa489472b65";
console.log(this.revnum);
console.log(this.newreplay);

     this.r.postreplay(this.newreplay).subscribe(res=>{
     this.r.getallreplays();
   },
     err=>{
      console.log(err);
   })

}

pageChanged(event){
  this.config.currentPage = event;
 }
}

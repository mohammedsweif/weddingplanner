import { Component, OnInit } from '@angular/core';
import { ReviewService } from 'src/app/_service/review.service';
import { Review } from 'src/app/model/review';
import { CategoryService } from 'src/app/_service/category.service';
import { Reviewadd } from 'src/app/model/reviewadd';
import { Reviewreplay } from 'src/app/model/reviewreplay';
import { Category } from 'src/app/model/category';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { Rate } from 'src/app/model/rate';
import { Reviews } from 'src/app/_models/review';
import { reply } from 'src/app/model/reply';

@Component({
  selector: 'app-vendor-categ-reviews',
  templateUrl: './vendor-categ-reviews.component.html',
  styleUrls: ['./vendor-categ-reviews.component.css']
})


export class VendorCategReviewsComponent implements OnInit {

  UserN:string=""
reviews:Review[]=[];
replies:Reviewreplay[]=[]
newreplay:reply=new reply();
revnum:number;
cats:Category[];
catnum:number=0;
config:any;
venrate:Rate;

VendorNo:string ="e75335e1-23f7-44c7-bac0-e6c35f5bd732" 
divReviewId:number=0
rev:Review=new Review()
  constructor(public r:ReviewService,private ser:MyserviceService) { 
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
  }
 
  ngOnInit(): void {
    this.r.getallreviews(this.VendorNo).subscribe(a=>{this.reviews=a;console.log(a)});
    this.r.getallreplays()

    this.ser.GetVenCategories(this.VendorNo).subscribe(
      a=>{this.cats=a;
        console.log(a)
        this.catnum=this.cats[0].cat_Id;})

  // this.ser.GetVenrate(this.VendorNo).subscribe(a=>{this.venrate=a;
  // console.log(this.venrate)})
          
  }
  revid:number;
  show:boolean=false;
  display(id:number){
    this.show= !this.show;
    this.revid=id; 
  }
  changeNumber(q:number,userid:string){
    console.log(q);
    this.revnum=q;
    this.UserN=userid;
    console.log(this.revnum);
    console.log("user No",this.UserN);
  }

  showDiv(id:number) {
    document.getElementById('myReplyDiv').style.display ="block"
    this.divReviewId=id;
    
 }

add(){
 this.newreplay.Review_Id=this.revnum;
 this.newreplay.PostDate=Date.now().toString()
 this.newreplay.liked=false
 this.newreplay.User_Id="46747598-f609-4aef-8438-43473ea3c23c"
 this.newreplay.Vendor_Id=this.VendorNo;
// console.log(this.revnum);
 console.log(this.newreplay);

      this.r.postreplay(this.newreplay).subscribe(res=>{
        this.r.getallreviews(this.VendorNo).subscribe(a=>{this.reviews=a;console.log(a)});
    },
      err=>{
        console.log(err);
    })



}

pageChanged(event){
  this.config.currentPage = event;
 }

 toggleLike(item:Reviewreplay){
    item.liked=!item.liked
    this.r.toggleReply(item).subscribe(a=>console.log(a))
 }

 toggleLikeR(item:Review){
  item.liked=!item.liked
  this.r.toggleReview(item).subscribe(a=>console.log(a))
 }

}

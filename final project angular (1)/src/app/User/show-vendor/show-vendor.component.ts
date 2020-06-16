import { Component, OnInit } from '@angular/core';
import { Vendordetails } from 'src/app/model/vendordetails';
import { VendordetailsService } from 'src/app/_service/vendordetails.service';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';
import {ActivatedRoute} from '@angular/router'

import { Rate } from 'src/app/model/rate';
import { ReviewService } from 'src/app/_service/review.service';
import { Review } from 'src/app/model/review';
import { UserReviewService } from 'src/app/_service/user-review.service';
import { Reviews } from 'src/app/_models/review';
import { Works } from 'src/app/VendorWorksModel/VWorks';



@Component({
  selector: 'app-show-vendor',
  templateUrl: './show-vendor.component.html',
  styleUrls: ['./show-vendor.component.css']
})
export class ShowVendorComponent implements OnInit {
 vendetails:Vendordetails=new Vendordetails();
 VendorNo:string ="e75335e1-23f7-44c7-bac0-e6c35f5bd732";
 vendorrate:Rate;
 reviews:Reviews[]=[];
 Cat:Array<any>;
 AllReview:Reviews[]=[];
 works:Works[]=[]
 Allworks:Works[]=[]

constructor(private s:VendordetailsService,private ss:MyserviceService,public r:ReviewService,public d:UserReviewService,private _route:ActivatedRoute) { }

  ngOnInit(): void {
    let id:string="";
    this._route.paramMap.subscribe(params=>{
      id = params.get("id");
      this.s.getvendordetails(id).subscribe(
        a=>{this.vendetails=a;
          console.log(a)
        })
      })

    // this.reviews=[];
    // this.s.getvendordetails(this.VendorNo).subscribe(
    // a=>{this.vendetails=a;
    //   console.log(a)
    // })

    // this.ss.GetVenrate(this.VendorNo).subscribe(a=>{this.vendorrate=a;
    // console.log(a)})
    this.d.GetReviewsv(this.VendorNo).subscribe(a=>{
      console.log(a)
      this.AllReview= a as Reviews[]
      this.reviews=this.AllReview;
      this.Cat=[... new Set(this.AllReview.map(a=>a.category))]
  
  
    });
    this.d.Getworks(this.VendorNo).subscribe(a=>{
      console.log(a)
      this.Allworks= a as Works[]
      this.works=this.Allworks;
      console.log(this.works)
    });
    }

}

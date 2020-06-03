import { Component, OnInit } from '@angular/core';
import { Vendordetails } from 'src/app/model/vendordetails';
import { VendordetailsService } from 'src/app/_service/vendordetails.service';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { NgbRatingConfig } from '@ng-bootstrap/ng-bootstrap';

import { Rate } from 'src/app/model/rate';
import { ReviewService } from 'src/app/_service/review.service';
import { Review } from 'src/app/model/review';



@Component({
  selector: 'app-show-vendor',
  templateUrl: './show-vendor.component.html',
  styleUrls: ['./show-vendor.component.css']
})
export class ShowVendorComponent implements OnInit {
 vendetails:Vendordetails=new Vendordetails();
 VendorNo:string ="e75335e1-23f7-44c7-bac0-e6c35f5bd732";
 vendorrate:Rate;
 
 
constructor(private s:VendordetailsService,private ss:MyserviceService,public r:ReviewService) { }

  ngOnInit(): void {
    this.r.reviews=[];
    this.s.getvendordetails(this.VendorNo).subscribe(
    a=>{this.vendetails=a;
      console.log(a)
    })
    this.ss.GetVenrate(this.VendorNo).subscribe(a=>{this.vendorrate=a;
    console.log(a)})
   this.r.getallreviews(this.VendorNo);
   
  }

}

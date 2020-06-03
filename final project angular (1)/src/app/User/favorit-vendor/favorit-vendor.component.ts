import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ClientVendorsViewModel } from 'src/app/BookingModel/ClientVendors';
import { category } from 'src/app/CategoryModel/category';
import { Subscription } from 'rxjs';
import { MyserviceService } from 'src/app/_service/myservice.service';
import{ NgInitDirective} from '../ng-init-directive'
import { Rating } from 'src/app/RatingModel/Rating';


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
  UserNo:string ="2620e326-0f8c-4ad3-ad5d-5de3d3096beb" 
  TotalNumber:number
  page:number=1

  constructor(private ser:MyserviceService) { }

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
}

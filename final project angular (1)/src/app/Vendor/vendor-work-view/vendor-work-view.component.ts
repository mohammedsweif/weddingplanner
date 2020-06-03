import { Component,NgModule, OnInit ,Injectable} from '@angular/core';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { VWorks } from 'src/app/VendorWorksModel/VWorks';
import { Subscription, interval } from 'rxjs';
import { category } from 'src/app/CategoryModel/category';
import * as bootstrap from "bootstrap";
import * as $ from "jquery";
import { Rate } from 'src/app/model/rate';

@Component({
  selector: 'app-vendor-work-view',
  templateUrl: './vendor-work-view.component.html',
  styleUrls: ['./vendor-work-view.component.css']
})
export class VendorWorkViewComponent implements OnInit {
  Works:VWorks[]=[]
  categories:category[]=[]
  AllCategories:category[]=[]
  subs:Subscription
  venrate:Rate;
  
  config :any;
  vendor_no:string="891372ef-93a8-49cd-aa5e-04bff5c1538a"     //get userId from localStorage
  
  catnum:number=0 
  catnum1:number
  catnum2:number
  
 
  NewWork:VWorks = {};
  addWork:VWorks = {};

  constructor(private WorkService:MyserviceService) {
    this.config = {
      itemsPerPage: 2,
      currentPage: 1
    }
   }
  

  ngOnInit(): void {
    //  const int=interval(100);
    

    this.subs=this.WorkService.getWorks().subscribe(
      a=>{
        this.Works=a;
        console.log(this.Works);
      }
      )
      this.addWork.category_id=1

      this.subs=this.WorkService.GetVenCategories(this.vendor_no).subscribe(
        a=>{this.categories=a;
          console.log(this.categories);}
      )
      ///////////rate of vendor
      this.WorkService.GetVenrate(this.vendor_no).subscribe(a=>{this.venrate=a;
      console.log(this.venrate)})
      
 }
  
 getImage(event) {
   console.log('image =', event);
 }

  Delete(id){
    if(confirm("Are you sure to delete this item ?")) {
      this.WorkService.deleteWork(id).subscribe(()=>{console.log(id);
        this.WorkService.getWorks().subscribe(a=>this.Works=a);
      })
    }
  }

change(value:number){
console.log(value);
this.catnum=value;

}

changeCateg(categoryId:number){
  console.log(categoryId);
  this.catnum=categoryId;
  // call service get works related to chosen batti5
  // this.WorkService.getWorks(categoryId).subscribe(a=>this.Works=a);
  }

changeEdit(value:number){
  console.log(value);
  this.catnum1=value;
  this.NewWork.category_id =this.catnum1;
  }

  changeAdd(value:number){
    console.log(value);
    this.catnum2=value;
    this.addWork.category_id =this.catnum2;
    }

edit(id:number){
  console.log(id);
  this.WorkService.getOne(id).subscribe(a=>this.NewWork=a); 
}

Add(){
  this.addWork.image="ebdhedbhebd"
  this.addWork.vendor_id=this.vendor_no
  this.addWork.last_updated=new Date().toString();
  this.WorkService.addWork(this.addWork).subscribe(data =>{console.log("Added"+ data);
  this.WorkService.getWorks().subscribe(a=>this.Works=a);})
  this.addWork=new VWorks();
  // $('#exampleModal11').modal('hide');
}
Update(){
  this.NewWork.image="ebdhedbhebd"
  this.NewWork.vendor_id=this.vendor_no
   this.NewWork.last_updated=new Date().toString();
    this.WorkService.editWork(this.NewWork).subscribe(data =>{console.log("updated"+ data);
    this.WorkService.getWorks().subscribe(a=>this.Works=a);})
    this.NewWork=new VWorks();
}
pageChanged(event){
  this.config.currentPage = event;
 }
}

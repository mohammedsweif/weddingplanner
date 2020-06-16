import { Component,NgModule, OnInit ,Injectable } from '@angular/core';
import { Package } from 'src/app/PackageModel/Package';
import { PackageServiceService } from 'src/app/_service/package-service.service';
import {MyserviceService} from 'src/app/_service/myservice.service'
import { Subscription } from 'rxjs';
import { season } from 'src/app/SeasonModel/season';
import { Event } from '@angular/router';
import { Eveent } from 'src/app/EventModel/Eveent';
import { packagefeatures } from 'src/app/FeatureModel/Packagefeatures';
import { category } from 'src/app/CategoryModel/category';

@Component({
  selector: 'app-vendor-packages',
  templateUrl: './vendor-packages.component.html',
  styleUrls: ['./vendor-packages.component.css']
})
export class VendorPackagesComponent implements OnInit {
  subs:Subscription
  newpackage:Package=new Package();
  editPackage:Package=new Package();
  addPackage:Package =new Package();
  categories:category[]=[]
  Packages:Package[]=[]
  Seasons:season[]=[]
  Eventss:Eveent[]=[]
  Features:packagefeatures[]=[]

  catnumC:number=0
  catnumE:number=0
  catnumS:number=0

  catnumC1:number=0
  catnumE1:number=0
  catnumS1:number=0
  TotalNumber:number
  page:number=1
  packageCount:number
  config:any;

 
  VendorNo:string ="98909ee6-aa65-400d-8587-ab06e92b4717"                    //get from localstrorage
 

  constructor(private ser:PackageServiceService,private WorkService:MyserviceService) { 
    this.config = {
      itemsPerPage: 3,
      currentPage: 1}
  }

  ngOnInit(): void {

   this.subs=this.ser.getallpackages().subscribe(
      a=>{
        this.Packages=a;
        console.log(this.Packages);
        })

     
      this.subs=this.ser.getEvent(this.VendorNo).subscribe(
        a=>{
          this.Eventss=a;
          console.log(this.Eventss);
          this.packageCount=this.Packages.length
        }
        ) 

        this.subs=this.ser.getSeason(this.VendorNo).subscribe(
          a=>{
            this.Seasons=a;
            console.log(this.Seasons);
          }
          ) 

        // this.subs=this.ser.getFeatures(this.VendorNo).subscribe(
        //   a=>{
        //     this.Features=a;
        //     console.log(this.Features);
        //   }) 


          this.subs=this.WorkService.GetVenCategories(this.VendorNo).subscribe(
            a=>{this.categories=a;
              console.log(this.categories);}
          )
    }


    changeCat(value:number){
      console.log(value);
      this.catnumC=value;
      this.addPackage.catagory_id =this.catnumC;
      }

      

        changeSes(value:number){
          console.log(value);
          this.catnumS=value;
          this.addPackage.season_id =this.catnumS;
          }

         changeEv(value:number){
            console.log(value);
            this.catnumE=value;
            this.addPackage.event_id =this.catnumE;
            console.log(this.addPackage.event_id)
            }


            changeCat1(value:number){
              console.log(value);
              this.catnumC1=value;
              // this.addPackage.catagory_id =this.catnumC1;
              }
        
              
        
                changeSes1(value:number){
                  console.log(value);
                  this.catnumS1=value;
                 // this.addPackage.season_id =this.catnumS1;
                  }
        
                 changeEv1(value:number){
                    console.log(value);
                    this.catnumE1=value;
                ///    this.addPackage.event_id =this.catnumE1;
                    }

    Add(){
    
      this.addPackage.vendorId=this.VendorNo
      // this.addWork.last_updated=new Date().toString();
      this.ser.postpackage(this.addPackage).subscribe(data =>{
        this.ser.getallpackages().subscribe(
          a=>{
            this.Packages=a;
            console.log(this.Packages);
            })
        console.log("Added"+ data);
      
    })
    this.addPackage=new Package();
}

EditPackage(){
  this.addPackage.vendorId=this.VendorNo
   this.ser.putpackage(this.editPackage).subscribe(data=>{
     console.log("edited"+ data);
     this.ser.getallpackages().subscribe(a=>{this.Packages=a;console.log(this.Packages);})
   })
   this.editPackage=new Package();
}


edit(id:number){
  console.log(id);
  this.ser.getOnePackage(id).subscribe(a=>this.editPackage=a); 
}


delete(id:number){
  console.log(id);
  this.ser.deletepackage(id).subscribe(res=>{
    console.log(res)
    this.ser.getallpackages().subscribe(
      a=>{
        this.Packages=a;
        console.log(this.Packages);
        })
  })

}
pageChanged(event){
  this.config.currentPage = event;
 }

}

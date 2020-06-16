import { Component, OnInit } from '@angular/core';
import { Subscription, interval } from 'rxjs';
import { category } from 'src/app/CategoryModel/category';
import { venBudgets } from 'src/app/VendorDataModel/venBudgets';
import { MyserviceService } from 'src/app/_service/myservice.service';

@Component({
  selector: 'app-vendor-budget',
  templateUrl: './vendor-budget.component.html',
  styleUrls: ['./vendor-budget.component.css']
})
export class VendorBudgetComponent implements OnInit {
  VendorData:venBudgets[]=[]
  categories:category[]=[]
  noBudgetList:category[]=[]

  
  editVendorBudgetlist:venBudgets[]=[]
  subs:Subscription
  vendor_no:string="e75335e1-23f7-44c7-bac0-e6c35f5bd732"     //get userId from localStorage

  TotalForCateg:number=0
  TotalPending:number=0
  TotalPaid:number=0

  catnum:number=0 
  catnum2:number=0

  catnumE:number=0

  addVendorBudget:venBudgets={}
  editVendorBudget:venBudgets={}

  constructor(private VendorService:MyserviceService) { }

  ngOnInit(): void {
    
    this.subs=this.VendorService.getVenData(this.vendor_no).subscribe(
      a=>{
        this.VendorData=a;
        console.log(this.VendorData);
      }
      )
      
     
      this.subs=this.VendorService.GetVenCategories(this.vendor_no).subscribe(
        a=>{this.categories=a;
          console.log(this.categories);}
      )

      this.subs=this.VendorService.GetNoBudgetCateg(this.vendor_no).subscribe(
        a=>{this.noBudgetList=a;
          console.log(this.noBudgetList);}
      )

  

      // this.noBudgetList=this.VendorData.filter(f=>f.cat_budget===null)
  }

  changeCateg(value:number){
    console.log(value);
    this.catnum=value;
    //this.addVendorBudget.catt_id =this.catnum;
    this.TotalForCateg=0
    this.TotalPaid=0
    this.TotalPending=0
    
    }

    changeEdit(value:number){
      console.log(value);
      this.catnumE=value;
      this.editVendorBudget.catt_id =this.catnumE;
      
      
      }
  changeAdd(value:number){
    console.log(value);
    this.catnum2=value;
    this.addVendorBudget.catt_id =this.catnum2;
    }

    

    Add(){
    
      this.addVendorBudget.vendor_id=this.vendor_no
      this.VendorService.addInVendor(this.addVendorBudget).subscribe(data =>{
        
        console.log("Added"+ data);
        this.VendorService.getVenData(this.vendor_no).subscribe(
          a=>{
            this.VendorData=a;
            console.log(this.VendorData);
          }
          )
          
      
    })
    this.addVendorBudget=new venBudgets();
}

EditBudget(){
  this.editVendorBudget.vendor_id=this.vendor_no
   this.VendorService.putBudget(this.editVendorBudget).subscribe(data=>{
     console.log("edited"+ data);
     this.VendorService.getVenData(this.vendor_no).subscribe(
      a=>{
        this.VendorData=a;
        console.log(this.VendorData);
      }
      )
   })
   this.editVendorBudget=new venBudgets();
}


edit(id:string,id1:number){
  console.log(id);
  
  this.VendorService.getOneBudgetData(id,id1).subscribe(a=>this.editVendorBudget=a); 
  // this.editVendorBudget=this.editVendorBudgetlist.find(f=>f.vendor_id==this.vendor_no)
}

GetTotal(id:string,id1:number){
    this.subs=this.VendorService.GetTotalBudget(id,id1).subscribe(a=>{this.TotalForCateg=a;console.log(a)})
    this.subs=this.VendorService.GetTotalBudgetPaid(id,id1).subscribe(a=>{this.TotalPaid=a;console.log(a)})
    this.subs=this.VendorService.GetTotalBudgetPending(id,id1).subscribe(a=>{this.TotalPending=a;console.log(a)})
}
}

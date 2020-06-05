import { Component, OnInit } from '@angular/core';
import { category } from 'src/app/CategoryModel/category';
import {MyserviceService} from 'src/app/_service/myservice.service'
import { Subscription } from 'rxjs';
import { VendorClientViewModel } from 'src/app/BookingModel/VendorClientViewModel';

@Component({
  selector: 'app-categ-clients',
  templateUrl: './categ-clients.component.html',
  styleUrls: ['./categ-clients.component.css']
})
export class CategClientsComponent implements OnInit {

  VendorClients:VendorClientViewModel[]=[]
  catnumC:number=0
  categories:category[]=[]
  subs:Subscription
  TotalNumber:number
  page:number=1
  VendorNo:string ="891372ef-93a8-49cd-aa5e-04bff5c1538a" 
  modalUserName:string=""
  modalUserId:string=""

  constructor(private ser:MyserviceService) { }

  ngOnInit(): void {
    this.subs=this.ser.getVenClients(this.VendorNo).subscribe(
      a=>{
        this.VendorClients=a;
        console.log(this.VendorClients);
        
      }
      )

      this.subs=this.ser.GetVenCategories(this.VendorNo).subscribe(
        a=>{this.categories=a;
          console.log(this.categories);}
      )

  }

  changeCat(value:number){
    console.log(value);
    this.catnumC=value;
    
    }
    clientname:string="";
    search(f){
      this.clientname = f.value;
      console.log(f.value);
      console.log(this.clientname);
    }

    sendUserName(name:string,id:string){
      this.modalUserName=name;
      this.modalUserId=id;
    }
}

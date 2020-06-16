import { Component, OnInit } from '@angular/core';
import {ShopServiceService} from '../../_service/Shop/shop-service.service';
import { Getproduct, product } from 'src/app/_models/product';
import { ShoppingCart } from 'src/app/_models/shop/shopping-cart';


@Component({
  selector: 'app-shop-home',
  templateUrl: './shop-home.component.html',
  styleUrls: ['./shop-home.component.css']
})
export class ShopHomeComponent implements OnInit {

  constructor(private ShopServ:ShopServiceService) { }
  ProductType:Array<any>
  products:Getproduct[]=[]
  AllProcuts:Getproduct[]=[]
  //productInfoCart:Getproduct[] = [];
  ShoppingCart:ShoppingCart[];
  ngOnInit(): void {
    this.ShopServ.getAllProductType().subscribe(type=>{console.log(type)
    this.ProductType= type as Array<any>
    
    })
    this.ShopServ.getAllProduct().subscribe(product=>{
      console.log(product)
      this.AllProcuts= product as Getproduct[]
    this.products=  this.AllProcuts
    })
  }
  FilterProduct(Id:any){
    if(Id=="0"){
       this.products=this.AllProcuts;
    }else{
      this.products= this.AllProcuts.filter(product=>product.type_id==Id)   
    }
    
  }
  
onClickCart(product:Getproduct){
  console.log(product);
  let item =new ShoppingCart(product.product_id,product.product_name,1,product.price,product.product_image);
   this.ShopServ.AddItemToLocalStorage(item);
 }

 
}


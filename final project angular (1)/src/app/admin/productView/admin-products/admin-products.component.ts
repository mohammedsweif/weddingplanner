import { Component, OnInit } from '@angular/core';
import { AdminProductServiceService } from 'src/app/_service/adminService/admin-product-service.service';
import { Subscription } from 'rxjs';
import { product } from 'src/app/_models/product';
import { productType } from 'src/app/_models/productType';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit {
Products:product[]=[]
subscription:Subscription
newProduct:product=new product()
editProduct:product=new product()

typenum:number=0
typenum1:number=0
types:productType[]=[]
TotalNumber:number
page:number=1
type:productType=new productType()
newType:productType=new productType()

  constructor(private ser:AdminProductServiceService) { }

  ngOnInit(): void {
  
    this.subscription=this.ser.getProducts().subscribe(a=>{this.Products=a;console.log(a)})
    this.subscription=this.ser.getTypes().subscribe(a=>{this.types=a;console.log(a)})
  }
Delete(id:number){
  this.ser.deleteProduct(id).subscribe(a=>{console.log(a);
    this.ser.getProducts().subscribe(a=>{this.Products=a;console.log(a)})
  })

}
  Add(){
    
    // this.newProduct.type_id=this.newType.type_id
    this.newProduct.product_image="ccchfhregfhg"
    this.ser.addProduct(this.newProduct).subscribe(a=>{console.log(a);this.ser.getProducts().subscribe(a=>{this.Products=a;console.log(a)})})
    
  }
  AddType(){
    this.ser.addType(this.newType).subscribe(a=>{this.ser.getTypes().subscribe(a=>{this.types=a;console.log(a)});console.log(a)})
  }

  editOne(x:number){
    this.ser.getOneProduct(x).subscribe(a=>this.editProduct=a)
  }

  Edit(){
    this.editProduct.type_id=this.type.type_id
    this.editProduct.product_image="ccchfhregfhg"
    
    this.ser.editProduct(this.editProduct).subscribe(a=>{console.log(a);this.ser.getProducts().subscribe(a=>{this.Products=a;console.log(a)})})
    this.editProduct=new product()
   
  }
  changeEdit(value:number){
    console.log(value);
    this.typenum=value;
    this.type.type_id =this.typenum;
    }
  
    changeAdd(value:number){
      console.log(value);
      this.typenum1=value;
      this.newType.type_id =this.typenum1;
      }

}





import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ShopServiceService} from '../../_service/Shop/shop-service.service';
import {Getproduct} from '../../_models/product';
import { ShoppingCart } from 'src/app/_models/shop/shopping-cart';
@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {
  product:Getproduct= new Getproduct();
  constructor(private ActiveRoute:ActivatedRoute,private shopServ:ShopServiceService) { 
  }

  ngOnInit(): void {
    let id=0;
    this.ActiveRoute.paramMap.subscribe(parm=>{

     id =+ parm.get("id");
     console.log(id);
     this.shopServ.getProductById(id).subscribe(prod=>{
       this.product=prod as Getproduct;
     })
    }) 
  }
  onClickCart(){
    let item =new ShoppingCart(this.product.product_id,this.product.product_name,1,this.product.price,this.product.product_image);
     this.shopServ.AddItemToLocalStorage(item);
   }
}

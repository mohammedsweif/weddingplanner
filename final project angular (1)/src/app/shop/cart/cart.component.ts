import { Component, OnInit } from '@angular/core';
import { Getproduct, product } from 'src/app/_models/product';
import { ShopServiceService } from 'src/app/_service/Shop/shop-service.service';
import { ShoppingCart } from 'src/app/_models/shop/shopping-cart';
import { OrderDetails } from 'src/app/_models/order-details';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  totalCost:number=0;
  Shippingandhandling:number=10;
  ShoppingCart:ShoppingCart[];
  constructor(private shopServ:ShopServiceService,private toast:ToastrService) {}

  ngOnInit(): void {
  this.ShoppingCart =  this.shopServ.getProductsFromLocalStorage();
  }
  raiseQtu(ID:number){
    this.shopServ.increase(ID);
    this.ShoppingCart=this.shopServ.getProductsFromLocalStorage();
  }
  MinQtu(ID:number){
    this.shopServ.decrease(ID);
    this.ShoppingCart=this.shopServ.getProductsFromLocalStorage();
  }
  DeleteItem(ID:number){
    this.shopServ.Remove(ID)
    this.ShoppingCart =  this.shopServ.getProductsFromLocalStorage();
  }
  GetFullPrice(){
    this.totalCost=this.shopServ.totalPrice()+this.Shippingandhandling;
    return this.shopServ.totalPrice();
  }
  submitOrder(){
    let ord = new OrderDetails();
    ord.Id="9ac14584-d5c9-4921-b2cd-006db299adbc";
    ord.OrderDetails = this.shopServ.getProductsFromLocalStorage();
    this.shopServ.postOrder(ord).subscribe(a=>{
      console.log(a);
   
    });
    this.toast.success("You Made an Order","Please Wait till it finish");
    this.shopServ.clear();
    this.ShoppingCart= this.shopServ.getProductsFromLocalStorage();
   

  }


}

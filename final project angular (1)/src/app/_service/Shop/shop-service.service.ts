import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {ShoppingCart} from '../../_models/shop/shopping-cart';
import { OrderDetails } from 'src/app/_models/order-details';
@Injectable({
  providedIn: 'root'
})
export class ShopServiceService {
  header={
    headers:new HttpHeaders({
        "Content-Type":"Application/Json"
    })
  }
  constructor(private http:HttpClient) { 
    if(localStorage.getItem("shoppingcart")==null)
    localStorage.setItem("shoppingcart",JSON.stringify([]));
  }
  getAllProductType(){
return this.http.get("http://localhost:50414/ShopHome/GetAllProductType");
  }
  getAllProduct(){
    return this.http.get("http://localhost:50414/ShopHome/GetAllProduct");
  }
  getProductById(id){
    return this.http.get(`http://localhost:50414/ShopHome/GetProudctById/${id}`)
  }
  AddItemToLocalStorage(Item:ShoppingCart){
    let cart:ShoppingCart[] = JSON.parse(localStorage.getItem("shoppingcart"));
    if(cart.findIndex(a=>a.ProductID== Item.ProductID) == -1){
      Item.FullPrice= Item.Price*Item.Qtu;
      cart.push(Item);
    }else{
     let index  =  cart.findIndex(a=>a.ProductID== Item.ProductID);
     cart[index].Qtu++;
     cart[index].FullPrice= Item.Price* cart[index].Price; 
    }
    localStorage.setItem("shoppingcart",JSON.stringify(cart));
  }
  getProductsFromLocalStorage():ShoppingCart[]{
    return JSON.parse(localStorage.getItem("shoppingcart"));
  }
  GetNoOfElementInCart():number{
    return (<ShoppingCart[]>JSON.parse(localStorage.getItem("shoppingcart"))).length;
  }
  increase(ID:number){
    let cart:ShoppingCart[]=JSON.parse(localStorage.getItem("shoppingcart"));
    let index= cart.findIndex(a=>a.ProductID==ID);
    cart[index].Qtu++;
    cart[index].FullPrice= cart[index].Price*cart[index].Qtu;
    localStorage.setItem("shoppingcart",JSON.stringify(cart));
  }
  decrease(ID:number){
    let cart:ShoppingCart[]=JSON.parse(localStorage.getItem("shoppingcart"));
    let index= cart.findIndex(a=>a.ProductID==ID);
    if(index ==-1){
      return
    }else{
      if(cart[index].Qtu>0){
        cart[index].Qtu--;
        cart[index].FullPrice= cart[index].Price*cart[index].Qtu;
        localStorage.setItem("shoppingcart",JSON.stringify(cart));
      }else{
        return;
      }
      
    }
  }
  Remove(ID){
    let cart:ShoppingCart[]=JSON.parse(localStorage.getItem("shoppingcart"));
    let index= cart.findIndex(a=>a.ProductID==ID);
    if(index== -1){
      return;
    }else{
      cart.splice(index,1);
      localStorage.setItem("shoppingcart",JSON.stringify(cart));
    }
  }
  totalPrice(){
    let price=0;
    let cart:ShoppingCart[]=JSON.parse(localStorage.getItem("shoppingcart"));
    cart.forEach(a=>{
      price+=a.FullPrice;
    })
    return price;
  }
  clear(){
    localStorage.setItem("shoppingcart",JSON.stringify([]));
  }
  postOrder(order:OrderDetails){
    return this.http.post("http://localhost:50414/ShopHome/PostOrder",order,this.header);
  }
}

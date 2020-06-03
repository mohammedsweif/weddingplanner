import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/_service/user-service.service';
import { Subscription } from 'rxjs';
import { UserBooks } from 'src/app/_models/UserBooks';

@Component({
  selector: 'app-client-book-cat',
  templateUrl: './client-book-cat.component.html',
  styleUrls: ['./client-book-cat.component.css']
})
export class ClientBookCatComponent implements OnInit {
subscription:Subscription
userNo:string="2620e326-0f8c-4ad3-ad5d-5de3d3096beb"

UserBooks:UserBooks[]=[]
TotalNumber:number
page:number=1
  constructor(private UserService:UserServiceService) { }

  ngOnInit(): void {

    this.subscription=this.UserService.GetClientBooks(this.userNo).subscribe(a=>{this.UserBooks=a;console.log(a)})
   
  }

  DeleteBooking(id:number){
    this.subscription=  this.UserService.DeleteBooking(id).subscribe(a=>{
      console.log(id)
      this.UserService.GetClientBooks(this.userNo).subscribe(a=>{this.UserBooks=a;console.log(a)})})
      

  }
}

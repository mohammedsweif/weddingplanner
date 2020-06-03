import { Component, OnInit } from '@angular/core'; 
import { Router } from '@angular/router';
import { RegisterServiceService } from 'src/app/_service/register-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private ser:RegisterServiceService,private route:Router) { }
  username:string;
  logout(){
this.ser.logout().subscribe(e=>{
  localStorage.removeItem("token");
  localStorage.removeItem("username");
  localStorage.removeItem("role"); 
  localStorage.removeItem("id");
  this.route.navigate(["Home"]);
});
    
    
  }

  check():boolean{
    if(localStorage.getItem("token") != null){
      this.username=localStorage.getItem("username");
      if(localStorage.getItem("role")=="Admin"){
        this.admin=true;
      }else if(localStorage.getItem("role")=="Vendor"){
        this.vendor=true;
      }else if(localStorage.getItem("role")=="user"){
        this.user=true;
      } 
      return true;
    }
    this.admin=false;
    this.user=false;
    this.vendor=false;
    return false;
  }
  admin=false;
  user=false;
  vendor=false;


  ngOnInit():void {}

}

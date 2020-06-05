import { Component, OnInit } from '@angular/core';
import { AdminuserService } from '../../_service/adminService/adminuser.service';
import { adminuser } from 'src/app/_models/Adminclasses/adminusers';
 

@Component({
  selector: 'app-userstables',
  templateUrl: './userstables.component.html',
  styleUrls: ['./userstables.component.css']
})
export class UserstablesComponent implements OnInit {

  constructor(private ser:AdminuserService) { }
 
allusers:adminuser[]=[];
  ngOnInit(): void {
this.ser.getall().subscribe(ea=>{ this.allusers = ea;
console.log(ea);
console.log(this.allusers);
});

  }
  userides:string[]=[];
  asd(e){
    
    if( this.userides.includes(e)){
      this.userides=this.userides.filter(el=>el != e);
     
    }else{
      this.userides.push(e);
  
    }
    console.log(this.userides);
    
  
  }
  messagecontent="";
  sendids(){
    
     this.ser.senddata(this.userides,this.messagecontent).subscribe(e=>console.log(e));
  }
   
}
import { Component, OnInit } from '@angular/core';
import { adminuser } from 'src/app/_models/Adminclasses/adminusers';
import { AdminuserService } from 'src/app/_service/adminService/adminuser.service';

@Component({
  selector: 'app-userrole',
  templateUrl: './userrole.component.html',
  styleUrls: ['./userrole.component.css']
})
export class UserroleComponent implements OnInit {
    
  constructor(private ser:AdminuserService) { }
  allusers:adminuser[]=[];
  allusers1:adminuser[]=[];

    ngOnInit(): void {
  this.ser.getall().subscribe(ea=>{ this.allusers = ea;
   
   
  this.allusers.sort((a:adminuser,b:adminuser)=>b.books  - a.books );
  console.log(this.allusers);
  
  });
  
    }
    userides:string[]=[];
    asd(e){
      
      if( this.userides.includes(e)){
        this.userides=this.userides.filter(el=>el != e);
        //console.log(e);
      }else{
        this.userides.push(e);
       // console.log(e);
      }
      console.log(this.userides);
      
    
    }
    compare( a, b ) {
      if ( a.last_nom < b.last_nom ){
        return -1;
      }
      if ( a.last_nom > b.last_nom ){
        return 1;
      }
      return 0;
    }
    
  
    sendids(){
      this.ser.senddata(this.userides).subscribe(e=>console.log(e));
    }
     
  }
  
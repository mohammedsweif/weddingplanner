import { Component, OnInit } from '@angular/core';
import { AdminuserService } from 'src/app/_service/adminService/adminuser.service';
import topall from './topall';
import topcat from './topcat';
@Component({
  selector: 'app-top-data',
  templateUrl: './top-data.component.html',
  styleUrls: ['./top-data.component.css']
})
export class TopDataComponent implements OnInit {

  constructor(public ser:AdminuserService) { }
  topuser:topall[]=[];
  topvendor:topall[]=[];
  topcatagory:topcat[]=[];
  ngOnInit(): void {
    
    this.ser.gettopuser().subscribe(e=>{this.topuser=e;console.log(this.topuser);});
    this.ser.gettopvendor().subscribe(e=>{this.topvendor=e;console.log(this.topvendor);});
    this.ser.gettopcatagory().subscribe(e=>{this.topcatagory=e;console.log(this.topcatagory);});
  }
}

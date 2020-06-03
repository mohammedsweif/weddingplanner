import { Component, OnInit } from '@angular/core';
import { UserSellService } from 'src/app/_service/user-sell.service';
import { UserUsed } from 'src/app/_models/user-used';

@Component({
  selector: 'app-used-gellery',
  templateUrl: './used-gellery.component.html',
  styleUrls: ['./used-gellery.component.css']
})
export class UsedGelleryComponent implements OnInit {
useds:UserUsed[];
TotalNumber:number
page:number=1
  constructor(public s:UserSellService) { }

  ngOnInit(): void {
    this.getall();
  }
  getall(){
    this.s.getAllUsed().subscribe(
      a=>{
        this.useds=a;
      console.log(a)});
  }
  

}

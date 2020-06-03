import { Component, OnInit } from '@angular/core';
import { UserSellService } from 'src/app/_service/user-sell.service';
import { UserUsed } from 'src/app/_models/user-used';
import { Router } from '@angular/router';
import { UserUsedPost } from 'src/app/_models/user-used-post';

@Component({
  selector: 'app-user-used',
  templateUrl: './user-used.component.html',
  styleUrls: ['./user-used.component.css']
})
export class UserUsedComponent implements OnInit {
  useds:UserUsedPost[];
  used:UserUsed;
  constructor(public s:UserSellService, public rout:Router) { }

  ngOnInit(): void {
    this.used=new UserUsedPost();
    this.used={
      piece_id:0,
      userseller_id:'12C',
      status:false,
      piece_Cost:null,
      Image:'2.png',
      piece_description:null,
      publish_date:new Date('2020-02-04T00:00:00'),
      available_date:new Date('2020-02-04T00:00:00')
     
    }
    
  }
  save()
  {
    this.s.addselled(this.used).subscribe(a=>
      {
        console.log(a);
        console.log("fffffffffff");
        this.rout.navigateByUrl("/User/:3/userGellery");
      },
     err=> {
       console.log(err);
     }
      )
  }

}

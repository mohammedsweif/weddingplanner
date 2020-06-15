import { Component, OnInit } from '@angular/core';
import {UserInfoService} from '../../_service/user-info.service';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(private UserInfo:UserInfoService) { }
id:string="9ac14584-d5c9-4921-b2cd-006db299adbc";
user:any;
  ngOnInit(): void {
    this.UserInfo.getUserInfo(this.id).subscribe(a=>{
      console.log(a); 
      this.user = a});
  }

}

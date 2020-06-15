import { Component, OnInit } from '@angular/core';
import {UserInfoService} from '../../_service/user-info.service';

@Component({
  selector: 'app-vendor-profile',
  templateUrl: './vendor-profile.component.html',
  styleUrls: ['./vendor-profile.component.css']
})
export class VendorProfileComponent implements OnInit {

  constructor(private UserInfo:UserInfoService) { }
  id:string="9ac14584-d5c9-4921-b2cd-006db299adbc";
  user:any;
  ngOnInit(): void {
    this.UserInfo.getUserInfo(this.id).subscribe(a=>{
      console.log(a); 
      this.user = a});
  }
}

import { Component, OnInit } from '@angular/core';
import {UserInfoService} from '../../_service/user-info.service';

@Component({
  selector: 'app-vendor-profile',
  templateUrl: './vendor-profile.component.html',
  styleUrls: ['./vendor-profile.component.css']
})
export class VendorProfileComponent implements OnInit {

  constructor(private UserInfo:UserInfoService) { }
  id:string="98909ee6-aa65-400d-8587-ab06e92b4717";
  user:any;
  ngOnInit(): void {
    this.UserInfo.getUserInfo(this.id).subscribe(a=>{
      console.log(a); 
      this.user = a});
  }
}

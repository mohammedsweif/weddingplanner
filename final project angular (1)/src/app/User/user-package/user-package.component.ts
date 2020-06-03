import { Component, OnInit } from '@angular/core';
import { UserpackagesService } from '..//../_service/userpackages.service';
import {ActivatedRoute} from '@angular/router';
import {Packages} from '../../_models/Packages';
@Component({
  selector: 'app-user-package',
  templateUrl: './user-package.component.html',
  styleUrls: ['./user-package.component.css']
})
export class UserPackageComponent implements OnInit {

  //id: string = "aa9b75f8-f926-47eb-b5dc-af8b4efdc225"
  Packages: Packages[]=[];
  constructor(private PackageServ: UserpackagesService,private activated:ActivatedRoute) {
   // this.Packages = new Array<any>();
  }

  ngOnInit(): void {
    let id:string;
    this.activated.paramMap.subscribe(params=>{
      id = params.get("id");
      this.GetPackages(id);
    })
    
  }
  GetPackages(id:string){
    this.PackageServ.getPackage(id).subscribe((data) => {
      console.log(data);
      this.Packages = data as Packages[];
    });
  }
}

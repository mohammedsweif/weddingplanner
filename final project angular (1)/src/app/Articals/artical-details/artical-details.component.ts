import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ArticalsService} from '../../_service/articals.service';
import{Articals} from '../../_models/articals';
@Component({
  selector: 'app-artical-details',
  templateUrl: './artical-details.component.html',
  styleUrls: ['./artical-details.component.css']
})
export class ArticalDetailsComponent implements OnInit {

  constructor(private ActiveRoute:ActivatedRoute,private ArtServ:ArticalsService) { }
artical:Articals;
id:number;
  ngOnInit(): void {
   
    this.ActiveRoute.paramMap.subscribe(param=>{param.get("id")
    this.id =+ param.get("id");
    this.ArtServ.GetArticalDetails(this.id).subscribe(art=>{
      this.artical= art as Articals;
      console.log(this.artical);
    })
  })
  }

}

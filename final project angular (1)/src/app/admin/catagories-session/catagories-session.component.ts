import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/_service/category.service';
import { Category } from 'src/app/model/category';
import { MyserviceService } from 'src/app/_service/myservice.service';
import { Countvendor } from 'src/app/model/countvendor';
import { category } from 'src/app/CategoryModel/category';
//import { Event } from 'src/app/EventModel/'

import { Countevent } from 'src/app/model/countevent';
import { Countseason } from 'src/app/model/countseason';
import { season } from 'src/app/SeasonModel/season';
import { Eveent } from 'src/app/EventModel/Eveent';

@Component({
  selector: 'app-catagories-session',
  templateUrl: './catagories-session.component.html',
  styleUrls: ['./catagories-session.component.css']
})
export class CatagoriesSessionComponent implements OnInit {
  cats:Category[];
  numvendor:Countvendor[];
  numevent:Countevent[];
  numseason:Countseason[];
  newcat:category=new category();
  newevent:Eveent=new Eveent();
  newseason:season=new season();
  
  constructor(public s:MyserviceService) { }

  ngOnInit(): void {  
    this.s.getcountvendor().subscribe(
      a=>{this.numvendor=a;
        console.log(this.numvendor)
      })
this.s.getcountevent().subscribe(
  a=>{this.numevent=a;
  console.log(this.numevent)}
)

this.s.getcountseason().subscribe(
  a=>{this.numseason=a;
  console.log(this.numseason)}
)

    }


// //catagory
    submitcat(){
      console.log(this.newcat);
     this.s.addcat(this.newcat).subscribe(res=>{
     this.s.getcountvendor().subscribe(a=>this.numvendor=a);
     this.newcat.cat_Name="";
     })
    }
    //event
    submitevent(){
      console.log(this.newevent); 
      this.s.addevent(this.newevent).subscribe(res=>{
        this.s.getcountevent().subscribe(a=>this.numevent=a);
        this.newevent.event_name="";
      })
    }
    //season
    submitseason()
    {
      this.s.addseason(this.newseason).subscribe(res=>{
        this.s.getcountseason().subscribe(a=>this.numseason=a);
        this.newseason.season_name="";
        this.newseason.start_time="";
        this.newseason.period="";
      })
    }
   //deletecatagory
    del(item:number){
      console.log(item);
     this.s.deletecatagory(item).subscribe(res=>{
      console.log(res)
      this.s.getcountvendor().subscribe(a=>this.numvendor=a);
      })
    }
    //deleteseason
    dels(item:number){
      this.s.deleteseason(item).subscribe(res=>{
        console.log(res)
        this.s.getcountseason().subscribe(a=>this.numseason=a);
      })
    }
    //deleteevent
    dele(item:number){
      this.s.deletevent(item).subscribe(res=>{
        console.log(res)
        this.s.getcountevent().subscribe(a=>this.numevent=a);
      })
    }
  }


import { Component, OnInit } from '@angular/core';
import { ToDoService } from 'src/app/_service/to-do.service';
import { ToDo } from 'src/app/_models/to-do';

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.css']
})
export class ToDoListComponent implements OnInit {
  does:ToDo[];
  toDo:ToDo;
  constructor(public s:ToDoService) { }

  ngOnInit(): void {
    this.getall();
    this.toDo=new ToDo();
    this.toDo={
      id:0,
      Vendor_Id:"12A",
      Description:null
    }
  }
  getall(){
    this.s.getToDo().subscribe(
      a=>{
        this.does=a;
        console.log("aaaaaaaaaa");
      console.log(a)});
  }
  delete(id)
  {
    this.s.delete(id).subscribe(
      
      a=>{
        this.getall();
        console.log("ddddddd");
        console.log(a)
  });
  }
  datafill(it){
    
    this.toDo.Description=it.Description;
   
  }
  update(){
    this.s.update(this.toDo).subscribe(a=>
      {
        this.s.getToDo().subscribe(
          a=>{
            this.does=a;
            console.log("uuuuuu");
          console.log(a)});
        console.log(a);
        this.s.getToDo();
      },
     err=> {
       console.log(err);
     }
      )
  }
  save()
  {
    this.s.addToDo(this.toDo).subscribe(a=>
      {
        this.s.getToDo().subscribe(
          a=>{
            this.does=a;
            console.log("sssssssss");
          console.log(a)});
        console.log(a);
        this.s.getToDo();
      },
     err=> {
       console.log(err);
     }
      )
  }

}

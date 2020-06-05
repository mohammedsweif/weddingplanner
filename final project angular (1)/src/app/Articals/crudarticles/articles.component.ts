import { Component, OnInit } from '@angular/core';
import {formatDate} from '@angular/common';
import {ArticalsService} from '../../_service/articals.service';
import {Articals, AddArticals} from '../../_models/articals';
import {CategoryService} from '../../_service/category.service';
import {Category} from '../../_models/category';
import {DatePipe} from '@angular/common';
@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {

  constructor(private ArticalServ:ArticalsService ,private CatServ:CategoryService,private datepipe: DatePipe) {
    
   }
articals:Articals[]=[];
category:Category[]=[];
Category:Category;
artical:AddArticals=new AddArticals();
EditArtical:AddArticals=new AddArticals();
ImageUrl:string="";
fileInfo:File=null;
dateNow= new Date();
  ngOnInit(): void {
    this.CatServ.getallcategories().subscribe(data=>{this.category= data as Category[]})
    this.ArticalServ.GetArticals().subscribe(Response=>{
      this.articals= Response as Articals[]

      console.log(this.articals)});
  }
deleteArtical(index:number){
  console.log(index);
  let id= this.articals[index].id;
   this.ArticalServ.DeleteArtical(id).subscribe(a=>{
     console.log(a)
    this.articals.splice(index,1);
   })
}
handleFileInput(file:FileList){
this.fileInfo=file.item(0);
console.log(file);
console.log(this.fileInfo);
var reader= new FileReader();
reader.onload=(event:any)=>{
  console.log(event);
  this.ImageUrl= event.target.result;
  console.log(this.ImageUrl);
}
reader.readAsDataURL(this.fileInfo);
}
onSubmit(){
  this.artical.Id=0;
  this.artical.ImageUrl= this.ImageUrl;
  this.artical.PostDate = this.datepipe.transform(this.dateNow, 'yyyy-MM-dd');;
  this.artical.user_id="9ac14584-d5c9-4921-b2cd-006db299adbc"
  console.log(this.artical);
 this.ArticalServ.AddArticals(this.artical).subscribe(data=>{
  console.log(data)  
  this.articals.push(data as Articals);
  })
  
}
selectEditArtical(index :number){
  console.log(index);
  var art = this.articals[index];
  console.log(art);
  this.EditArtical.Id=art.id;
  this.EditArtical.ImageUrl = art.imageUrl;
  this.EditArtical.PostDate=this.datepipe.transform(art.postDate, 'yyyy-MM-dd');
  this.EditArtical.CatId=art.catId;
  this.EditArtical.user_id=art.user_id;
  this.EditArtical.Article_Title=art.article_Title;
  this.EditArtical.Article_Description=art.article_Description;
  console.log(this.EditArtical);
}
SubmitEdit(){
  this.ArticalServ.EditArtical(this.EditArtical).subscribe(data=>{console.log(data)})
}
}

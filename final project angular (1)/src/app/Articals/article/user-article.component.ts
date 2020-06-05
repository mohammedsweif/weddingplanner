import { Component, OnInit } from '@angular/core';
import {Articals} from '../../_models/articals';
import {ArticalsService} from '../../_service/articals.service';
import {CategoryService} from '../../_service/category.service';
import {Category} from '../../_models/category';
@Component({
  selector: 'app-user-article',
  templateUrl: './user-article.component.html',
  styleUrls: ['./user-article.component.css']
})
export class UserArticleComponent implements OnInit {

  articals:Articals[]=[];
  categories:Category[]=[];
  articalList:Articals[]=[];
  Cat:Category = new Category();

  constructor(private CatServ:CategoryService,private ArticalServ:ArticalsService) { }

  ngOnInit(): void {
    this.ArticalServ.GetArticals().subscribe(data=>{
      this.articalList= data as Articals[];
      this.articals=this.articalList;
    })
    this.CatServ.getallcategories().subscribe(data=>{
      this.categories= data as Category[]
    })
  }
  makeFilter(id:any){
    console.log(id);
    if(id=="0"){
      this.articals=this.articalList;
    }else{
       this.articals=this.articalList.filter(artical=>artical.catId == id);
    }
  }

}

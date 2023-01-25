import { ISubCategory } from './../../shared/interfaces/subcategory';
import { CategoryService } from './../category.service';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ICategory } from 'src/app/shared/interfaces/category';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

    categories: ICategory[] = [];
    subCategories: ISubCategory[] | undefined;
    category! : ICategory | undefined;    
    constructor(private categoryService: CategoryService, private domSinitizer: DomSanitizer){}
    
  ngOnInit(): void {
      this.categoryService.getCategories().subscribe(res=>{
        console.log(res);
        this.categories = res;
     });
  }

  toggle(id: any): void{
   this.category =  this.categories.find(x=>x.id==id);
   this.subCategories = this.category?.hobbySubCategories;
   
  }
}

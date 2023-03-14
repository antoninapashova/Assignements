import { ISubCategory } from './../../shared/interfaces/subcategory';
import { CategoryService } from './../../category/category.service';
import { SubCategoryService } from './../sub-category.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ICategory } from 'src/app/shared/interfaces/category';

@Component({
  selector: 'app-add-subcategory',
  templateUrl: './add-subcategory.component.html',
  styleUrls: ['./add-subcategory.component.css']
})
export class AddSubcategoryComponent implements OnInit {
   
  subCategory!: ISubCategory;
  categories!: ICategory[];
  isSuccessfull!: boolean;
  constructor(private subCategoryService: SubCategoryService, private categoryService: CategoryService){}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(res=> this.categories=res);
  }

  onSubmit(form: NgForm) {
    this.subCategory = form.value;
    this.subCategoryService.addSubCategory(this.subCategory).subscribe(response=>{
      if(response){
        this.isSuccessfull = true;
     }
     form.reset();
    });
    }
}

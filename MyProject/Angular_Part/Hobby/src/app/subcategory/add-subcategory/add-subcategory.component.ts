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

  constructor(private subCategoryService: SubCategoryService, private categoryService: CategoryService){}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(res=> this.categories=res);
  }

  onSubmit(form: NgForm) {
    console.log(form.value);

    this.subCategory = form.value;
    this.subCategoryService.addSubCategory(this.subCategory).subscribe();

    console.log(this.subCategory);
  }
}

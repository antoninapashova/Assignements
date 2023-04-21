import { ISubCategory } from './../../shared/interfaces/subcategory';
import { CategoryService } from './../../category/category.service';
import { SubCategoryService } from './../sub-category.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ICategory } from 'src/app/shared/interfaces/category';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-add-subcategory',
  templateUrl: './add-subcategory.component.html',
  styleUrls: ['./add-subcategory.component.css']
})
export class AddSubcategoryComponent implements OnInit {
   
  subCategory!: ISubCategory;
  categories!: ICategory[];
  constructor(private subCategoryService: SubCategoryService, private categoryService: CategoryService,
              private matDialog: MatDialog){}

  ngOnInit(): void {
    this.categoryService.getNames().subscribe({
      next: (res)=>{
         this.categories = res;
       },
       error: (err)=>{
        let obj ={title: 'Categories', message: err.message, type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj});
       }
    });
  }

  onSubmit(form: NgForm) {
    this.subCategory = form.value;
    this.subCategoryService.addSubCategory(this.subCategory).subscribe({
      next: (res)=>{
      let obj ={title: 'Subcategory', message: 'Subcategory is added successfull', type: ModalType.INFO}
      this.matDialog.open( DialogTemplateComponent, {data: obj});
      form.reset();
     },
     error: (err)=>{
      let obj ={title: 'Subcategory', message: err.message, type: ModalType.WARN}
      this.matDialog.open( DialogTemplateComponent, {data: obj});
     }
    });
 }
}

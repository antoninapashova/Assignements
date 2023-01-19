import { GetCategoryDto } from './../../shared/dtos/get-category-dto';
import { CategoryService } from './../category.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent {
    
    constructor(private categoryService: CategoryService){}

    categories?: GetCategoryDto[];

    getAllCategories() {
      this.categoryService.getCategories().subscribe(res=> this.categories=res);
    }
}

import { CreateCategoryDto } from './../../shared/dtos/create-category-dto';
import { CategoryService } from './../category.service';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

constructor(private service: CategoryService){}
 category?: CreateCategoryDto;

 onSubmit(form: NgForm) {
   this.category = form.value;
    this.service.addCategory(form.value).subscribe();
  }

}

import { AddCategoryComponent } from './../add-category/add-category.component';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { CategoryService } from './../category.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ICategory } from 'src/app/shared/interfaces/category';
import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'action'];

    categories: ICategory[] = [];
    subCategories: ISubCategory[] | undefined;
    category! : ICategory | undefined;  

    @ViewChild(MatTable, {static:true}) table!: MatTable<any>;

    constructor(private categoryService: CategoryService, 
      public dialog: MatDialog){}
    
  ngOnInit(): void {
      this.categoryService.getCategories().subscribe(res=>{
        console.log(res);
        this.categories = res;
     });
}
   
openDialog(action: any, obj: any ) {
  obj.action = action;
  const dialogRef = this.dialog.open(AddCategoryComponent, {
    width: '250px',
    data:obj
  });

  dialogRef.afterClosed().subscribe(result => {
    if(result.event == 'Add'){
      this.addRowData(result.data);
    }else if(result.event == 'Delete'){
      this.deleteRowData(result.data);
    }
  });
}

addRowData(obj: any){
    this.categoryService.addCategory({name: obj.name}).subscribe();
    this.table.renderRows();
}

deleteRowData(obj: any){
  console.log(obj.id);
 this.categoryService.delete(obj.id).subscribe();
}

toggle(id: any): void{
   this.category =  this.categories.find(x=>x.id==id);
   this.subCategories = this.category?.hobbySubCategories;
}

}
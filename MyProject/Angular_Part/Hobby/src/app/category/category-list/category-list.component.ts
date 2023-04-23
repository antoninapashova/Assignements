import { DataSharingService } from './../../core/data-sharing.service';
import { AddCategoryComponent } from './../add-category/add-category.component';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { CategoryService } from './../category.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ICategory } from 'src/app/shared/interfaces/category';
import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
    displayedColumns: string[] = ['id', 'name','created-date', 'action'];

    categories: ICategory[] = [];
    subCategories: ISubCategory[] | undefined;
    category! : ICategory | undefined;  
    isAdded!: boolean;
    @ViewChild(MatTable, {static:true}) table!: MatTable<any>;

    constructor(private categoryService: CategoryService, private dataSharingService: DataSharingService,
      public dialog: MatDialog){
          this.dataSharingService.isCategoryAdded.subscribe(value => {
          this.isAdded= value;
       });
    }

  ngOnInit(): void {
      this.categoryService.getCategories().subscribe(res=>{
        this.categories = res;
        this.categories.forEach(x=>x.createdDate=x.createdDate.substring(0, 10)); 
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
    this.categoryService.addCategory({name: obj.name}).subscribe({
      next:(res)=>{
        let obj ={title: 'Add category', message: 'New category is added successful', type: ModalType.INFO}
             this.dialog.open(DialogTemplateComponent, {data: obj})
             this.dataSharingService.isCategoryAdded.next(true);
             this.table.renderRows();
        },
        error:(err)=>{
          console.log(err);
          let obj ={title: 'Add category', message: err.message, type: ModalType.WARN}
          this.dialog.open( DialogTemplateComponent, {data: obj})
        }
    });
  }

  deleteRowData(obj: any){
    this.categoryService.delete(obj.id).subscribe();
  }
}
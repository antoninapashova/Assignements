import { ICategory } from './../../shared/interfaces/category';
import { CategoryService } from './../category.service';
import { Component, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  action:string;
  local_data:any;
  
   constructor(public dialogRef: MatDialogRef<AddCategoryComponent>,
              @Optional() @Inject(MAT_DIALOG_DATA) public category: ICategory ){
                this.local_data = {...category};
    this.action = this.local_data.action;
  }

  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}

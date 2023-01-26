import { TagService } from './../tag.service';
import { Component, Inject, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ITag } from 'src/app/shared/interfaces/tag';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-tag',
  templateUrl: './add-tag.component.html',
  styleUrls: ['./add-tag.component.css']
})
export class AddTagComponent {
  action:string;
  local_data:any;
  
   constructor(public dialogRef: MatDialogRef<AddTagComponent>,
              @Optional() @Inject(MAT_DIALOG_DATA) public tag: ITag ){
                this.local_data = {...tag};
    this.action = this.local_data.action;
  }

  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }
}

import { AddTagComponent } from './../add-tag/add-tag.component';
import { TagService } from './../tag.service';
import { Component, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { ITag } from 'src/app/shared/interfaces/tag';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-tag-list',
  templateUrl: './tag-list.component.html',
  styleUrls: ['./tag-list.component.css']
})
export class TagListComponent {

  displayedColumns: string[] = ['id', 'name', 'action'];

  tags: ITag[] = [];
  tag : ITag | undefined;  

  @ViewChild(MatTable, {static:true}) table!: MatTable<any>;

  constructor(private tagService: TagService, 
    public dialog: MatDialog){}
  
ngOnInit(): void {
    this.tagService.getAll().subscribe(res=> this.tags = res);
}
 
openDialog(action: any, obj: any ) {
obj.action = action;
const dialogRef = this.dialog.open(AddTagComponent, {
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
  this.tagService.addTag({name: obj.name}).subscribe();
  this.table.renderRows();
}

deleteRowData(obj: any){
console.log(obj.id);
this.tagService.delete(obj.id).subscribe();
}

}

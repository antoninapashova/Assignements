import { DataSharingService } from './../../core/data-sharing.service';
import { AddTagComponent } from './../add-tag/add-tag.component';
import { TagService } from './../tag.service';
import { Component, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { ITag } from 'src/app/shared/interfaces/tag';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-tag-list',
  templateUrl: './tag-list.component.html',
  styleUrls: ['./tag-list.component.css']
})
export class TagListComponent {

  displayedColumns: string[] = ['id', 'name', 'action'];

  tags: ITag[] = [];
  tag: ITag | undefined;

  @ViewChild(MatTable, { static: true }) table!: MatTable<any>;

  constructor(private tagService: TagService,
    public dialog: MatDialog, private dataSharingService: DataSharingService) { }

  ngOnInit(): void {
    this.tagService.getAll().subscribe(res => this.tags = res);
  }

  openDialog(action: any, obj: any) {
    obj.action = action;
    const dialogRef = this.dialog.open(AddTagComponent, {
      width: '250px',
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.event == 'Add') {
        this.addRowData(result.data);
      } else if (result.event == 'Delete') {
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(obj: any) {
    this.tagService.addTag({ name: obj.name }).subscribe({
      next: (res) => {
        let obj = { title: 'Add tag', message: 'New tag is added successful', type: ModalType.INFO };
        this.dialog.open(DialogTemplateComponent, { data: obj });
        this.dataSharingService.isTagAdded.next(true);
      },
      error: (err) => {
        let obj = { title: 'Add tag', message: err.message, type: ModalType.WARN };
        this.dialog.open(DialogTemplateComponent, { data: obj });
      }
    });
    this.table.renderRows();
  }

  deleteRowData(obj: any) {
    this.tagService.delete(obj.id).subscribe();
  }
}

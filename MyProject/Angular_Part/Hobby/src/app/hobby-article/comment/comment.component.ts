import { DataSharingService } from './../../core/data-sharing.service';
import { MatDialog } from '@angular/material/dialog';
import { CommentService } from './../services/comment.service';
import { IComment } from './../../shared/interfaces/comment';
import { Component, Input} from '@angular/core';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent {

  @Input() comment!: IComment | undefined;
  currentUserId!: number;
  constructor(private commentService: CommentService, private matDialog: MatDialog, private sharingService: DataSharingService) { 

  }

  deleteComment(id: any){
     this.commentService.deleteComment(id).subscribe({
       next: (res)=>{
        let obj ={title: 'Comment', message: "Comment is deleted successfull", type: ModalType.INFO}
        this.matDialog.open( DialogTemplateComponent, {data: obj})
       },
       error: (err)=>{
        let obj ={title: 'Comment', message: err.detail, type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj})
       }
     });
  }
}

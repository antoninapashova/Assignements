import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { CommentService } from './../services/comment.service';
import { IComment } from './../../shared/interfaces/comment';
import { IPhoto } from './../../shared/interfaces/photo';
import { Component, Inject  } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-hobby-card-dialog',
  templateUrl: './hobby-card-dialog.component.html',
  styleUrls: ['./hobby-card-dialog.component.css']
})
export class HobbyCardDialogComponent {

  modalTitle: string;
  modalDescription: string;
  modalUsername:string;
  modalPhotos: IPhoto[];
  modalComments!: IComment[];  
  modalId: number | undefined;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: IHobby, private commentService: CommentService, private matDialog: MatDialog) {
    this.modalTitle = data.title;
    this.modalDescription = data.description;
    this.modalUsername = data.username;
    this.modalPhotos = data.hobbyPhoto;
    this.modalId = data.id; 
    this.getComments(data.id);
  }

   getComments(id: any)  {
    this.commentService.getCommentsByHobbyId(id).subscribe({
      next: (res)=>{
         console.log(res);
         this.modalComments=res;
      },
     error: (err)=>{
       let obj ={title: 'Comment', message: err.detail, type: ModalType.WARN}
       this.matDialog.open( DialogTemplateComponent, {data: obj});
      }
    });
   }
}

import { IComment } from './../../shared/interfaces/comment';
import { Component, Input } from '@angular/core';
import { CommentService } from '../services/comment.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { DataSharingService } from 'src/app/core/data-sharing.service';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent  {

   @Input() currentUsername: string | undefined;
   @Input() comments!: IComment[];
   @Input() hobbyArticleId!: number | undefined;

   constructor(private commentService: CommentService, private matDialog: MatDialog,
               private datasharingService: DataSharingService){
   }

   addComment({text}: {text: any}): void {
    let comment: IComment={
        commentContent : text.title,
        userId : this.datasharingService.loggedInUser.userId,
        hobbyArticleId: this.hobbyArticleId
      }

    this.commentService.createComment(comment).subscribe({
      next: (res)=>{
        console.log(res);
      },
      error: (err)=>{
        let obj ={title: 'Create article', message: err, type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj})
      }
    });
  }

  getComments(){
    this.commentService.getCommentsByHobbyId(this.hobbyArticleId).subscribe({
      
      next: (res)=>{
        console.log(res);
        this.comments = res;
      },
       error: (err)=>{
        console.log(this.hobbyArticleId);
        console.log(err.detail);
       }
    });
  }
}

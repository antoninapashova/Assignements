import { IComment } from './../../shared/interfaces/comment';
import { Component, Input } from '@angular/core';
import { CommentService } from '../services/comment.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { DataSharingService } from 'src/app/core/data-sharing.service';
import { ActiveCommentInterface } from 'src/app/shared/interfaces/active-comment';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent  {
   
  activeComment: ActiveCommentInterface | null = null;

   @Input() comments: IComment[] = [];
   @Input() hobbyArticleId!: number | undefined;

   constructor(private commentService: CommentService, private matDialog: MatDialog,
               private datasharingService: DataSharingService){}

   addComment({text, parentId}: {text: string; parentId: string | null}): void {
    let comment: IComment={
        commentContent : text,
        userId : this.datasharingService.loggedInUser.userId,
        hobbyArticleId: this.hobbyArticleId,
        parentId : null
      }

      this.commentService.createComment(comment).subscribe({
       next: (res)=>{ },
       error: (err)=>{
        let obj ={title: 'Create comment', message: err.message, type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj})
      }
    });
  }

  getComments(){
    this.commentService.getCommentsByHobbyId(this.hobbyArticleId).subscribe({
      next: (res)=>{
         this.comments = res;
      },
       error: (err)=>{
        let obj ={title: 'Load comments', message: err.message, type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj})
       }
    });
  }

  setActiveComment(activeComment: ActiveCommentInterface | null): void {
    this.activeComment = activeComment;
  }
}

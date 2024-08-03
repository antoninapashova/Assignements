import { IComment } from './../../shared/interfaces/comment';
import { Component, Input } from '@angular/core';
import { CommentService } from '../services/comment.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { DataSharingService } from 'src/app/core/data-sharing.service';
import { ActiveCommentInterface } from 'src/app/shared/interfaces/active-comment';
import { IUser } from 'src/app/shared/interfaces/user';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent {
  replies: IComment[] = [];
  activeComment: ActiveCommentInterface | null = null;
  @Input() comments: IComment[] = [];
  @Input() hobbyArticleId!: number | undefined;

  constructor(private commentService: CommentService, private matDialog: MatDialog,
    private datasharingService: DataSharingService, private dataSharing: DataSharingService) { }

  addComment({ commentContent, parentId }: { commentContent: string, parentId: number | null }): void {
    let comment = {
      id: null,
      commentContent,
      userId: this.datasharingService.loggedInUser.userId,
      hobbyArticleId: this.hobbyArticleId,
      parentId: null
    }

    this.commentService.createComment(comment).subscribe({
      next: () => {
        this.comments = [...this.comments, comment];
        this.activeComment = null;
      },
      error: (err) => {
        let obj = { title: 'Create comment', message: err.message, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj })
      }
    });
  }

  editComment(commentContent: any) {
    let comment: any = {
      commentContent: commentContent,
    };

    this.commentService.editComment(comment.id, comment).subscribe();
  }

  getComments() {
    this.commentService.getCommentsByHobbyId(this.hobbyArticleId).subscribe({
      next: (res) => { this.comments = res; },
      error: (err) => {
        let obj = { title: 'Load comments', message: err.message, type: ModalType.WARN };
        this.matDialog.open(DialogTemplateComponent, { data: obj });
      }
    });
  }

  deleteComment(id: any) {
    this.commentService.deleteComment(id).subscribe({
      next: () => {
        let obj = { title: 'Comment', message: "Comment is deleted successfull", type: ModalType.INFO };
        this.matDialog.open(DialogTemplateComponent, { data: obj });
        this.comments = this.comments.filter((comment) => comment.id != id);
      },
      error: (err) => {
        let obj = { title: 'Comment', message: err.detail, type: ModalType.WARN };
        this.matDialog.open(DialogTemplateComponent, { data: obj });
      }
    });
  }

  getReplies(parrentId: number | null): IComment[] {
    // this.commentService.getCommentReplies(parrentId).subscribe(res=> this.replies=res);
    return this.replies;
  }

  setActiveComment(activeComment: ActiveCommentInterface | null): void {
    this.activeComment = activeComment;
  }
}

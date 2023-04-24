import { ActiveCommentInterface } from './../../shared/interfaces/active-comment';
import { MatDialog } from '@angular/material/dialog';
import { CommentService } from './../services/comment.service';
import { IComment } from './../../shared/interfaces/comment';
import { Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { DataSharingService } from 'src/app/core/data-sharing.service';
import { ActiveCommentTypeEnum } from 'src/app/shared/interfaces/active-comment.enum';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  currentUserId!: number;
  canEdit: boolean = false;
  canDelete: boolean = false;
  activeCommentType = ActiveCommentTypeEnum;
  replyId: number | null = null;

  @Input() activeComment!: ActiveCommentInterface | null;
  @Input() comment!: IComment;
  @Input() parentId!: number | null;
  @Output() setActiveComment = new EventEmitter<ActiveCommentInterface | null>();
  @Output() addComment = new EventEmitter<{ text: string; parentId: string | null }>();
  
  constructor(private commentService: CommentService, private matDialog: MatDialog,
              private dataSharing: DataSharingService) {}

  ngOnInit(): void {
     this.canEdit = this.dataSharing.isUserLoggedIn.getValue();
     this.canDelete = this.dataSharing.isUserLoggedIn.getValue();
     this.replyId = this.parentId ? this.parentId : this.comment.id;
  }

  deleteComment(id: any){
     this.commentService.deleteComment(id).subscribe({
       next: (res)=>{
        let obj ={title: 'Comment', message: "Comment is deleted successfull", type: ModalType.INFO};
        this.matDialog.open( DialogTemplateComponent, {data: obj});
       },
       error: (err)=>{
        let obj ={title: 'Comment', message: err.detail, type: ModalType.WARN};
        this.matDialog.open( DialogTemplateComponent, {data: obj});
       }
     });
  }

  editComment( commentContent: any ){
    let comment : IComment= {
       id: this.comment?.id,
       commentContent: commentContent,
       userId: this.currentUserId,
       hobbyArticleId: this.comment?.hobbyArticleId
    };
    this.commentService.editComment(this.comment?.id,comment ).subscribe();
  }

  isReplying(): boolean {
    if (!this.activeComment) {
      return false;
    }
    return (
      this.activeComment.id === this.comment.id && this.activeComment.type === this.activeCommentType.replying
    );
  }
  
  
  isEditing(): boolean {
    if (!this.activeComment) {
      return false;
    }
    return (
      this.activeComment.id === this.comment.id &&
      this.activeComment.type === 'editing'
    );
  }
  
}

import { ActiveCommentInterface } from './../../shared/interfaces/active-comment';
import { MatDialog } from '@angular/material/dialog';
import { CommentService } from './../services/comment.service';
import { IComment } from './../../shared/interfaces/comment';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DataSharingService } from 'src/app/core/data-sharing.service';
import { ActiveCommentTypeEnum } from 'src/app/shared/interfaces/active-comment.enum';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {
  isUserLoggedIn: boolean = false;
  canReply: boolean = false;
  canEdit: boolean = false;
  canDelete: boolean = false;

  activeCommentType = ActiveCommentTypeEnum;
  replyId: number | null = null;

  @Input() activeComment!: ActiveCommentInterface | null;
  @Input() comment!: IComment;
  @Input() parentId!: number | null;
  @Input() replies!: IComment[];

  @Output() setActiveComment = new EventEmitter<ActiveCommentInterface | null>();
  @Output() addComment = new EventEmitter<{ commentContent: string; parentId: number | null }>();
  @Output() deleteComment = new EventEmitter<number | null>();
  @Output() updateComment = new EventEmitter<{ commentContent: string; commentId: string }>();

  constructor(private commentService: CommentService, private matDialog: MatDialog,
    private dataSharing: DataSharingService) { }

  ngOnInit(): void {
    this.isUserLoggedIn = this.dataSharing.isUserLoggedIn.getValue();
    this.canReply = this.isUserLoggedIn;
    this.canEdit = this.isUserLoggedIn;
    this.canDelete = this.isUserLoggedIn && this.replies.length === 0;
    this.replyId = this.parentId ? this.parentId : this.comment.id;
  }

  isReplying(): boolean {
    if (!this.activeComment) {
      return false;
    }

    return this.activeComment.id === this.comment.id && this.activeComment.type === this.activeCommentType.replying;
  }

  isEditing(): boolean {
    if (!this.activeComment) {
      return false;
    }
    
    return this.activeComment.id === this.comment.id && this.activeComment.type === 'editing';
  }
}

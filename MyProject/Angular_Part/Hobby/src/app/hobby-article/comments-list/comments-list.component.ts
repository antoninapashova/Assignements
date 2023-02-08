import { HobbyService } from './../hobby-aticle.service';
import { IComment } from './../../shared/interfaces/comment';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-comments-list',
  templateUrl: './comments-list.component.html',
  styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent  {

   @Input() currentUsername: string | undefined;
   @Input() comments!: IComment[];
   @Input() hobbyArticleId: number | undefined;

   constructor(private hobbyService: HobbyService){
   }

   addComment({text}: {text: any}): void {
    let comment: IComment={
        commentContent : text.title,
        username : this.currentUsername,
        hobbyArticleId: this.hobbyArticleId
      }
      
      console.log(comment);
    this.hobbyService.createComment(comment).subscribe(res=>console.log(res));
    }

  
}

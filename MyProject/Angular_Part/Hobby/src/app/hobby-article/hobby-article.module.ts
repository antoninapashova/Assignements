import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddHobbyComponent } from './add-hobby/add-hobby.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { CommentComponent } from './comment/comment.component';
import { HobbyCardComponent } from './hobby-card/hobby-card.component';
import { CommentsListComponent } from './comments-list/comments-list.component';
import { CommentFormComponent } from './comment-form/comment-form.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { LightboxModule } from 'ngx-lightbox';
import { HobbyCardDialogComponent } from './hobby-card-dialog/hobby-card-dialog.component';

@NgModule({
  declarations: [
    AddHobbyComponent,
    CommentComponent,
    HobbyCardComponent,
    CommentsListComponent,
    CommentFormComponent,
    HobbyCardDialogComponent,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    CommonModule,
    NgxDropzoneModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    MatListModule,
    MatExpansionModule,
    LightboxModule,
  ],
  exports:[
    CommentFormComponent,
    AddHobbyComponent, 
     CommentComponent,
    HobbyCardComponent,
    CommentsListComponent,
  ]
})
export class HobbyArticleModule { }

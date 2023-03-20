import { IComment } from './../../shared/interfaces/comment';
import { IPhoto } from './../../shared/interfaces/photo';
import { IHobby } from './../../shared/interfaces/hobby-article';
import { Component, Inject  } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

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
  modalComments: IComment[];  
  modalId: number | undefined;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: IHobby) {
    this.modalTitle = data.title;
    this.modalDescription = data.description;
    this.modalUsername = data.username;
    this.modalPhotos = data.hobbyPhoto;
    this.modalComments = data.hobbyComments;
    this.modalId = data.id;
  }

  closeDialog(){
    
  }
}

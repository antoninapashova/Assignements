import { IComment } from '../../shared/interfaces/comment';
import { HobbyCardDialogComponent } from '../hobby-card-dialog/hobby-card-dialog.component';
import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { IPhoto } from '../../shared/interfaces/photo';

@Injectable({
  providedIn: 'root'
})
export class HobbyDialogService {

  constructor(public dialog: MatDialog) { }

  openModal(title: string, description: string, username: string, photos: IPhoto[], comments: IComment[], yes: Function, no: Function) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.autoFocus = true;
    dialogConfig.data = {
      title: title,
      description: description,
      username: username,
      photos: photos,
      comments: comments
    };
    dialogConfig.minWidth = 300;
    dialogConfig.minHeight = 300

    const dialogRef = this.dialog.open(HobbyCardDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (yes) {
          yes();
        }
      } else {
        if (no) {
          no();
        }
      }
    });
  }
}

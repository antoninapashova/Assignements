import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/shared/interfaces/user';
import { UserService } from 'src/app/user/user.service';
import { DataSharingService } from '../data-sharing.service';
import { DialogTemplateComponent, ModalType } from '../dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  profile?: IUser;

  constructor(private dataSharingService: DataSharingService, private userService: UserService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    let id = this.dataSharingService.getUserId();

    if (id) {
      this.getProfile(id);
    } else {
      let obj = { title: 'Error', message: "Something went wrong. Please sign in again", type: ModalType.WARN };
      this.matDialog.open(DialogTemplateComponent, { data: obj });
    }
  }

  getProfile(id: string) {
    this.userService.getById(id).subscribe({
      next: (res) => {
        this.profile = res;
      },
      error: () => {
        let obj = { title: 'Error', message: "Something went wrong", type: ModalType.WARN };
        this.matDialog.open(DialogTemplateComponent, { data: obj });
      }
    })
  }
}
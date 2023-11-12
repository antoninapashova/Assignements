import { MatDialog } from '@angular/material/dialog';
import { IHobby } from './../../shared/interfaces/hobby-article';
import { HobbyService } from '../../hobby-article/services/hobby-aticle.service';
import { Component, OnInit } from '@angular/core';
import { DialogTemplateComponent, ModalType } from '../dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  hobbies: IHobby[] = [];

  constructor(private hobbyService: HobbyService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.hobbyService.getAll().subscribe({
      next: (res) => {
        this.hobbies = res;
      },
      error: (err) => {
        let obj = { title: 'Hobbies', message: err, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj })
      }
    });
  }
}

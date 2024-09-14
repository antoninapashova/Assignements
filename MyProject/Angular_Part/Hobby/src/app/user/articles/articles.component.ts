import { HobbyService } from '../../hobby-article/services/hobby-aticle.service';
import { UserService } from './../user.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatAccordion } from '@angular/material/expansion';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css'],
  providers: [UserService]
})
export class ArticlesComponent implements OnInit {
  activeAccount: string | undefined;
  hobbies: IHobby[] = [];

  constructor(private hobbyService: HobbyService, private userService: UserService, private matDialog: MatDialog) { }

  @ViewChild(MatAccordion) accordion!: MatAccordion;

  ngOnInit(): void {
    this.activeAccount = this.userService.getFullNameFromToken();
    this.hobbyService.getAll().subscribe(res => {
      this.hobbies = res;
    });
  }

  deleteArticle(id: any, username: any) {
    const role = this.userService.getRoleFromToken();

    if (this.activeAccount == username || role == 'Admin') {
      this.deleteArticleById(id);
    }
  }

  deleteArticleById(id: any) {
    this.hobbyService.deleteHobby(id).subscribe({
      next: () => {
        let obj = { title: 'Delete article', message: "Article is deleted successfull!", type: ModalType.INFO }
        this.matDialog.open(DialogTemplateComponent, { data: obj });
        this.hobbies = [...this.hobbies];
      },
      error: (err) => {
        let obj = { title: 'Create article', message: err, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj })
      }
    });
  }
}
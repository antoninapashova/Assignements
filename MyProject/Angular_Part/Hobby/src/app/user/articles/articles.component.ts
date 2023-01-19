import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css'],
  providers: [UserService]
})
export class ArticlesComponent {

  constructor(private userService: UserService){}

  getUserArticles(): void{
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';

@Component({
  selector: 'app-hobby-card',
  templateUrl: './hobby-card.component.html',
  styleUrls: ['./hobby-card.component.css']
})
export class HobbyCardComponent implements OnInit {
 
    
  @Input() hobbies?: IHobby[]

   ngOnInit(): void {
   }

  addComment(): void{}
  showComments(): void{ }
}

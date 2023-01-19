import { IUser } from './../../shared/interfaces/user';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent {
  
      
   @Input()user!: IUser;


    
}

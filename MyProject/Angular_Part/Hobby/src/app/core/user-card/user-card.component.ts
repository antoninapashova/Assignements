
import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/shared/interfaces/user';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit{

  profile?: IUser;
  constructor(){}

  ngOnInit(): void {
    this.getProfile();
  }

  getProfile(){
  
  }

}

import { AzureAdService } from './../../auth/azure-ad.service';

import { Component, Input, OnInit } from '@angular/core';
import { IUser } from 'src/app/shared/interfaces/user';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit{

  profile?: IUser;
  constructor(private azureAdService: AzureAdService){}

  ngOnInit(): void {
    this.getProfile();
  }

  getProfile(){
    this.azureAdService.getUserProfile().subscribe(profileInfo=>{
      console.log(profileInfo);
      this.profile = profileInfo;
    })
  }

}

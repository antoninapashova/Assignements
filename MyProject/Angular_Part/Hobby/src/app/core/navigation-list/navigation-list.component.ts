import { MsalService } from '@azure/msal-angular';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { ICategory } from './../../shared/interfaces/category';

import { AzureAdService } from './../../auth/azure-ad.service';
import { Component, EventEmitter, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation-list',
  templateUrl: './navigation-list.component.html',
  styleUrls: ['./navigation-list.component.css']
})
export class NavigationListComponent implements OnInit {
  isUserLogedIn: boolean = false;
  username:string | undefined;
  name: string | undefined;
   isAdmin: boolean = false;

  subCategories: ISubCategory[] | undefined;
  category!: ICategory | undefined;
  
  constructor(private azureAdService: AzureAdService, private msalService: MsalService) { }
  
  @Output() sidenavClose = new EventEmitter();

  ngOnInit() {
    this.azureAdService.isUserLogedIn.subscribe(x=> {
      this.isUserLogedIn = x;
      this.username = this.azureAdService.username;
      this.name = this.azureAdService.name;
    });
    
    let activAccount = this.msalService.instance.getActiveAccount();   
    if(activAccount?.idTokenClaims?.roles?.includes('Admin')){
      this.isAdmin=true;
   }
  }
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
}

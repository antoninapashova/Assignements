import { MsalService } from '@azure/msal-angular';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { ICategory } from './../../shared/interfaces/category';
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
   isUser: boolean = false;
  subCategories: ISubCategory[] | undefined;
  category!: ICategory | undefined;
  
  constructor() { }
  
  @Output() sidenavClose = new EventEmitter();

  ngOnInit() {
     
  }
  
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
}

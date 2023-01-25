import { ISubCategory } from './../../shared/interfaces/subcategory';
import { HobbyService } from './../../hobby-article/hobby-aticle.service';
import { ICategory } from './../../shared/interfaces/category';
import { SafeResourceUrl } from '@angular/platform-browser';
import { CategoryService } from './../../category/category.service';
import { AzureAdService } from './../../auth/azure-ad.service';
import { Component, EventEmitter, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation-list',
  templateUrl: './navigation-list.component.html',
  styleUrls: ['./navigation-list.component.css']
})
export class NavigationListComponent implements OnInit {
  pdfUrl?: SafeResourceUrl;
  isUserLogedIn: boolean = false;
  username:string | undefined;
  name: string | undefined;
 
 
  subCategories: ISubCategory[] | undefined;
  category!: ICategory | undefined;
  constructor(private azureAdService: AzureAdService) { }
  
  @Output() sidenavClose = new EventEmitter();

  ngOnInit() {
    this.azureAdService.isUserLogedIn.subscribe(x=> {
      this.isUserLogedIn = x;
      this.username = this.azureAdService.username;
      this.name = this.azureAdService.name;
    });

    
  }

  

  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
}

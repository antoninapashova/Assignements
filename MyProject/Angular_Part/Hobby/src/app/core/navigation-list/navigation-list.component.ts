import { DataSharingService } from './../data-sharing.service';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { ICategory } from './../../shared/interfaces/category';
import { Component, EventEmitter, Output, OnInit, OnDestroy } from '@angular/core';
import { UserService } from 'src/app/user/user.service';
import { UserStoreService } from 'src/app/user/user-store.service';

@Component({
  selector: 'app-navigation-list',
  templateUrl: './navigation-list.component.html',
  styleUrls: ['./navigation-list.component.css']
})
export class NavigationListComponent implements OnInit, OnDestroy {

  isAuthenticated!: boolean;
  fullName: string | undefined;
  role!: string;
  subCategories: ISubCategory[] | undefined;
  category!: ICategory | undefined;
  mySubscription: any;

  constructor(private dataSharingService: DataSharingService, private userService: UserService, private userStore:UserStoreService,) {
    this.dataSharingService.isUserLoggedIn.subscribe( value => {
      this.isAuthenticated = value;
   });
  }
  
  @Output() sidenavClose = new EventEmitter();

  ngOnInit() {
    this.userStore.getFullNameFromStore().subscribe((val:any)=>{      
      const fullNameFromToken = this.userService.getFullNameFromToken();
      this.fullName = val || fullNameFromToken; 
     });
 
     this.userStore.getRoleFromStore().subscribe((val:any)=>{
       const roleFromToken = this.userService.getRoleFromToken();
       this.role = val || roleFromToken;
     });
  }
  
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }

  ngOnDestroy(): void {
    if (this.mySubscription) {
        this.mySubscription.unsubscribe();
    }
  }
}

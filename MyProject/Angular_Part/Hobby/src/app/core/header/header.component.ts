import { UserStoreService } from './../../user/user-store.service';
import { UserService } from './../../user/user.service';
import { Component, EventEmitter, Output, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { NavigationEnd, Router } from '@angular/router';
import { DataSharingService } from '../data-sharing.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy{
   
  isAuthenticated!: boolean;
  activeUser!: string;
  fullName: string = ""; 
  username!: string;
  role!: string;
  mySubscription: any;
  private readonly unsubscribe = new Subject<void>();
  @Output() public sidenavToggle = new EventEmitter();

 constructor(private userService: UserService,  private router: Router,
             private userStore:UserStoreService, private dataSharingService: DataSharingService) {
      
              this.dataSharingService.isUserLoggedIn.subscribe( value => {
                this.isAuthenticated = value;
            });
 }

 
  ngOnInit(): void {
    this.userStore.getFullNameFromStore().subscribe((val:any)=>{      
     const fullNameFromToken = this.userService.getFullNameFromToken();
     console.log(this.fullName);
     this.fullName = val || fullNameFromToken; 
    });

    this.userStore.getRoleFromStore().subscribe((val:any)=>{
      const roleFromToken = this.userService.getRoleFromToken();
      this.role = val || roleFromToken;
    });
    
    //this.isAuthenticated= this.userService.isLoggedIn();
  }
 
  logOut = () => {
     this.userService.signOut();
     window.location.reload();
   }

   onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

  ngOnDestroy(): void {
    if (this.mySubscription) {
        this.mySubscription.unsubscribe();
    }
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
  }
}

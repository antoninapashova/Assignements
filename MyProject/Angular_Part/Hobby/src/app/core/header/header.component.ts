import { UserStoreService } from './../../user/user-store.service';
import { UserService } from './../../user/user.service';
import { Component, EventEmitter, Output, OnInit, OnDestroy } from '@angular/core';
import {  Subject } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy{
   
  isAuthenticated=false;
  activeUser!: string;
  fullName: string = ""; 
  username!: string;
  role!: string;
  private readonly unsubscribe = new Subject<void>();
  @Output() public sidenavToggle = new EventEmitter();

 constructor(private userService: UserService, 
             private router: Router,
             private userStore:UserStoreService) {}
 
  ngOnDestroy(): void {
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
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
    })
  }
 
  isUserLogedIn(){
   this.isAuthenticated= this.userService.isLoggedIn();
  }


  logOut = () => {
     this.userService.signOut();
     this.router.navigate(['login']);
  }

   onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}

import { UserService } from './../../user/user.service';
import { Component, EventEmitter, Output, OnInit, OnDestroy } from '@angular/core';
import {  Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy{
   
  isAuthenticated=false;
  activeUser!: string;
  name!: string 
  username!: string;
  isAdmin: boolean = false;
  isUser: boolean= false;
  private readonly unsubscribe = new Subject<void>();
  @Output() public sidenavToggle = new EventEmitter();

 constructor(private userService: UserService, 
             private router: Router) {}
 
  ngOnDestroy(): void {
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
  }
 
  ngOnInit(): void {}
 

  logOut = () => {
     this.userService.signOut();
     this.router.navigate(['login']);
  }

   onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}

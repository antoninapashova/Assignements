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

 constructor(private jwtHelper: JwtHelperService, 
             private router: Router) {}
 
  ngOnDestroy(): void {
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
  }
 
  ngOnInit(): void {}
 



isUserAuthenticated() {
  const token = localStorage.getItem("jwt");
  if (token && !this.jwtHelper.isTokenExpired(token)) {
     this.isAuthenticated=true;
   }
 }

  logOut = () => {
     localStorage.removeItem("jwt");
  }

   onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}

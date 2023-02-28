import { UserService } from './../user/user.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router) {
  }

  canActivate(): boolean{
    if(this.userService.isLoggedIn()){
      return true;
    }else{
      this.router.navigate(["login"]);
      return false;
    }
    
  }
  
}

import { UserService } from './../user.service';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
   
  invalidLogin?: boolean;

  url = '/api/authentication/';

  constructor(private router: Router, private userService: UserService,private jwtHelper : JwtHelperService,
    ) { }

  public login (form: NgForm) {
    const credentials = JSON.stringify(form.value);

    this.userService.login(credentials).subscribe((response) => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/product"]);
    });
     
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
}

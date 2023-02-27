import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
   
  invalidLogin?: boolean;
  hide : boolean = true;
  loginUserForm: FormGroup = new FormGroup({});
  url = '/api/authentication/';

  constructor(private formBuilder: FormBuilder, private router: Router, private userService: UserService,private jwtHelper : JwtHelperService) { }

  ngOnInit(): void {
       this.loginUserForm = this.formBuilder.group({
         username: [null, [Validators.required, Validators.minLength(3)]],
         password: [null, [Validators.required, Validators.minLength(5)]],
       });
     }
  
  public onSubmit (form: FormGroup) {
    const credentials = JSON.stringify(form.value);

    this.userService.login(credentials).subscribe((response) => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/home"]);
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

  hideShowPass(){
    
  }
}

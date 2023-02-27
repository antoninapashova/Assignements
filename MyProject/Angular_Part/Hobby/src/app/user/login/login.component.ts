import { ModalType } from './../../core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,  Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DialogTemplateComponent } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
   
  invalidLogin?: boolean;
  hide : boolean = true;
  loginUserForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, private router: Router, 
              private userService: UserService,private jwtHelper : JwtHelperService,
              private matDialog: MatDialog
           ) { }

  ngOnInit(): void {
       this.loginUserForm = this.formBuilder.group({
         username: [null, [Validators.required, Validators.minLength(3)]],
         password: [null, [Validators.required, Validators.minLength(5)]],
       });
     }
  
  onSubmit (form: FormGroup) {
     if(this.loginUserForm.valid){
       console.log(this.loginUserForm.value);
         
       this.userService.login(form.value).subscribe({
        next:(res)=>{
          console.log(res);
          let obj ={title: 'Login', message: 'Login is successful', type: ModalType.INFO}
          this.matDialog.open( DialogTemplateComponent, {data: obj})
          this.router.navigate(['home']);
        },
        error:(err)=>{
          console.log(err);

          let obj ={title: 'Login', message: err.message, type: ModalType.WARN}
          console.log(obj);
          this.matDialog.open( DialogTemplateComponent, {data: obj})
        }
       })
     }
     
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

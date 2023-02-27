import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { matchValidator } from 'src/app/core/validators/confirm-password.validator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{

  registerUserForm: FormGroup = new FormGroup({});
  isSuccessfull: boolean = false;
  constructor(private formBuilder: FormBuilder,private router: Router, private userService: UserService) { }

  ngOnInit(): void {
   this.registerUserForm = this.formBuilder.group({
      username: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.required, Validators.minLength(5), Validators.email]],
      firstName: [null, [Validators.required, Validators.minLength(3)]],
      lastName: [null, [Validators.required,  Validators.minLength(3)]],
      password: [null, [Validators.required, Validators.minLength(5), matchValidator('confirmPassword', true)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(5), matchValidator('password')]]
    });
  }

  onSubmit(form: FormGroup){ 
      this.userService.addUser(form.value).subscribe({
          next: (res)=>{
            alert(res);
            form.reset();
            this.router.navigate(['login']);
          },
          error:(err)=>{
            alert(err.error.meesage);
         }
      });
  }
}

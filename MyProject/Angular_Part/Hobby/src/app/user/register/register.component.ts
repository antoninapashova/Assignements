import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { ConfirmPasswordValidator } from './confirm-password.validator';
import { IUser } from 'src/app/shared/interfaces/user';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  implements OnInit {

  signUpForm: FormGroup = new FormGroup({});
  user!: IUser;

  constructor(private formBuilder: FormBuilder, private userService : UserService ){}

  ngOnInit():void{
    
    this.signUpForm = this.formBuilder.group({
      username: [null, [Validators.required, Validators.minLength(3)]],
      firstName: [null, [Validators.required, Validators.minLength(3)]],
      lastName: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.required, Validators.email]],
      age:[null, [Validators.min(16)]],
      password: [null, [Validators.required, Validators.minLength(5)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(5)]]
     },
     {
       validator: ConfirmPasswordValidator("password", "confirmPassword")
     }
  );
    }

    onSubmit(form: FormGroup) {
      console.log(form);
      this.user = form.value;
      console.log(this.user);
      this.userService.addUser(this.user).subscribe();
       form.reset;
    }

}

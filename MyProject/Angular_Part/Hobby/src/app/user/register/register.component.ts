import { UserService } from './../user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{

  registerUserForm: FormGroup = new FormGroup({});
  isSuccessfull: boolean = false;
  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit(): void {
   this.registerUserForm = this.formBuilder.group({
      username: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.required, Validators.minLength(5)]],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      password: [null, [Validators.required, Validators.minLength(5)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(5)]]
    });
  }

  onSubmit(form: FormGroup){ 
      this.userService.addUser(form.value).subscribe((response)=>{
        if(response){
           this.isSuccessfull = true;
        }
        console.log(response);
        form.reset();
      });
  }
}

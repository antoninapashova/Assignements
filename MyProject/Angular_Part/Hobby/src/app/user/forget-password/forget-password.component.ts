import { UserService } from 'src/app/user/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit{

  resetPasswordForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<ForgetPasswordComponent>, private userService: UserService){}

  ngOnInit(): void {
    this.resetPasswordForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.minLength(5), Validators.email]],
    });
  }
  onSubmit (form: FormGroup) {
    if(form.valid){
      console.log(form.value);
      //this.userService.resetPassword
    }
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}

import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent {

  resetPasswordForm: FormGroup = new FormGroup({});
  isSuccessfull: boolean = false;

  constructor(){}

  onSubmit(form: FormGroup){}
}

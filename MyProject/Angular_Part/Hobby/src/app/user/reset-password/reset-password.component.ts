import { MatDialog } from '@angular/material/dialog';
import { ResetPasswordService } from './../reset-password.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { matchValidator } from 'src/app/core/validators/confirm-password.validator';
import { ResetPassword } from 'src/app/shared/interfaces/reset-password.model';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  resetPasswordForm!: FormGroup;
  emailToReset!: string;
  emailToken!: string;
  resetPasswordObj = new ResetPassword();
  isSuccessfull: boolean = false;

  constructor(private formBuilder: FormBuilder, private activateRoute: ActivatedRoute,
    private resetService: ResetPasswordService, private router: Router,
    private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.resetPasswordForm = this.formBuilder.group({
      password: [null, [Validators.required, Validators.minLength(5), matchValidator('confirmPassword', true)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(5), matchValidator('password')]]
    });

    this.activateRoute.queryParams.subscribe(val => {
      this.emailToReset = val['email'];
      let uriToken = val['code'];

      this.emailToken = uriToken.replace(/ /g, '+');
      console.log(this.emailToken);
      console.log(this.emailToReset);
    })
  }

  onSubmit(form: FormGroup) {
    if (this.resetPasswordForm.valid) {
      this.resetPasswordObj.email = this.emailToReset;
      this.resetPasswordObj.newPassword = this.resetPasswordForm.value.password;
      this.resetPasswordObj.confirmPassword = this.resetPasswordForm.value.confirmPassword;
      this.resetPasswordObj.emailToken = this.emailToken;

      this.resetService.resetPassword(this.resetPasswordObj)
        .subscribe({
          next: (res) => {
            console.log(res);
            let obj = { title: 'Reset password', message: 'Reset password is successfully', type: ModalType.INFO };
            this.matDialog.open(DialogTemplateComponent, { data: obj });
            this.router.navigate(['/login']);
          },
          error: (err) => {
            console.log(err);
            let obj = { title: 'Reset password', message: err, type: ModalType.INFO };
            this.matDialog.open(DialogTemplateComponent, { data: obj });
          }
        });
    }
  }
}

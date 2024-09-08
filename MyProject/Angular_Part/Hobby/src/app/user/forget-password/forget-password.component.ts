import { ResetPasswordService } from './../reset-password.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup = new FormGroup({});

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<ForgetPasswordComponent>, private matDialog: MatDialog,
    private resetPasswordService: ResetPasswordService) { }

  ngOnInit(): void {
    this.resetPasswordForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.minLength(5), Validators.email]],
    });
  }

  onSubmit(form: FormGroup) {
    if (form.valid) {
      this.resetPasswordService.sendResetPassworLink(form.value.email).subscribe({
        next: () => {
          let obj = { title: 'Send email', message: 'Email is send successfull!', type: ModalType.INFO }
          this.matDialog.open(DialogTemplateComponent, { data: obj });
          this.closeDialog();
        },
        error: (err) => {
          let obj = { title: 'Send email', message: err, type: ModalType.WARN }
          this.matDialog.open(DialogTemplateComponent, { data: obj });
          this.closeDialog();
        }
      });
    }
  }

  closeDialog() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}
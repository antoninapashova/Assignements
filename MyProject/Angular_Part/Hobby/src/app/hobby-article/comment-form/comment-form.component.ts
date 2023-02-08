import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.css']
})
export class CommentFormComponent implements OnInit{
  commentForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder) {}

  @Input() submitLabel!: string;
  @Input() hasCancelButton: boolean = false;
  @Input() initialText: string = '';
  @Output() handleSubmit = new EventEmitter<string>();

   ngOnInit(): void {
    this.commentForm = this.fb.group({
      title: [this.initialText, Validators.required],
    });
  
  }

  onSubmit(form: FormGroup): void {
    this.handleSubmit.emit(form.value);
    this.commentForm.reset();
  }
}

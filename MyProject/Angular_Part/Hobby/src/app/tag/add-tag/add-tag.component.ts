import { TagService } from './../tag.service';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ITag } from 'src/app/shared/interfaces/tag';

@Component({
  selector: 'app-add-tag',
  templateUrl: './add-tag.component.html',
  styleUrls: ['./add-tag.component.css']
})
export class AddTagComponent {

  tag!: ITag;

  constructor(private tagSrvice: TagService){}
  
  onSubmit(form: NgForm) {
     this.tag = form.value;
     this.tagSrvice.addTag(this.tag).subscribe();
     console.log(this.tag);
     console.log(form);

  }
}

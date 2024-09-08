import { Router } from '@angular/router';
import { DataSharingService } from './../../core/data-sharing.service';
import { UploadService } from '../services/upload-service.service';
import { TagService } from './../../tag/tag.service';
import { SubCategoryService } from './../../subcategory/sub-category.service';
import { ITag } from './../../shared/interfaces/tag';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { HobbyService } from '../services/hobby-aticle.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPhoto } from 'src/app/shared/interfaces/photo';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatDialog } from '@angular/material/dialog';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-add-hobby',
  templateUrl: './add-hobby.component.html',
  styleUrls: ['./add-hobby.component.css']
})
export class AddHobbyComponent implements OnInit {
  createArticleForm: FormGroup = new FormGroup({});
  photos: File[] = [];
  subcategories: ISubCategory[] = [];
  tags: ITag[] = [];
  photosData: IPhoto[] = [];
  hobby!: IHobby;
  hobbyTags: ITag[] = [];

  constructor(private formBuilder: FormBuilder, private hobbyService: HobbyService,
    private subCategoryService: SubCategoryService, private tagService: TagService,
    private uploadService: UploadService, private matDialog: MatDialog,
    private datasharingService: DataSharingService, private router: Router) { }

  ngOnInit(): void {
    this.createArticleForm = this.formBuilder.group({
      title: [null, [Validators.required, Validators.minLength(3)]],
      description: [null, [Validators.required, Validators.minLength(5)]],
      tags: [null, [Validators.required]],
      subcategory: [null, [Validators.required]],
      photos: [null]
    });

    this.tagService.getAll().subscribe(res => this.tags = res);
    this.subCategoryService.getSubCategories().subscribe(res => this.subcategories = res);
  }

  uploadPhotosOnCloudinary() {
    this.photos.forEach(async p => {
      const data = new FormData();

      data.append('file', p);
      data.append('upload_preset', 'hobby_angular');
      data.append('cloud_name', 'dpqbf79wg');

      let result = this.uploadService.uploadImage(data);
      const response = await lastValueFrom(result);

      this.hobby.hobbyPhoto.push({
        publicId: response.public_id,
        url: response.url,
      });
    });
  }

  onSubmit(form: FormGroup) {
    this.hobby = form.value;
    this.hobby.hobbySubcategoryId = form.value['subcategory'];
    this.hobby.userId = this.datasharingService.loggedInUser.userId;
    this.hobby.hobbyPhoto = [];
    this.uploadPhotosOnCloudinary();

    setTimeout(() => {
      this.hobbyService.addHobby(this.hobby).subscribe({
        next: () => {
          let obj = { title: 'Create article', message: "Article is created successfull!", type: ModalType.WARN }
          this.matDialog.open(DialogTemplateComponent, { data: obj });
          this.router.navigate(['home'])
        },
        error: (err) => {
          let obj = { title: 'Create article', message: err, type: ModalType.WARN }
          this.matDialog.open(DialogTemplateComponent, { data: obj })
        }
      });
    }, 2000);
  }

  onSelect(event: any) {
    this.photos.push(...event.addedFiles);
  }

  onRemove(event: any) {
    this.photos.splice(this.photos.indexOf(event), 1);
  }
}
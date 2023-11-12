import { ISubCategory } from './../../shared/interfaces/subcategory';
import { SubCategoryService } from './../../subcategory/sub-category.service';
import { HttpBackend, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { HobbyService } from '../services/hobby-aticle.service';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';
import { map } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UploadService } from '../services/upload-service.service';

@Component({
  selector: 'app-edit-hobby-form',
  templateUrl: './edit-hobby-form.component.html',
  styleUrls: ['./edit-hobby-form.component.css']
})
export class EditHobbyFormComponent implements OnInit {

  hobby!: IHobby;
  photos: File[] = [];
  private httpClient: HttpClient;
  subcategories!: ISubCategory[];
  editArticleForm: FormGroup = new FormGroup({});

  constructor(private activeRoute: ActivatedRoute, private hobbyService: HobbyService,
    private matDialog: MatDialog, private router: Router, private handler: HttpBackend,
    private subCategoryService: SubCategoryService, private uploadService: UploadService,
    private formBuilder: FormBuilder) {
    this.httpClient = new HttpClient(handler);
  }

  ngOnInit(): void {

    this.activeRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.hobbyService.getById(id).subscribe({
            next: (res) => {
              this.hobby = res;
              this.hobby.hobbyPhoto.forEach(p => {
                this.httpClient.get(p.url, { responseType: "arraybuffer" })
                  .pipe(map(response => {
                    return new File([response], "myImage.png");
                  })).forEach(f => this.photos.push(f));
              });
              this.getSubcategories();
              console.log(this.hobby);
            },
            error: (err) => {
              let obj = { title: 'Edit article', message: err, type: ModalType.WARN }
              this.matDialog.open(DialogTemplateComponent, { data: obj })
            }
          })
        }
      },
      error: (err) => {
        let obj = { title: 'Edit article', message: err, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj })
      }
    });

    this.editArticleForm = this.formBuilder.group({
      title: [null, [Validators.required, Validators.minLength(3)]],
      description: [null, [Validators.required, Validators.minLength(5)]],
      tags: [null, [Validators.required]],
      subcategory: [null, [Validators.required]],
      photos: [null]
    });

  }

  onSubmit(form: FormGroup) {
    this.hobbyService.updateHobby(this.hobby.id, this.hobby).subscribe({
      next: (res) => {
        let obj = { title: 'Edit article', message: "Article is changed successfull!", type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj });
        this.router.navigate(['home']);
      },
      error: (err) => {
        let obj = { title: 'Edit article', message: err, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj });
      }
    });
  }

  onSelect(event: any) {
    this.photos.push(...event.addedFiles);
  }

  onRemove(event: any) {
    this.photos.splice(this.photos.indexOf(event), 1);
  }

  getSubcategories() {
    this.subCategoryService.getSubCategories().subscribe({
      next: (res) => {
        this.subcategories = res;
      },
      error: (err) => {
        let obj = { title: 'Subcategories', message: err, type: ModalType.WARN }
        this.matDialog.open(DialogTemplateComponent, { data: obj })
      }
    })
  }
}



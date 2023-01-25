import { UploadService } from './../upload-service.service';
import { TagService } from './../../tag/tag.service';
import { SubCategoryService } from './../../subcategory/sub-category.service';
import { ITag } from './../../shared/interfaces/tag';
import { ISubCategory } from './../../shared/interfaces/subcategory';
import { HobbyService } from './../hobby-aticle.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { IPhoto } from 'src/app/shared/interfaces/photo';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MsalService } from '@azure/msal-angular';

@Component({
  selector: 'app-add-hobby',
  templateUrl: './add-hobby.component.html',
  styleUrls: ['./add-hobby.component.css']
})
export class AddHobbyComponent implements OnInit {
  
  createArticleForm: FormGroup = new FormGroup({});
  photos: File[]=[];
  subcategories: ISubCategory[] = [];
  tags: ITag[]=[];
  photosData: IPhoto[] = [];
  hobby!: IHobby;

  constructor(private formBuilder: FormBuilder, 
              private hobbyService: HobbyService, 
              private subCategoryService: SubCategoryService,
              private tagService: TagService,
              private uploadService: UploadService,
              private msalService: MsalService)
              {}


  ngOnInit():void{
    this.createArticleForm = this.formBuilder.group({
      title: [null, [Validators.required, Validators.minLength(3)]],
      description: [null, [Validators.required, Validators.minLength(5)]],
      tags: [null, [Validators.required]],
      subcategory: [null, [Validators.required]],
      photos: [null]
    });

    this.tagService.getAll().subscribe(res=>this.tags=res);
    this.subCategoryService.getSubCategories().subscribe(res=>this.subcategories=res);
  }

	onSelect(event: any) {
    this.photos.push(...event.addedFiles);
  }

	onRemove(event: any) {
    this.photos.splice(this.photos.indexOf(event), 1);
	}

  onSubmit(form: FormGroup){ 
    const data = new FormData();
        
    this.photos.forEach(f=>data.append('file', f, f.name));
    data.append('upload_preset', 'hobby_angular');
    data.append('cloud_name', 'dpqbf79wg');

  this.uploadService.uploadImage(data).subscribe(res=>{

     let photoMapped: IPhoto = {
        publicId: res.public_id,
        url: res.url, 
     };

     this.photosData.push(photoMapped);
     console.log(this.photosData)
     this.hobby=form.value;
     this.hobby.username=this.msalService.instance.getActiveAccount.name;
     this.hobby.hobbySubcategoryId=6;
     this.hobby.tags = this.tags;
     this.hobby.hobbyPhoto=this.photosData;
     console.log(this.hobby);
     this.hobbyService.addHobby(this.hobby).subscribe((response)=>console.log(response));
    }); 
 }
}


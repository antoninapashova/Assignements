import { HttpBackend, HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { HobbyService } from '../services/hobby-aticle.service';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';
import { map, reduce } from 'rxjs';

@Component({
  selector: 'app-edit-hobby-form',
  templateUrl: './edit-hobby-form.component.html',
  styleUrls: ['./edit-hobby-form.component.css']
})
export class EditHobbyFormComponent implements OnInit{
  hobby!: IHobby;
  photos: File[] = [];
  private httpClient: HttpClient;
  constructor(private activeRoute: ActivatedRoute, private hobbyService: HobbyService, 
              private matDialog: MatDialog, private router: Router, private handler: HttpBackend){
                this.httpClient = new HttpClient(handler);
              }

  ngOnInit(): void {
    this.activeRoute.paramMap.subscribe({
      next: (params)=>{
        const id = params.get('id');
        if(id){
          this.hobbyService.getById(id).subscribe({
            next:(res)=>{
              this.hobby=res;
              this.hobby.hobbyPhoto.forEach(p=>{
                 this.httpClient.get(p.url, {responseType: "arraybuffer"})
                 .pipe(map(response => {
                  return new File([response], "myImage.png");
                })).forEach(f=>this.photos.push(f));
              });
              console.log(this.photos);
            },
            error: (err)=>{
              let obj ={title: 'Edit article', message: err, type: ModalType.WARN}
              this.matDialog.open( DialogTemplateComponent, {data: obj})
            }
          })
        }
      },
      error: (err)=>{
          let obj ={title: 'Edit article', message: err, type: ModalType.WARN}
          this.matDialog.open( DialogTemplateComponent, {data: obj})
      }
    });
  }

  onSelect(event: any) {
    this.photos.push(...event.addedFiles);
  }

	onRemove(event: any) {
    this.photos.splice(this.photos.indexOf(event), 1);
	}

}

/*
this.hobbyService.updateHobby(id, this.hobby).subscribe({
            next: (res)=>{
              let obj ={title: 'Edit article', message: "Article is changed successfull!", type: ModalType.WARN}
              this.matDialog.open( DialogTemplateComponent, {data: obj});
               this.router.navigate(['home']);
              },
              error: (err)=>{
                let obj ={title: 'Edit article', message: err, type: ModalType.WARN}
                this.matDialog.open( DialogTemplateComponent, {data: obj});
              }
});
*/

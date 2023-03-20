import { UserStoreService } from 'src/app/user/user-store.service';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/user/user.service';
import { Component,  Input, OnInit,  ViewChild } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatAccordion } from '@angular/material/expansion';
import { HobbyService } from '../hobby-aticle.service';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';
import { HobbyCardDialogComponent } from '../hobby-card-dialog/hobby-card-dialog.component';

@Component({
  selector: 'app-hobby-card',
  templateUrl: './hobby-card.component.html',
  styleUrls: ['./hobby-card.component.css']
})
export class HobbyCardComponent implements OnInit {
  @ViewChild(MatAccordion) accordion!: MatAccordion;
  @Input() hobbies?: IHobby[];
  currentUsername!: string | undefined;
  role!: string;

  constructor(private hobbyService: HobbyService, private userService: UserService,
              private matDialog: MatDialog, private userStore:UserStoreService, 
              ) {}

   ngOnInit(): void {
      this.userStore.getFullNameFromStore().subscribe((val:any)=>{      
        const fullNameFromToken = this.userService.getFullNameFromToken();
        this.currentUsername = val || fullNameFromToken; 
       });
   
       this.userStore.getRoleFromStore().subscribe((val:any)=>{
         const roleFromToken = this.userService.getRoleFromToken();
         this.role = val || roleFromToken;
       });
    } 

    openDialog(hobby: IHobby){
     let obj = {title: hobby.title, description: hobby.description, username: hobby.username, photos: hobby.hobbyPhoto, comments: hobby.hobbyComments}
     this.matDialog.open( HobbyCardDialogComponent, {data: obj});
    }

    deleteArticle(id: any, username: any){
     if(this.currentUsername==username || this.role=='Admin'){
        this.hobbyService.deleteHobby(id).subscribe({
          next: (res)=>{
            let obj ={title: 'Hobby', message: 'Hobby is deleted successfull!', type: ModalType.INFO}
            this.matDialog.open( DialogTemplateComponent, {data: obj});
          },
          error: (err)=>{
            let obj ={title: 'Hobby', message: err, type: ModalType.WARN}
            this.matDialog.open( DialogTemplateComponent, {data: obj});
          }
        });
      }else{
        let obj ={title: 'Hobby', message: "You can not delete other users hobbies!", type: ModalType.WARN}
        this.matDialog.open( DialogTemplateComponent, {data: obj});
      }
    }
}

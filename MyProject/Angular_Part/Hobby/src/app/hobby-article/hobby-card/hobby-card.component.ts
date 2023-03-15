import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/user/user.service';
import { Component,  Input, OnInit,  ViewChild } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatAccordion } from '@angular/material/expansion';
import { IPhoto } from 'src/app/shared/interfaces/photo';
import { HobbyService } from '../hobby-aticle.service';
import { DialogTemplateComponent, ModalType } from 'src/app/core/dialog/dialog-template/dialog-template.component';

@Component({
  selector: 'app-hobby-card',
  templateUrl: './hobby-card.component.html',
  styleUrls: ['./hobby-card.component.css']
})
export class HobbyCardComponent implements OnInit {
  @ViewChild(MatAccordion) accordion!: MatAccordion;
  @Input() hobbies?: IHobby[];
  photos?: IPhoto[];

  currentUsername!: string | undefined;
  role!: string;

  constructor(private hobbyService: HobbyService, private userService: UserService,
              private matDialog: MatDialog) {}

   ngOnInit(): void {
      this.hobbies?.forEach(x=>{
          x.hobbyPhoto.forEach(p=>this.photos?.push(p));
      });
   } 

   deleteArticle(id: any, username: any){
      this.currentUsername = this.userService.getFullNameFromToken();
      this.role = this.userService.getRoleFromToken();

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

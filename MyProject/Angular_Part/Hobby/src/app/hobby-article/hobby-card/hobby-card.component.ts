import { HobbyService } from './../hobby-aticle.service';
import { Component,  Input, OnInit,  ViewChild } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatAccordion } from '@angular/material/expansion';

@Component({
  selector: 'app-hobby-card',
  templateUrl: './hobby-card.component.html',
  styleUrls: ['./hobby-card.component.css']
})
export class HobbyCardComponent implements OnInit {
  @ViewChild(MatAccordion) accordion!: MatAccordion;

  currentUsername!: string | undefined;
  constructor(private hobbyService:HobbyService ) {}

   @Input() hobbies?: IHobby[];

   ngOnInit(): void {
     //this.currentUsername= this.msalService.instance.getActiveAccount()?.name;
     console.log(this.hobbies);
   } 


   deleteArticle(id: any, username: any){
    /*
       if(this.currentUsername==username || this.msalService.instance.getActiveAccount()?.idTokenClaims?.roles){
         this.hobbyService.deleteHobby(id).subscribe(res=>console.log(res));
       }
       */
    }

}

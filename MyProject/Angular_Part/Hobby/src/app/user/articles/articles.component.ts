import { HobbyService } from './../../hobby-article/hobby-aticle.service';
import { UserService } from './../user.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IHobby } from 'src/app/shared/interfaces/hobby-article';
import { MatAccordion } from '@angular/material/expansion';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css'],
  providers: [UserService]
})
export class ArticlesComponent implements OnInit {

  activeAccount: string | undefined;
  hobbies: IHobby[] = [];
  userHobbies: IHobby[] = [];
  constructor(private hobbyService: HobbyService){}

  @ViewChild(MatAccordion) accordion!: MatAccordion;

  ngOnInit(): void {
       // this.activeAccount = this.authService.instance.getActiveAccount()?.name; 
        //console.log(this.activeAccount);
        this.hobbyService.getAll().subscribe(res=> {
            this.hobbies = res;
            this.userHobbies =this.hobbies.filter(x=>x.username==this.activeAccount);
        });
   }     


  deleteArticle(id: any, username: any){
    /*
    if(this.activeAccount==username || this.authService.instance.getActiveAccount()?.idTokenClaims?.roles){
      this.hobbyService.deleteHobby(id).subscribe(res=>console.log(res));
    }
    */
 }
}

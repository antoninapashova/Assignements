import { HobbyService } from '../../hobby-article/services/hobby-aticle.service';
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

  constructor(private hobbyService: HobbyService, private userService: UserService){}

  @ViewChild(MatAccordion) accordion!: MatAccordion;

  ngOnInit(): void {
    //TO DO:
        //this.activeAccount = this.authService.instance.getActiveAccount()?.name; 
        //to provide active account from jwt
        this.activeAccount = this.userService.getFullNameFromToken();
        console.log(this.activeAccount);
        this.hobbyService.getAll().subscribe(res=> {
            this.hobbies = res;
            this.userHobbies = this.hobbies.filter(x=>x.username == this.activeAccount);
        });
   }     

  deleteArticle(id: any, username: any){
    //TO DO:
    const role = false 
    //get role from jwt --> this.authService.instance.getActiveAccount()?.idTokenClaims?.roles
    if(this.activeAccount == username || role ){
      this.hobbyService.deleteHobby(id).subscribe();
    }
  }
}

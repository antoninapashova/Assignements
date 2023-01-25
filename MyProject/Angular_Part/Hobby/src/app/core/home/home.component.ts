import { IHobby } from './../../shared/interfaces/hobby-article';
import { HobbyService } from './../../hobby-article/hobby-aticle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  hobbies: IHobby[] = [];
  
  constructor(private hobbyService: HobbyService){ }

  ngOnInit(): void {
      this.hobbyService.getAll().subscribe(res=>{
      console.log(res);
      this.hobbies=res;
      console.log(this.hobbies);
    });
  }
    
}

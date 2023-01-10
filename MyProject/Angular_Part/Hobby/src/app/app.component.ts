import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  pageTitle : string = 'Hobby_Project';

  onTitleChangeHandler($event: any){
   console.log($event);
  }
}

import { IUser } from 'src/app/shared/interfaces/user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

const GRAPH_ENDPOINT= 'https://graph.microsoft.com/v1.0/me';

@Injectable({
  providedIn: 'root'
})
export class AzureAdService {
  
  isUserLogedIn: Subject<boolean>= new Subject<boolean>;
  username!: string | undefined;
  name!: string | undefined;
  
  constructor(private httpClient: HttpClient) { }

  getUserProfile(){
    return this.httpClient.get<IUser>(GRAPH_ENDPOINT)
  }
}

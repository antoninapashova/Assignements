import { HttpClient } from '@angular/common/http';
import { TokenApiModel } from './../shared/interfaces/token-api';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../shared/urls/base-url';
import { ApiPaths } from '../shared/urls/api-paths';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {

  private fullName = new BehaviorSubject<string>("");
  private role = new BehaviorSubject<string>("");
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

   getRoleFromStore(){
    return this.role.asObservable();
   }

   setRoleForStore(role: string){
    this.role.next(role);
   }

   getFullNameFromStore(){
    return this.fullName.asObservable();
   }

   setFullName(fullName: string){
    return this.fullName.next(fullName)
   }
}

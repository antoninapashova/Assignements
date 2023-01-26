import { ApiPaths } from './../shared/urls/api-paths';
import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import {Observable} from 'rxjs';
import { IHobby } from "../shared/interfaces/hobby-article";
import { environment } from "../shared/urls/base-url";

@Injectable({
    providedIn: 'root',
})
export class HobbyService{
   
    constructor(private httpClient: HttpClient){}
  
    baseUrl = environment.baseUrl;

    getAll(): Observable<IHobby[]> {
        return this.httpClient.get<IHobby[]>(`${this.baseUrl}${ApiPaths.Hobby}`)
   }

    getById(id: string) : Observable<IHobby>{
        return this.httpClient.get<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`)
    }
    
    addHobby(hobby: IHobby) : Observable<IHobby>{
        return this.httpClient.post<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}`, hobby);
    }

    updateHobby(id: string, hobby: IHobby) : Observable<IHobby>{
        return this.httpClient.put<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`, hobby);
    }

    deleteHobby(id: string) : Observable<IHobby>{
        return this.httpClient.delete<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`);
    }
     
}
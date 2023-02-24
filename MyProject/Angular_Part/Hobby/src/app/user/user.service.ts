import { ApiPaths } from './../shared/urls/api-paths';
import { environment } from './../shared/urls/base-url';
import { Observable } from 'rxjs';
import { IUser } from './../shared/interfaces/user';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IHobby } from '../shared/interfaces/hobby-article';

@Injectable({
    providedIn: 'root',
})
export class UserService{

    constructor(private httpClient: HttpClient){}
    
    baseUrl = environment.baseUrl;
    
    getById(id: string) : Observable<IUser>{
        return this.httpClient.get<IUser>(`${this.baseUrl}${ApiPaths.User}/${id}`);
    }

    addUser(user: IUser) : Observable<any>{
        return this.httpClient.post(`${this.baseUrl}${ApiPaths.User}`, user);
    }

    updateUser(id: string, user: IUser) : Observable<IUser>{
        return this.httpClient.put<IUser>(`${this.baseUrl}${ApiPaths.User}/${id}`, user);
    }
   
    deleteUser(id: string) : Observable<any>{
        return this.httpClient.delete(`${this.baseUrl}${ApiPaths.User}/${id}`);
    }

    getUserArticles(id: string) : Observable<IHobby[]>{
        return this.httpClient.get<IHobby[]>(`${this.baseUrl}${ApiPaths.User}/${id}`)
    }

    login(obj: Object): Observable<IUser>{
        return this.httpClient.post<IUser>(`${this.baseUrl}${ApiPaths.User}/login`,obj);
    }

}
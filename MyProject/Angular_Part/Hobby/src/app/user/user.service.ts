import { JwtHelperService } from '@auth0/angular-jwt';
import { ApiPaths } from './../shared/urls/api-paths';
import { environment } from './../shared/urls/base-url';
import { Observable } from 'rxjs';
import { IUser } from './../shared/interfaces/user';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IHobby } from '../shared/interfaces/hobby-article';
import { TokenApiModel } from '../shared/interfaces/token-api';

@Injectable({
    providedIn: 'root',
})
export class UserService{

    private userPayload:any;
    constructor(private httpClient: HttpClient){
        this.userPayload = this.decodeToken();
    }
    
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

    login(obj: Object): Observable<any>{
        return this.httpClient.post<any>(`${this.baseUrl}${ApiPaths.User}/authenticate`, obj);
    }

    signOut(){
       localStorage.clear();
    }

    storeToken(tokenValue: string){
        localStorage.setItem('token', tokenValue);
    }

    storeRefreshToken(tokenValue: string){
        localStorage.setItem('refreshToken', tokenValue);
    }

    getToken(){
        return localStorage.getItem('token');
    }

    getRefreshToken(){
        return localStorage.getItem('refreshToken');
    }

    isLoggedIn(): boolean{
        return !!localStorage.getItem('token');
    }

    decodeToken(){
        const jwtHelper = new JwtHelperService();
        const token = this.getToken()!;
        return jwtHelper.decodeToken(token);
    }

    getFullNameFromToken(){
        if(this.userPayload){
            return this.userPayload.unique_name;
        }
    }

    getRoleFromToken(){
        if(this.userPayload){
            return this.userPayload.role;
        }
    }
    
   renewToken(tokenApi: TokenApiModel){
      return this.httpClient.post<any>(`${this.baseUrl}${ApiPaths.User}/refresh`, tokenApi)
   }

}
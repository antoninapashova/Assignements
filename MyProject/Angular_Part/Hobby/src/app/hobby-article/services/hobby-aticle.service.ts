import { ApiPaths } from '../../shared/urls/api-paths';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { IHobby } from "../../shared/interfaces/hobby-article";
import { environment } from "../../shared/urls/base-url";

@Injectable({
    providedIn: 'root',
})
export class HobbyService {
    baseUrl = environment.baseUrl;

    constructor(private httpClient: HttpClient) { }

    getAll(): Observable<IHobby[]> {
        return this.httpClient.get<IHobby[]>(`${this.baseUrl}${ApiPaths.Hobby}/All`);
    }

    getById(id: string | undefined): Observable<IHobby> {
        const headers = new HttpHeaders().append('Access-Control-Allow-Origin', '*');
        return this.httpClient.get<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`, { headers });
    }

    getArticlesByUsername(username: string | undefined): Observable<IHobby[]> {
        const headers = new HttpHeaders().append('Access-Control-Allow-Origin', '*');
        return this.httpClient.get<IHobby[]>(`${this.baseUrl}${ApiPaths.Hobby}/${username}`, { headers });
    }

    addHobby(hobby: IHobby): Observable<IHobby> {
        return this.httpClient.post<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}`, hobby);
    }

    updateHobby(id: number, hobby: IHobby): Observable<IHobby> {
        return this.httpClient.put<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`, hobby);
    }

    deleteHobby(id: number): Observable<IHobby> {
        return this.httpClient.delete<IHobby>(`${this.baseUrl}${ApiPaths.Hobby}/${id}`);
    }
}
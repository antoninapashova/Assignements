import { ApiPaths } from './../shared/urls/api-paths';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ITag } from '../shared/interfaces/tag';
import { environment } from '../shared/urls/base-url';


@Injectable({
    providedIn: 'root',
})
export class TagService {
    baseUrl = environment.baseUrl;

    constructor(private httpClient : HttpClient){}

    getAll() : Observable<ITag[]>{
        return this.httpClient.get<ITag[]>(`${this.baseUrl}${ApiPaths.Tag}/All`);
    }

    getById(id: string) : Observable<ITag>{
        return this.httpClient.get<ITag>(`${this.baseUrl}${ApiPaths.Tag}/${id}`);
    }

    addTag(tag: any) : Observable<any> {
        return this.httpClient.post<any>(`${this.baseUrl}${ApiPaths.Tag}`, tag);
    }

    delete(id: string) : Observable<ITag> {
        return this.httpClient.delete<ITag>(`${this.baseUrl}${ApiPaths.Tag}/${id}`);
    }
}
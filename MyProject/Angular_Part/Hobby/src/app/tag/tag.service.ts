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

    constructor(private httpClient : HttpClient){}

    baseUrl = environment.baseUrl;



    getAll() : Observable<ITag[]>{
        return this.httpClient.get<ITag[]>(`${this.baseUrl}${ApiPaths.Tag}`);
    }

    getById(id: string) : Observable<ITag>{
        return this.httpClient.get<ITag>(`${this.baseUrl}${ApiPaths.Tag}/${id}`);
    }

    addTag(tag: ITag) : Observable<ITag> {
        return this.httpClient.post<ITag>(`${this.baseUrl}${ApiPaths.Tag}`, tag);
    }

    delete(id: string) : Observable<ITag> {
        return this.httpClient.delete<ITag>(`${this.baseUrl}${ApiPaths.Tag}/${id}`);
    }
}
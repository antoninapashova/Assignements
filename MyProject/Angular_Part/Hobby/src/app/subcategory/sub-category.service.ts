import { ApiPaths } from './../shared/urls/api-paths';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {Observable} from 'rxjs';
import { ISubCategory } from "../shared/interfaces/subcategory";
import { environment } from "../shared/urls/base-url";

@Injectable({
    providedIn: 'root',
})
export class SubCategoryService{

    constructor(private httpClient: HttpClient){}

    baseUrl = environment.baseUrl;
    
    getSubCategories() : Observable<ISubCategory[]>{
        return this.httpClient.get<ISubCategory[]>(`${this.baseUrl}${ApiPaths.SubCategory}/All`);
    }

    getSubCategoryById(id: string) : Observable<ISubCategory>{
        return this.httpClient.get<ISubCategory>(`${this.baseUrl}${ApiPaths.SubCategory}/${id}`)
    }

    addSubCategory(subCategory: ISubCategory): Observable<ISubCategory>{
        return this.httpClient.post<ISubCategory>(`${this.baseUrl}${ApiPaths.SubCategory}`, subCategory);
    }

    deleteSubCategory(id: string) : Observable<ISubCategory>{
        return this.httpClient.delete<ISubCategory>(`${this.baseUrl}${ApiPaths.SubCategory}/${id}`);
    }
}
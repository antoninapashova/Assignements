import { CreateCategoryDto } from './../shared/dtos/create-category-dto';
import { GetCategoryDto } from './../shared/dtos/get-category-dto';
import { ApiPaths } from './../shared/urls/api-paths';
import { environment } from './../shared/urls/base-url';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable} from 'rxjs';


@Injectable({
    providedIn: 'root',
})
export class CategoryService {

    constructor(private httpClient: HttpClient){}
    
    baseUrl = environment.baseUrl;

    getCategories(): Observable<any>{
       return this.httpClient.get<any>(`${this.baseUrl}${ApiPaths.Category}/categories`);
    }

    getNames(): Observable<any>{
        return this.httpClient.get<any>(`${this.baseUrl}${ApiPaths.Category}/names`);
    }
   
     getCategoryById(id: string) : Observable<GetCategoryDto>{
        return this.httpClient.get<GetCategoryDto>(`${this.baseUrl}${ApiPaths.Category}/${id}`)
    }

    addCategory(category : CreateCategoryDto) : Observable<any>{
       const headers = new HttpHeaders({
         'Content-Type': 'application/json',
         'accept': '*/*'
       });

       const body = JSON.stringify(category);

        return this.httpClient.post<any>(`${this.baseUrl}${ApiPaths.Category}`,  category, {headers: headers} );
         
    }

    delete(id: string): Observable<any>{
        return this.httpClient.delete(`${this.baseUrl}${ApiPaths.Category}/${id}`);
    }
    
}

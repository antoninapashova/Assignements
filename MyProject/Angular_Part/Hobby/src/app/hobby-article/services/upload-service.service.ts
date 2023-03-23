import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpBackend, HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
    providedIn: 'root',
})
export class UploadService{

    private httpClient: HttpClient;

    constructor(handler: HttpBackend){this.httpClient = new HttpClient(handler);}

    uploadImage(vals: any): Observable<any>{
        let data = vals;
        return this.httpClient.post<any>('https://api.cloudinary.com/v1_1/dpqbf79wg/image/upload',  data)
    }
}
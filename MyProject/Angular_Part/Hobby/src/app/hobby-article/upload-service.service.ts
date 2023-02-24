import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
    providedIn: 'root',
})
export class UploadService{

    constructor(private _http: HttpClient){}

    uploadImage(vals: any): Observable<any>{
        let data = vals;
        return this._http.post<any>('https://api.cloudinary.com/v1_1/dpqbf79wg/image/upload',  data)
    }

    
}
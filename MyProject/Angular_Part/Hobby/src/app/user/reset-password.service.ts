import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResetPassword } from '../shared/interfaces/reset-password.model';
import { environment } from '../shared/urls/base-url';
import { ApiPaths } from './../shared/urls/api-paths';


@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {

    baseUrl = environment.baseUrl;

   constructor(private _httpClient: HttpClient) { }

   sendResetPassworLink(email: string): Observable<string>{
      return this._httpClient.get<string>(`${this.baseUrl}${ApiPaths.User}/send-reset-email/${email}`);
   }
   
   resetPassword(resetPasswordObj: ResetPassword){
      return this._httpClient.post<any>(`${this.baseUrl}${ApiPaths.User}/reset-password`, resetPasswordObj);
   }

}

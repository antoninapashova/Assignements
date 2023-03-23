import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IComment } from 'src/app/shared/interfaces/comment';
import { ApiPaths } from 'src/app/shared/urls/api-paths';
import { environment } from 'src/app/shared/urls/base-url';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  baseUrl = environment.baseUrl;
  constructor(private httpClient: HttpClient) { }

  createComment(comment: IComment): Observable<IComment> {
    return this.httpClient.post<IComment>(`${this.baseUrl}${ApiPaths.Comment}`, comment);
  }

}

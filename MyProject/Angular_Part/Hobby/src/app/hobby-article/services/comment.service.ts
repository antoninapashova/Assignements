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

  getCommentsByHobbyId(hobbyId: any): Observable<IComment[]>{
    return this.httpClient.get<IComment[]>(`${this.baseUrl}${ApiPaths.Comment}/${hobbyId}`);
  }

  editComment(hobbyId: any, comment: any): Observable<number> {
    return this.httpClient.put<number>(`${this.baseUrl}${ApiPaths.Comment}/${hobbyId}`, comment);
  }

  deleteComment(id: any): Observable<any>{
    return this.httpClient.delete<any>(`${this.baseUrl}${ApiPaths.Comment}/${id}`);
  }

  getCommentReplies(parrentId: number): Observable<IComment[]> {
    return this.httpClient.get<IComment[]>(`${this.baseUrl}/reply/${parrentId}`);
  }
}

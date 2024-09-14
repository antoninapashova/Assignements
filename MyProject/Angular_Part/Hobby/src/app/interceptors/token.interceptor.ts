import { TokenApiModel } from './../shared/interfaces/token-api';
import { UserService } from './../user/user.service';
import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { DialogTemplateComponent, ModalType } from '../core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private userService: UserService, private matDialog: MatDialog, private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler) {
    const token = this.userService.getToken();

    if (token) {
      request = request.clone({
        setHeaders: { Authorization: `Bearer ${token}` }
      });
    }

    return next.handle(request).pipe(
      catchError((err: any) => {
        const refreshToken = this.userService.getRefreshToken();
        if (err instanceof HttpErrorResponse && err.status === 401 && refreshToken) {
          return this.handleUnauthorizedError(request, next);
        } else {
          return throwError(() => new Error(err.error.detail));
        }
      })
    );
  }

  handleUnauthorizedError(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let tokenApiModel = new TokenApiModel();
    tokenApiModel.accessToken = this.userService.getToken()!;
    tokenApiModel.refreshToken = this.userService.getRefreshToken()!;

    return this.userService.renewToken(tokenApiModel)
      .pipe(
        switchMap((data: TokenApiModel) => {
          this.userService.storeRefreshToken(data.refreshToken);
          this.userService.storeToken(data.accessToken);
          req = req.clone({
            setHeaders: { Authorization: `Bearer ${data.accessToken}` }
          });
          return next.handle(req);
        }),
        catchError(() => {
          return throwError(() => {
            this.matDialog.open(DialogTemplateComponent, { data: { title: 'Warning', message: 'Token is expired, please sign in again', type: ModalType.INFO } });
            this.router.navigate(['login'])
          });
        }));
  }
}
import { TokenApiModel } from './../shared/interfaces/token-api';
import { UserService } from './../user/user.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { DialogTemplateComponent, ModalType } from '../core/dialog/dialog-template/dialog-template.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DialogService } from '../core/dialog/dialog.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private userService: UserService, 
              private matDialog: MatDialog,
              private router: Router, private dialogService: DialogService  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.userService.getToken();

    if(token){
      request = request.clone({
        setHeaders: {Authorization: `Bearer ${token}`}
      });
    }
    
    return next.handle(request).pipe(
      catchError((err)=>{
        if(err instanceof HttpErrorResponse){
           if(err.status === 401){
            return this.handleUnauthorizedError(request, next);       
           }
        }
        return throwError(()=>new Error("Some other error occured"));
      })
    );
  }

  handleUnauthorizedError(req: HttpRequest<any>, next: HttpHandler){
    let tokenApiModel = new TokenApiModel();
    tokenApiModel.accessToken = this.userService.getToken()!;
    tokenApiModel.refreshToken = this.userService.getRefreshToken()!;

    return this.userService.renewToken(tokenApiModel)
    .pipe(
      switchMap((data:TokenApiModel)=>{
        this.userService.storeRefreshToken(data.refreshToken);
        this.userService.storeToken(data.accessToken);
        req = req.clone({
          setHeaders: {Authorization: `Bearer ${data.accessToken}`}
        });
        return next.handle(req);
      }
    ),
    catchError((err)=>{
      return throwError(()=>{
       let obj ={title: 'Warning', message: 'Token is expired, Please Login again', type: ModalType.INFO}
       this.matDialog.open( DialogTemplateComponent, {data: obj});  
       this.router.navigate(['login']) 
      })
    }));
  }
}

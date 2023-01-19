import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isUserLoggedIn = true;

  constructor() { }

  isUserAuthenticated(): boolean {
    return this.isUserLoggedIn;
  }

  getToken() {
    return localStorage.getItem('auth-token');
  }
}


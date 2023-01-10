import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
    /*
    {
     path: 'login',
       component: LoginComponent,
       canActivate: [AuthActivate],
       data: {
           authenticationRequired: false,
           authenticationFailureRedirectUrl: '/login'
       }
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [AuthActivate],
        data: {
            authenticationRequired: false,
            authenticationFailureRedirectUrl: '/register'
        }
    },
    {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthActivate],
        data: {
            authenticationRequired: true,
            authenticationFailureRedirectUrl: '/login'
        }
    },
    {
        path: 'user-posts',
        component: UserpostsComponent,
        data: {
            authenticationRequired: true,
            authenticationFailureRedirectUrl: '/login'
        }
    },
    {
        path: 'about',
        component: AboutComponent,
        data: {
            authenticationRequired: false
        }
    }
    */
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
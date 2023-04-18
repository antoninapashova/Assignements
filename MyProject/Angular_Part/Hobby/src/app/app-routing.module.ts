import { ResetPasswordComponent } from './user/reset-password/reset-password.component';
import { ForgetPasswordComponent } from './user/forget-password/forget-password.component';
import { AuthGuard } from './auth/auth-guard.guard';
import { RegisterComponent } from './user/register/register.component';
import { LoginComponent } from './user/login/login.component';
import { AboutComponent } from './core/about/about.component';
import { TagListComponent } from './tag/tag-list/tag-list.component';
import { HomeComponent } from './core/home/home.component';
import { AddHobbyComponent } from './hobby-article/add-hobby/add-hobby.component';
import { AddTagComponent } from './tag/add-tag/add-tag.component';
import { AddSubcategoryComponent } from './subcategory/add-subcategory/add-subcategory.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { ArticlesComponent } from './user/articles/articles.component';
import { AddCategoryComponent } from './category/add-category/add-category.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditHobbyFormComponent } from './hobby-article/edit-hobby-form/edit-hobby-form.component';

const routes: Routes = [
    {
    path: 'login',
     component: LoginComponent
    },
    {
     path: 'register',
     component: RegisterComponent
    },
     {
     path: 'forgot-password',
     component: ForgetPasswordComponent
     },
     {
        path: 'reset',
        component: ResetPasswordComponent
     },
     {
    path: 'add-category',
    component: AddCategoryComponent,
    canActivate: [AuthGuard],
    data: {
      roles: [ 'Admin' ]
    },
   },

   {
    path: 'user',
    children:[
      {
          path: 'articles',
          component: ArticlesComponent,
          canActivate: [AuthGuard],
          data: {
            roles: [ 'Admin', 'User' ]
          },
       },
       {
        path: 'add-article',
        component: AddHobbyComponent,
        canActivate: [AuthGuard],
        data: {
          roles: [ 'User', 'Admin' ]
        },
       },
       
      ],
     },
     {
      path: 'category',
      children:[
        {
          path: 'add',
          component: AddCategoryComponent,
          canActivate: [AuthGuard],
          data: {
            roles: [ 'Admin' ]
          },
        },
        {
          path: 'get-all',
          component: CategoryListComponent,
          canActivate: [AuthGuard],
        }
      ]
     },
     {
      path: 'subcategory',
      children: [
        {
         path: 'add',
         component: AddSubcategoryComponent,
         canActivate: [AuthGuard],
         data: {
          roles: [ 'Admin' ]
        },
        },
      ],
     },
     {
        path: 'tag',
        children:[
          {
            path: 'add',
            component: AddTagComponent,
            canActivate: [AuthGuard],
            data: {
              roles: [ 'Admin' ]
            },
          },
          {
            path: 'get-all',
            component: TagListComponent,
            canActivate: [AuthGuard],
            data:{
              roles: [ 'Admin', 'User' ]

            }
          }
         ]
      },
      {
        path: 'home',
        component: HomeComponent,
        canActivate: [AuthGuard],
        data: {
          roles: [ 'User', 'Admin' ]
        },
        children:[
          
        ]
      },
      {
        path: 'about',
        component: AboutComponent
      },
      {
        
          path: 'home/user/edit-article/:id',
          component: EditHobbyFormComponent,
          canActivate: [AuthGuard],
          data: {
            roles: [ 'User', 'Admin' ]
          },
         
      }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      initialNavigation: 'enabledBlocking',
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

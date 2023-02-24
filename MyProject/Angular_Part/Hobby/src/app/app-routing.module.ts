import { RegisterComponent } from './user/register/register.component';
import { LoginComponent } from './user/login/login.component';
import { AboutComponent } from './core/about/about.component';
import { TagListComponent } from './tag/tag-list/tag-list.component';
import { IndexComponent } from './core/index/index.component';
import { HomeComponent } from './core/home/home.component';
import { AddHobbyComponent } from './hobby-article/add-hobby/add-hobby.component';
import { AddTagComponent } from './tag/add-tag/add-tag.component';
import { AddSubcategoryComponent } from './subcategory/add-subcategory/add-subcategory.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { ArticlesComponent } from './user/articles/articles.component';
import { AddCategoryComponent } from './category/add-category/add-category.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
    path: 'add-category',
    component: AddCategoryComponent,
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
          data: {
            roles: [ 'Admin', 'User' ]
          },
          
       },

       {
        path: 'add-article',
        component: AddHobbyComponent,
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
          data: {
            roles: [ 'Admin' ]
          },
        },
        {
          path: 'get-all',
          component: CategoryListComponent,
           
        }
      ]
     },
     {
      path: 'subcategory',
      children: [
        {
         path: 'add',
         component: AddSubcategoryComponent,
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
            data: {
              roles: [ 'Admin' ]
            },
          },
          {
            path: 'get-all',
            component: TagListComponent,
            data:{
              roles: [ 'Admin', 'User' ]

            }
          }
         ]
      },
      {
        path: '',
        component: IndexComponent
      },
      {
        path: 'home',
        component: HomeComponent,
        data: {
          roles: [ 'User', 'Admin' ]
        },
      },
      {
        path: 'about',
        component: AboutComponent
      }

];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      initialNavigation: 'enabledBlocking',
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

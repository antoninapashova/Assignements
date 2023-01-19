import { AddHobbyComponent } from './hobby-article/add-hobby/add-hobby.component';
import { AddTagComponent } from './tag/add-tag/add-tag.component';
import { AddSubcategoryComponent } from './subcategory/add-subcategory/add-subcategory.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { ArticlesComponent } from './user/articles/articles.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { AddCategoryComponent } from './category/add-category/add-category.component';
import { NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
   {
    path: 'add-category',
    component: AddCategoryComponent
   },
   {
    path: 'user',
    children:[
       {
        path: 'login',
        component: LoginComponent
       },
       {
        path: 'register',
        component: RegisterComponent,
       
       },
       {
          path: 'articles',
          component: ArticlesComponent
       },
       {
        path: 'add-article',
        component: AddHobbyComponent
       }
      ],
       
    },
     {
      path: 'category',
      children:[
        {
          path: 'add',
          component: AddCategoryComponent
        },
        {
          path: 'getAll',
          component: CategoryListComponent
        }
      ]
     },
     {
      path: 'subcategory',
      children: [
        {
         path: 'add',
         component: AddSubcategoryComponent,
        },
      ],

     },
      {
        path: 'tag',
        children:[
          {
            path: 'add',
            component: AddTagComponent,
          }
         ]
      }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

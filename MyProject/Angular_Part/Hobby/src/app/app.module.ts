
import { FormsModule } from '@angular/forms';
import { TagModule } from './tag/tag.module';
import { SubcategoryModule } from './subcategory/subcategory.module';
import { HobbyArticleModule } from './hobby-article/hobby-article.module';
import { CategoryModule } from './category/category.module';
import { UserModule } from './user/user.module';
import { CoreModule } from './core/core.module';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { CommonModule } from '@angular/common';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { MsalModule, MsalRedirectComponent, MsalService, MsalBroadcastService, MsalInterceptor, MsalGuard } from '@azure/msal-angular';
import { PublicClientApplication, InteractionType } from '@azure/msal-browser';
import { AzureAdService } from './auth/azure-ad.service';

const isIE = window.navigator.userAgent.indexOf('MSIE') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

@NgModule({
  declarations: [
    AppComponent,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CoreModule,
    UserModule,
    CategoryModule,
    TagModule,
    FormsModule,
    HobbyArticleModule,
    SubcategoryModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatTabsModule,
    CommonModule,
    NgxDropzoneModule,
    MsalModule.forRoot(new PublicClientApplication
      (
        {
        auth: {
          clientId: '4378f475-831c-43d9-b411-90c0e7d04f06', 
          authority: 'https://login.microsoftonline.com/544f8ac3-ce4c-47d1-9b72-284ac54b8d1c',
          redirectUri: 'http://localhost:4200/home',
         },
         cache:{
          cacheLocation: 'localStorage',
          storeAuthStateInCookie: isIE,
         }
      }
    ),
      {
        interactionType: InteractionType.Redirect,
        authRequest: {
          scopes: ['user.read']
        }
      },
      {
        interactionType: InteractionType.Redirect,
        protectedResourceMap: new Map(
          [
            ['https://graph.microsoft.com/v1.0/me', ['user.Read']],
            ['localhost', ['api://f5918e9f-90bf-44e3-b844-6e887463e400/api.scope']]
          ]
        )
      }
    )
],
  providers: [
  MsalService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: MsalInterceptor,
    multi: true,
  },
  MsalGuard,
  MsalService,
  MsalBroadcastService,
  AzureAdService
  ],
  exports:[
    TagModule,
    FormsModule,
    HobbyArticleModule,
    CoreModule,
    SubcategoryModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatTabsModule,
    MatListModule],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }

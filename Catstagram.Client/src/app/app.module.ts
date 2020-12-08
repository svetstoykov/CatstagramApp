import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CatListComponent } from './cat-list/cat-list.component';
import { CatDetailsComponent } from './cat-details/cat-details.component';
import { CreatepostComponent } from './createpost/createpost.component';
import { CatService } from './services/applicationServices/cat.service';
import { SearchService } from './services/applicationServices/search.service';
import { AuthService } from './services/authenticationServices/auth.service';
import { AuthGuardService } from './services/authenticationServices/auth-guard.service';
import { TokenInterceptorService } from './services/interceptorServices/token-interceptor.service';
import { ErrorInterceptorService } from './services/interceptorServices/error-interceptor.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { SearchComponent } from './search/search.component';
import { UserProfileComponent } from './user-profile/user-profile.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreatepostComponent,
    CatListComponent,
    CatDetailsComponent,
    HeaderComponent,
    SearchComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AuthService,
    CatService,
    SearchService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CreatepostComponent } from './createpost/createpost.component';
import { AuthGuardService } from './services/authenticationServices/auth-guard.service';
import { CatListComponent } from './cat-list/cat-list.component';
import { CatDetailsComponent } from './cat-details/cat-details.component';
import { SearchComponent } from './search/search.component'
import {UserProfileComponent} from './user-profile/user-profile.component'

const routes: Routes = [
  { path: '', redirectTo: "/cats", pathMatch: "full"},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'search', component: SearchComponent},
  { path: 'profile', component: UserProfileComponent, canActivate: [AuthGuardService]},
  { path: 'create', component: CreatepostComponent, canActivate: [AuthGuardService],},
  { path: 'cats', component: CatListComponent, canActivate: [AuthGuardService],},
  { path: 'cats/:id', component: CatDetailsComponent, canActivate: [AuthGuardService],},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

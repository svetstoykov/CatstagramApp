import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { UserProfile } from '../../models/UserProfile';
import { AuthService } from '../authenticationServices/auth.service';


@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private userPath = environment.apiUrl + '/profile';

  constructor(private http: HttpClient, private authService: AuthService) {}

  getCurrentUser(): Observable<UserProfile>{
    return this.http.get<UserProfile>(this.userPath);
  }

  
}

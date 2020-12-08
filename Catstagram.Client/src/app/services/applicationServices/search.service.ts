import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { AuthService } from '../authenticationServices/auth.service';
import {UserSearch} from '../../models/UserSearch';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  private searchPath = environment.apiUrl + '/search';

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  search(username): Observable<Array<UserSearch>>{
    return this.httpClient.get<Array<UserSearch>>(`${this.searchPath}/${username}`)
  }

}

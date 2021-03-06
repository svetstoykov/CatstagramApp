import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Cat } from '../../models/Cat';
import { AuthService } from '../authenticationServices/auth.service';
import { CatDetails } from '../../models/CatDetails';
import { CatUpdate } from '../../models/CatUpdate';


@Injectable({
  providedIn: 'root',
})
export class CatService {
  private catPath = environment.apiUrl + '/cats';
  constructor(private http: HttpClient, private authService: AuthService) {}

  create(data): Observable<Cat> {
    return this.http.post<Cat>(this.catPath, data);
  }

  getCats(): Observable<Array<Cat>> {
    return this.http.get<Array<Cat>>(this.catPath);
  }

  getCatById(id): Observable<CatDetails> {
    return this.http.get<CatDetails>(`${this.catPath}/${id}`);
  }

  deleteCatById(id): Observable<Cat>{
    return this.http.delete<Cat>(`${this.catPath}/${id}`);
  }

  updateCat(data): Observable<CatUpdate>{
    return this.http.put<CatUpdate>(`${this.catPath}`, data);
  }
}

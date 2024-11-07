import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiEndpoint = 'auth';
  baseUrl = `${environment.API_URL}/${this.apiEndpoint}`;
  
  constructor(private httpClient: HttpClient) {
  }
  
  signUp(user: any) {
    return this.httpClient.post(`${this.baseUrl}`, user);
  }
}

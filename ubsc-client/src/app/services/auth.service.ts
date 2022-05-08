import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginURL = environment.serverURL + '/Identity/Login';
  private registerURl = environment.serverURL + '/Identity/Register';

  constructor(private http: HttpClient) {}

  login(data): Observable<any> {
    return this.http.post(this.loginURL, data);
  }

  register(data): Observable<any> {
    return this.http.post(this.registerURl, data);
  }

  saveToken(token){
    localStorage.setItem('token', token);
  }

  getToken(){
    return localStorage.getItem('token');
  }
}

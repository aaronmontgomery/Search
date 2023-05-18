import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private _httpClient: HttpClient;

  constructor(httpClient: HttpClient) {
    this._httpClient = httpClient;
  }
  
  get<T>(url: string): Observable<T> {
    return this._httpClient.get<T>(url);
  }

}

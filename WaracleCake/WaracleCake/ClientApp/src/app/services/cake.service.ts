import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Cake } from '../models/cake';

@Injectable({
  providedIn: 'root'
})
export class CakeService {

  baseApiUrl: string;
  endPoint: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.baseApiUrl = environment.cakeApiBaseUrl;
      this.endPoint = 'api/cakes/';
  }

  getCakes(): Observable<Cake[]> {
    return this.http.get<Cake[]>(this.baseApiUrl + this.endPoint)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getCake(id: number): Observable<Cake> {
      return this.http.get<Cake>(this.baseApiUrl + this.endPoint + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  saveCake(cake): Observable<Cake> {
      return this.http.post<Cake>(this.baseApiUrl + this.endPoint, JSON.stringify(cake), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateCake(postId: number, cake): Observable<Cake> {
      return this.http.put<Cake>(this.baseApiUrl + this.endPoint + postId, JSON.stringify(cake), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteCake(postId: number): Observable<Cake> {
      return this.http.delete<Cake>(this.baseApiUrl + this.endPoint + postId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.status = 409){
      errorMessage = 'A cake with this name already exists, please choose another name.'
    } 
    else {
      errorMessage = 'Something went wrong, please try again later.';
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Business } from '../Models/business-model';
import { catchError, Observable, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BusinessService {
    private apiUrl = 'https://localhost:7273/api/businesses';

    constructor(private http: HttpClient) {}
    
    getBusinesses(): Observable<any>{
        return this.http.get(this.apiUrl).pipe(
            catchError(error => {
                console.error('Error fetching businesses:', error);
                return throwError(() => error);
            })
        );
    }
}


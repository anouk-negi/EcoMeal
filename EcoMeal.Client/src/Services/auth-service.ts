import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthResponse } from '../Models/auth-response-model';
import { User } from '../Models/user-model';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
    private apiUrl = 'https://localhost:7273/api/auth';
    private currentUserSubject = new BehaviorSubject<User | null>(null);
    public currentUser$ = this.currentUserSubject.asObservable();

    constructor(private http: HttpClient) {
        this.loadUserFromToken();
    }

    login(email: string, password: string, role: string): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/login`, { email, password, role })
        .pipe(
            tap(response => this.handleAuthResponse(response))
        );
    }

    register(email: string, password: string, name: string, role: string): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/register`, {
        email,
        password,
        name,
        role
        })
        .pipe(
        tap(response => this.handleAuthResponse(response))
        );
    }

    logout(): void {
        localStorage.removeItem('token');
        this.currentUserSubject.next(null);
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    isAuthenticated(): boolean {
        return !!this.getToken();
    }

    private handleAuthResponse(response: AuthResponse): void {
        localStorage.setItem('token', response.token);
        this.currentUserSubject.next(response.user);
    }

    private loadUserFromToken(): void {
        const token = this.getToken();
        if (token) {
        const payload = this.parseJwt(token);
        const user: User = {
            id: payload.sub,
            email: payload.email,
            fullName: payload.name
        };
        this.currentUserSubject.next(user);
        }
    }

    private parseJwt(token: string): any {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(
        atob(base64).split('').map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)).join('')
        );
        return JSON.parse(jsonPayload);
    }
}
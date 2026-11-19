import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';

import { AuthService } from '../../Services/auth-service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  isRegisterMode = false;

  email = '';
  password = '';
  name = '';
  role = 'Customer';

  error = '';
  loading = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  selectRole(role: string): void {
    this.role = role;
    this.error = '';
  }

  toggleMode(): void {
    this.isRegisterMode = !this.isRegisterMode;
    this.error = '';
  }

  get hasMinLength(): boolean {
    return this.password.length >= 8;
  }

  get hasUppercase(): boolean {
    return /[A-Z]/.test(this.password);
  }

  get hasLowercase(): boolean {
    return /[a-z]/.test(this.password);
  }

  get hasDigit(): boolean {
    return /[0-9]/.test(this.password);
  }

  get hasSpecialChar(): boolean {
    return /[^a-zA-Z0-9]/.test(this.password);
  }

  get isPasswordValid(): boolean {
    return this.hasMinLength &&
      this.hasUppercase &&
      this.hasLowercase &&
      this.hasDigit &&
      this.hasSpecialChar;
  }

  onSubmit(): void {
    this.error = '';

    if (this.isRegisterMode && !this.isPasswordValid) {
      this.error = 'Please meet all password requirements.';
      return;
    }

    this.loading = true;

    if (this.isRegisterMode) {
      this.authService.register(
        this.email,
        this.password,
        this.name,
        this.role
      ).subscribe({
        next: () => this.router.navigate(['/dashboard']),
        error: (err) => {
          this.error = err.error?.message ||
            err.error?.errors?.[0] ||
            'Registration failed';
          this.loading = false;
        }
      });
    } else {
      this.authService.login(this.email, this.password, this.role).subscribe({
        next: () => this.router.navigate(['/dashboard']),
        error: (err) => {
          this.error = err.error?.message || 'Invalid email or password';
          this.loading = false;
        }
      });
    }
  }
}
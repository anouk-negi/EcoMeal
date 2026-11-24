import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PackageModel } from '../Models/package-model';
import { CreatePackageRequest } from '../Models/create-package-model';

@Injectable({
  providedIn: 'root',
})
export class PackageService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7273/api/packages';;

  getPackages(filters?: {
    businessId?: string;
    packageTypeId?: string;
    onlyAvailable?: boolean;
  }): Observable<PackageModel[]> {
    let params = new HttpParams();

    if (filters?.businessId) {
      params = params.set('businessId', filters.businessId);
    }
    if (filters?.packageTypeId) {
      params = params.set('packageTypeId', filters.packageTypeId);
    }
    if (filters?.onlyAvailable) {
      params = params.set('onlyAvailable', 'true');
    }

    return this.http.get<PackageModel[]>(this.apiUrl, { params });
  }

  getPackageById(id: string): Observable<PackageModel> {
    return this.http.get<PackageModel>(`${this.apiUrl}/${id}`);
  }

  createPackage(payload: CreatePackageRequest): Observable<PackageModel> {
    return this.http.post<PackageModel>(this.apiUrl, payload);
  }

  updatePackage(id: string, payload: CreatePackageRequest): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, payload);
  }

  deletePackage(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
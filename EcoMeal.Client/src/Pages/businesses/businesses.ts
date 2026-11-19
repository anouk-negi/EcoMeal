import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { BusinessService } from '../../Services/business-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-businesses',
  standalone: true,
  imports: [CommonModule],
  styleUrl: './businesses.css',
  templateUrl: './businesses.html',
})
export class Businesses implements OnInit {
  public businessService = inject(BusinessService);
  private cdr = inject(ChangeDetectorRef);
  public businesses: any[] = [];

  ngOnInit(): void {
    this.businessService.getBusinesses().subscribe({
      next: (data) => { 
        console.log('Data received from API:', data);
        this.businesses = data; 
        this.cdr.detectChanges();
      },
      error: (err) => { console.log('Error fetching businesses', err); }
    });
  }
}
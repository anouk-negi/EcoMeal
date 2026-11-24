import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PackageModel } from '../../Models/package-model';
import { PackageService } from '../../Services/package-service';

interface PackageTypeOption {
  id: string;
  name: string;
}

interface PackageGroup {
  typeId: string;
  typeName: string;
  items: PackageModel[];
}

@Component({
  selector: 'app-packages',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './packages.html',
  styleUrl: './packages.css',
})
export class PackagesPage implements OnInit {
  private readonly packageService = inject(PackageService);
  private readonly cdr = inject(ChangeDetectorRef);

  packages: PackageModel[] = [];
  packageTypes: PackageTypeOption[] = [];
  groupedPackages: PackageGroup[] = [];
  selectedTypeId = 'ALL';

  ngOnInit(): void {
    this.packageService.getPackages().subscribe({
      next: (data) => {
        this.packages = data ?? [];
        this.extractPackageTypes();
        this.rebuildGroups();
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Failed to load packages:', err);
        this.packages = [];
        this.groupedPackages = [];
        this.cdr.detectChanges();
      },
    });
  }

  selectType(typeId: string): void {
    this.selectedTypeId = typeId;
    this.rebuildGroups();
    this.cdr.detectChanges();
  }

  private extractPackageTypes(): void {
    const map = new Map<string, string>();

    for (const pkg of this.packages) {
      const id = pkg.packageTypeID || 'uncategorized';
      const name = pkg.packageTypeName || 'Other Packages';
      if (!map.has(id)) {
        map.set(id, name);
      }
    }

    this.packageTypes = Array.from(map.entries()).map(([id, name]) => ({ id, name }));
  }

  private rebuildGroups(): void {
    const filtered =
      this.selectedTypeId === 'ALL'
        ? this.packages
        : this.packages.filter((p) => (p.packageTypeID || 'uncategorized') === this.selectedTypeId);

    const groupsMap = new Map<string, PackageGroup>();

    for (const pkg of filtered) {
      const typeId = pkg.packageTypeID || 'uncategorized';
      const typeName = pkg.packageTypeName || 'Other Packages';

      if (!groupsMap.has(typeId)) {
        groupsMap.set(typeId, { typeId, typeName, items: [] });
      }
      groupsMap.get(typeId)!.items.push(pkg);
    }

    this.groupedPackages = Array.from(groupsMap.values());
  }
}
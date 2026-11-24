export interface PackageModel {
  id: string;
  businessID: string;
  businessName?: string | null;
  packageTypeID: string;
  packageTypeName?: string | null;
  name?: string | null;
  description?: string | null;
  price?: number | null;
  availableQuantitity?: number | null;
  pickupStart: string;
  pickupEnd: string;
  imageURL?: string | null;
}
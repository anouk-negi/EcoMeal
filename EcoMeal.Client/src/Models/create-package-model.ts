export interface CreatePackageRequest {
  businessID: string;
  packageTypeID: string;
  name: string;
  description?: string | null;
  price: number;
  availableQuantitity: number;
  pickupStart: string;
  pickupEnd: string;
  imageURL?: string | null;
}
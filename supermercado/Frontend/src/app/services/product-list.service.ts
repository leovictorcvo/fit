import { firstValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductListService {
  constructor(private http: HttpClient) { }

  async getProductsOfCategory(categoryId: string): Promise<Product[]> {
    return firstValueFrom(this.http.get<Product[]>(`https://localhost:44317/category/${categoryId}/products`));
  }
}

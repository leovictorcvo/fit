import { firstValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryListService {

  constructor(private http: HttpClient) { }

  async getCategories(): Promise<Category[]> {
    return firstValueFrom(this.http.get<Category[]>('https://localhost:44317/category'));
  }
}

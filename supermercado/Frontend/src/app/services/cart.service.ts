import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Cart } from './../models/cart';
import { ProductToAddToCart } from './../models/productToAddToCart';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) { }

  async getCart(cartId:string) : Promise<Cart>{
    return firstValueFrom(this.http.get<Cart>(`https://localhost:44317/cart/${cartId}`));
  }

  async addProductToCart(item:ProductToAddToCart): Promise<Cart> {
    return firstValueFrom(this.http.post<Cart>('https://localhost:44317/cart', item));
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';

import {CartService} from '../services/cart.service';

@Component({
  selector: 'app-cart-badge',
  templateUrl: './cart-badge.component.html',
  styleUrls: ['./cart-badge.component.sass']
})
export class CartBadgeComponent implements OnInit {
  cartId:string | null = null;
  cartItemsCount:number = 0;

  @Input() set cartSize(size: number) {
    this.cartItemsCount = size;
  }

  constructor(private service:CartService) { }

  ngOnInit(): void {
    this.cartId = localStorage.getItem('cartId');
    if (!this.cartId) {
      this.cartId = Guid.create().toString();
      localStorage.setItem('cartId', this.cartId);
    }
    this.updateCartItemsCount(this.cartId);
  }

  async updateCartItemsCount(cartId: string) {
    const { items } = await this.service.getCart(cartId);
    this.cartItemsCount = items.length;
  }

}

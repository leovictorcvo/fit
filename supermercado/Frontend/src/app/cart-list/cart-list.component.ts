import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';

import { ToastrService } from 'ngx-toastr';

import { CartItem } from './../models/cart';

import {CartService} from '../services/cart.service';

@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.sass']
})
export class CartListComponent implements OnInit {
  cart:CartItem[] = [];
  cartSize:number = 0;

  constructor(
    private service:CartService,
    private router:Router,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    const cartId:string | null = localStorage.getItem('cartId');

    if (cartId) {
      this.loadCart(cartId);
    } else {
      this.router.navigate(['/']);
    }
  }

  async loadCart(cartId:string) {
    const {items} = await this.service.getCart(cartId);
    this.cart = items;
    this.cartSize = items.length;
  }

  handleFinalize() {
    localStorage.setItem('cartId', Guid.create().toString());
    this.toastr.success('Compra finalizada com sucesso!', 'Obrigado', { timeOut: 2500});
    this.router.navigate(['/']);
  }
}

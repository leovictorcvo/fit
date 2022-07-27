import { ProductToAddToCart } from './../models/productToAddToCart';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';

import { Product } from '../models/product';

import { CartService } from '../services/cart.service';
import { ProductListService } from '../services/product-list.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.sass']
})
export class ProductListComponent {
  list: Product[] = [];
  formProduct: FormGroup = new FormGroup({
    product: new FormControl(''),
    quantity: new FormControl(0, [Validators.min(1)])
  });
  quantityInStock: number = 0;
  cartItemsCount: number = 0;

  constructor(
    private service: ProductListService,
    private cartService: CartService,
    private toastr: ToastrService
  ) { }

  onChangeProduct() {
    this.formProduct.controls['quantity'].setValue(0);
    let id: string = this.formProduct.controls['product'].value;
    let selectedProduct: Product | undefined = this.list.find(p => p.id == id);
    if (selectedProduct) {
      this.quantityInStock = selectedProduct.quantityInStock;
    }
  }

  async updateProductList(categoryId: string) {
    const data = await this.service.getProductsOfCategory(categoryId);
    this.list = data;
    if (this.list.length > 0) {
      let selectedProduct: Product = this.list[0];
      this.formProduct.controls['product'].setValue(selectedProduct.id);
      this.quantityInStock = selectedProduct.quantityInStock;
    }
  }

  async handleAddProductToCart() {
    const cartId = localStorage.getItem('cartId');
    const productId = this.formProduct.controls['product'].value as string;
    const quantity = this.formProduct.controls['quantity'].value as number;

    if (quantity > this.quantityInStock) {
      this.toastr.error('Produto sem estoque. Tente novamente mais tarde.', 'Atenção');
    } else {
      if (cartId) {
        const item: ProductToAddToCart = {
          cartId,
          productId,
          quantity
        };
        const { items } = await this.cartService.addProductToCart(item);
        this.cartItemsCount = items.length;
        this.updateProductQuantity(productId, quantity);
      }
    }
  }

  updateProductQuantity(productId: string, quantity: number) {
    const product = this.list.find(p => p.id === productId);
    if (product) {
      product.quantityInStock -= quantity;
      this.quantityInStock = product.quantityInStock;
    }
  }
}

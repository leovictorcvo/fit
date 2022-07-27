export interface CartItem {
  productId: string;
  productName: string;
  quantity: number;
}

export interface Cart {
  id: string;
  items: CartItem[];
}

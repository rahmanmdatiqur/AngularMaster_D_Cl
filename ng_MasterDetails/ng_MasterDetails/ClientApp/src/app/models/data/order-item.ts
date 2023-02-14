import { Product } from "./product";

export interface OrderItem {
    orderId?:number;
    productId?:number;
    quantity?:number;
    product?:Product;
}

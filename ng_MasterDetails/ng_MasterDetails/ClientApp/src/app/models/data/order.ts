import { Status } from "../shared/app-constants";
import { OrderItem } from "./order-item";

export interface Order {
    orderId?:number;
    orderDate?:Date;
    deliveryDate?:Date;
    status?:Status;
    customerId?:number;
    orderItems?:OrderItem[];
}

import { Customer } from "../data/customer";
import { OrderItem } from "../data/order-item";
import { Status } from "../shared/app-constants";

export interface OrderAndOrderItemViewModel {
    orderId?:number;
    orderDate?:Date;
    deliveryDate?:Date;
    status?:Status;
    customerId?:number;
    orderItems?:OrderItem[];
    customer?:Customer;
}

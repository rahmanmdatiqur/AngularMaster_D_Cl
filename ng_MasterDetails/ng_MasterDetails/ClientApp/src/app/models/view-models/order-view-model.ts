import { Status } from "../shared/app-constants";

export interface OrderViewModel {
    orderId?:number;
    orderDate?:Date;
    deliveryDate?:Date;
    status?:Status;
    customerId?:number;
    customerName?:string;
    orderValue?:number;
}

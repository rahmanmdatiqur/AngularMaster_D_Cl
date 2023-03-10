import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { Customer } from 'src/app/models/data/customer';
import { Order } from 'src/app/models/data/order';
import { OrderItem } from 'src/app/models/data/order-item';
import { Product } from 'src/app/models/data/product';
import { Status } from 'src/app/models/shared/app-constants';
import { NotifyService } from 'src/app/services/common/notify.service';
import { CustomerService } from 'src/app/services/data/customer.service';
import { OrderService } from 'src/app/services/data/order.service';
import { ProductService } from 'src/app/services/data/product.service';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent implements OnInit {
  order:Order = {customerId:undefined, orderDate:undefined, deliveryDate:undefined, status:undefined}
  customers:Customer[] = [];
  products:Product[] =[];
  //
  statusOptions:{label:string, value:number}[] =[];
  //
  orderForm:FormGroup= new FormGroup({
    customerID: new FormControl(undefined, Validators.required),
    orderDate: new FormControl(undefined, Validators.required),
    deliveryDate: new FormControl(undefined),
    status: new FormControl(undefined, Validators.required),
    orderItems: new FormArray([])
  })
  constructor(
    private orderService: OrderService,
    private productService:ProductService,
    private customerService:CustomerService,
    private notifyService:NotifyService,
    private activatedRout:ActivatedRoute
  ) { }
  get orderItemsFormArray(){
    return this.orderForm.controls["orderItems"] as FormArray;
  }
  addItem(oi?:OrderItem){
    if(oi){
      this.orderItemsFormArray.push(new FormGroup({
        productID: new FormControl(oi.productId, Validators.required),
        quantity:new FormControl(oi.quantity, Validators.required)
      }))
    }
    else
    {
      this.orderItemsFormArray.push(new FormGroup({
        productID: new FormControl(undefined, Validators.required),
        quantity:new FormControl(undefined, Validators.required)
      }));
    }
    
  }
  removeItem(index:number){
    if(this.orderItemsFormArray.controls.length> 1)
      this.orderItemsFormArray.removeAt(index);
  }
  save(){
    if(this.orderForm.invalid) return;
    //console.log(this.orderForm.value);
    Object.assign(this.order, this.orderForm.value);
    console.log(this.order);
    this.orderService.update(this.order)
    .subscribe({
      next:r=>{
        this.notifyService.message("Data saved", 'DISMISS');
      },
      error:err=>{
        this.notifyService.message("Failed to load products", 'DISMISS');
        throwError(()=>err);
      }
    })
  }
  ngOnInit(): void {
    let id:number = this.activatedRout.snapshot.params['id'];
    this.orderService.getWithItems(id)
    .subscribe({
      next:r=>{
        this.order = r;
        console.log(this.order);
        this.orderForm.patchValue(this.order);
        this.order.orderItems?.forEach(oi=>{
          this.addItem(oi);
        });
        console.log(this.orderForm.value)
      },
      error:err=>{
        this.notifyService.message("Falied to load order", "DISMISS");
        throwError(()=>err);
      }
    });
    this.customerService.get()
    .subscribe({
      next: r=>{
        this.customers = r;
      },
      error: err=>{
        this.notifyService.message("Failed to load customers", 'DISMISS');
      }
    });
    this.productService.get()
    .subscribe({
      next: r=>{
        this.products = r;
      },
      error: err=>{
        this.notifyService.message("Failed to load products", 'DISMISS');
      }
    });
    Object.keys(Status).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    ).forEach((v: any, i) => {
      this.statusOptions.push({label: v, value:<any> Status[v]});
    });
  }
}

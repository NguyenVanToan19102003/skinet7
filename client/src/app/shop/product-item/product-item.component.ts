import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { Basket } from 'src/app/shared/models/basket';
import { Product } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent  {

  @Input() product? : Product;

  constructor(private basket : BasketService){}

  addItemTobasket(){
    this.product && this.basket.addItemToBasket(this.product);
  }

}

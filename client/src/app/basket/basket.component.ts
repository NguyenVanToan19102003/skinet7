import { Component } from '@angular/core';
import { BasketService } from './basket.service';
import { BasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent {

  constructor(public baketSevice : BasketService){}

  incrementQuantity(item : BasketItem){
    this.baketSevice.addItemToBasket(item);
  }

  removeItem(id : number){
    this.baketSevice.removeItemFromBasket(id);
  }

  removeAllItem(id : number , quantity : number){
    this.baketSevice.removeItemFromBasket(id , quantity);
  }
}

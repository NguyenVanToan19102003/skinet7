import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  constructor(private basketService : BasketService , private accountService : AccountService){

  }
  ngOnInit(): void {
    this.loadBasketId();
    this.loadCurrentUser();
  }


  loadBasketId(){
    const basketId = localStorage.getItem('basket_id');
    if(basketId) this.basketService.getBasket(basketId);
  }

  loadCurrentUser(){
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe();
  }

}

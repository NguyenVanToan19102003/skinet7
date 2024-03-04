import { Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search') searchTerm? : ElementRef;
  products : Product[] = [];
  brands : Brand[] = [];
  types : Type[] = [];

  shopParams = new ShopParams();
  sortOptions = [
      {name : 'Alphabetical' , value : 'name'},
      {name : 'Price : Low to high' , value : 'priceAsc'},
      {name : 'Price : High to low' , value : 'priceDesc'},
  ]
  totalCount = 0;

  constructor(private shopService : ShopService) {

  }
  ngOnInit(): void {

    this.getproducts();
    this.getBrands();
    this.getTypes();

  }

  getproducts(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next : res => {
        this.products = res.data;
        this.shopParams.pageNumber = res.pageIndex;
        this.shopParams.pageSize = res.pageSize;
        this.totalCount = res.count;
      },
      error : err => console.log("Lỗi Không Load Được SP !" , err),
    })
  }

  getBrands(){
    this.shopService.getBrands().subscribe({
      next : res => this.brands = [{id : 0 , name : 'All '}, ...res],
      error : err => console.log("Lỗi Không Load Được Brands !" , err),
    })
  }

  getTypes(){
    this.shopService.getBrands().subscribe({
      next : res => this.types = [{id : 0 , name : 'All '}, ...res],
      error : err => console.log("Lỗi Không Load Được Types !" , err),
    })
  }

  onBrandSelected(brandId : number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }

  onTypeSelected(typeId : number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }

  onSortSelected(event : any){
    this.shopParams.sort = event.target.value;
    this.getproducts();
  }

  onPageChange(event : any) {

    if(this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getproducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }

  onReset(){
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getproducts();
  }
}

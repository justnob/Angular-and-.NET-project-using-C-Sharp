import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/modles/pagination';
import { Product } from '../shared/modles/product';
import { Type } from '../shared/modles/type';
import { Brand } from '../shared/modles/brand';
import { ShopParams } from '../shared/modles/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams)
  {
    let params = new HttpParams();

    if(shopParams.brandId > 0) params = params.append('brandId', shopParams.brandId);
    if(shopParams.typeId > 0) params = params.append('typeId', shopParams.typeId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if (shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', {params});
  }

  getProduct(id: number )
  {
    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }

  getBrands()
  {
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
  }
  getTypes()
  {
    return this.http.get<Type[]>(this.baseUrl + 'products/types');
  }
}
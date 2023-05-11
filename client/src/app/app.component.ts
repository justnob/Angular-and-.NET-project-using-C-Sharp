import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './modles/product';
import { Pagination } from './modles/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Light';
  products: Product[] = [];

  constructor(private http: HttpClient)
  {

  }
  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products').subscribe({
      next: response => this.products = response.data, //waht to do next
      error: error => console.log(error),//what to do if error occure
      complete: () => {
        console.log('request completed');
        console.log('extra ststement');
      }
    })
  }
}

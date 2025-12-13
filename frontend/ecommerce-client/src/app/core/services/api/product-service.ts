import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { environment } from '../../../../environments/environment';

import { Product } from '../../models/product.model';
import { ProductUpsert } from '../../models/product-upsert.model';

@Injectable({providedIn: 'root'})
export class ProductService {
  private http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Product`;

  getAll(): Promise<Product[]> {
    return lastValueFrom(
      this.http.get<Product[]>(this.apiUrl)
    );
  }

  getById(id:number): Promise<Product>{
    return lastValueFrom(
      this.http.get<Product>(`${this.apiUrl}/${id}`)
    );
  }

  create(model: ProductUpsert): Promise<string>{
    return lastValueFrom(
      this.http.post(this.apiUrl,model,{
        responseType: "text",
      })
    );
  }

  update(model: ProductUpsert): Promise<string>{
    return lastValueFrom(
      this.http.put(this.apiUrl,model,{
        responseType: "text",
      })
    );
  }

  remove(id: number): Promise<string>{
    return lastValueFrom(
      this.http.delete(`${this.apiUrl}/${id}`, {
        responseType: 'text',
      })
    );
  }
  
}

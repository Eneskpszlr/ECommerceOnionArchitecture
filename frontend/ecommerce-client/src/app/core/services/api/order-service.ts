import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { environment } from '../../../../environments/environment';

import { Order } from '../../models/order.model';
import { OrderUpsert } from '../../models/order-upsert.model';

@Injectable({providedIn: 'root'})
export class OrderService {
  private http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Order`;

  getAll(): Promise<Order[]> {
    return lastValueFrom(
      this.http.get<Order[]>(this.apiUrl)
    );
  }

  getById(id:number): Promise<Order>{
    return lastValueFrom(
      this.http.get<Order>(`${this.apiUrl}/${id}`)
    );
  }

  create(model: OrderUpsert): Promise<string>{
    return lastValueFrom(
      this.http.post(this.apiUrl,model,{
        responseType: "text",
      })
    );
  }

  update(model: OrderUpsert): Promise<string>{
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

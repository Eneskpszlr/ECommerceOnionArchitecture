import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { environment } from '../../../../environments/environment';

import { AppUser } from '../../models/app-user.model';
import { AppUserUpsert } from '../../models/app-user-upsert.model';

@Injectable({providedIn: 'root'})
export class AppUserService {
  private http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/AppUser`;

  getAll(): Promise<AppUser[]> {
    return lastValueFrom(
      this.http.get<AppUser[]>(this.apiUrl)
    );
  }

  getById(id:number): Promise<AppUser>{
    return lastValueFrom(
      this.http.get<AppUser>(`${this.apiUrl}/${id}`)
    );
  }

  create(model: AppUserUpsert): Promise<string>{
    return lastValueFrom(
      this.http.post(this.apiUrl,model,{
        responseType: "text",
      })
    );
  }

  update(model: AppUserUpsert): Promise<string>{
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

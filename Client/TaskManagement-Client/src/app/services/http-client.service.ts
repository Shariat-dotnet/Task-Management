import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {
  constructor(private client: HttpClient) {
   }


  get(url: string): Observable<object> {  
    
    return this.client.get(url);
  }

  post(url: string, body: object) {
    return this.client.post(url, body);
  }
   put(url: string, body: object) {
    return this.client.put(url, body);
   }
   delete(url: string) {
    return this.client.delete(url);
  }
}

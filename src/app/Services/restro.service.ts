import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Restaurant } from '../Models/restaurant';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestroService {

  url: string = "  http://localhost:3000/restaurant";
 
  selectedItems : Restaurant[] = [];
  constructor(private http: HttpClient) {}

  public getAllMenu() : Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(this.url);
  }

 public addToCheckout(resource : Restaurant)  {
 
    return this.selectedItems.push(resource);
 }

 public GetCheckout() : Restaurant[] {
 
  return this.selectedItems;
}

}

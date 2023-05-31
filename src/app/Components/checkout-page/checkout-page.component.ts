import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/Models/restaurant';
import { RestroService } from 'src/app/Services/restro.service';

@Component({
  selector: 'app-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrls: ['./checkout-page.component.css']
})
export class CheckoutPageComponent  {
  selectedItem: Restaurant[] = [];
  constructor(private restroService: RestroService) {}
total : number = 0;

  // ngOnInit(): void {
  //   this.restroService.GetCheckout().subscribe((data : Restaurant[]) => {

  //     return this.selectedItem = data;

  //   });

   
  // }

  getTotalPrice(): number {

    return this.selectedItem.reduce((total, item) => total = total+  item.Price, 0);

  }

}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { CheckoutPageComponent } from './Components/checkout-page/checkout-page.component';
import { NavResComponent } from './Components/nav-res/nav-res.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    CheckoutPageComponent,
    NavResComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

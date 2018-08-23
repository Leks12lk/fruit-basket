import { HttpService } from './services/http.service';
import { FruitBasketModule } from './fruit-basket/fruit-basket.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './app.component';



@NgModule({
  declarations: [
    AppComponent    
],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FruitBasketModule
  ],
  providers: [
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

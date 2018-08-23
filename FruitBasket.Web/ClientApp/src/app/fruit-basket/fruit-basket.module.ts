import { FruitBasketService } from './services/fruit-basket.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FruitBasketComponent } from './fruit-basket.component';
import { PlayerFormComponent } from './player-form/player-form.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  declarations: [
    FruitBasketComponent,
    PlayerFormComponent
],
providers: [
  FruitBasketService
],
  exports: [
    FruitBasketComponent
  ]
})
export class FruitBasketModule { }

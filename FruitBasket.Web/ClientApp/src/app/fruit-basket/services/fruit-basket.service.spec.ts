/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FruitBasketService } from './fruit-basket.service';

describe('Service: FruitBasket', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FruitBasketService]
    });
  });

  it('should ...', inject([FruitBasketService], (service: FruitBasketService) => {
    expect(service).toBeTruthy();
  }));
});

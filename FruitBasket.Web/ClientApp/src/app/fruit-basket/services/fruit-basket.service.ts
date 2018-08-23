import { StartingGame } from '../models/starting-game';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Rx';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

declare var window: any;

@Injectable()
export class FruitBasketService {
    appPath:string;
    

constructor(private http: HttpClient) {
    if(window.serverSideSettings){
        this.appPath = window.serverSideSettings.appPath;
    }
 }

getRealBasketWeight() {
    return this.http.get('/FruitBasket/GetRealBasketWeight');
}

startGame(playersModel: StartingGame) {
    return this.http.post('/FruitBasket/StartGame', playersModel);
}


private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error.message}`);
    }
    
    // return an empty observable
    return Observable.empty();
};

}

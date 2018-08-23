import { Injectable } from '@angular/core';
import { RequestOptions, Headers } from '@angular/http';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx'; 
import { catchError } from "rxjs/operators";




declare var window: any;

@Injectable()
export class HttpService {
	
	public error: any;
	constructor(private http: HttpClient) {
		
	}

	get(path:string): Observable<any> {
		return this.http.get(path)			
			.pipe(
				catchError((err: HttpErrorResponse) => {
					return this.handleError.call(this, err);
				})
			);
	}

	post(path: string, data: any, options: any = null) {
		var headers = new Headers({ 'Content-Type': 'application/json;  charset=utf-8 ' });
		if (!options) {
			options = new RequestOptions({ headers: headers });
		}
		return this.http.post(path, data)
		.pipe(
			catchError((err: HttpErrorResponse) => {
				return this.handleError.call(this, err);
			})
		);
	}

	delete(path: string): Observable<any> {
		return this.http.delete(path)
			.pipe(
				catchError((err: HttpErrorResponse) => {
					return this.handleError.call(this, err);
				})
			);
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

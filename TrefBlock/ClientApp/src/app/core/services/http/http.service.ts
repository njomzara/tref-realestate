import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ErrorService } from '../error/error.service';
import { ApiEndPoints, ApiMethod } from '../../const';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  /**
   * Constructor
   * @param baseUrl - App base URL
   * @param http    - HTTP Client
   * @param _error
   */
  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient,  private _error: ErrorService)
  {

  }

  /**
   * Generic HTTP request function
   * @param api
   * @param method
   * @param data
   */
  requestCall(api: ApiEndPoints, method: ApiMethod, data?: any) {

    let response;

    switch (method) {
      case ApiMethod.GET:
        response = this.http.get(this.baseUrl + api + data, { headers: new HttpHeaders({ timeout: `${120000}` }) })
          .pipe(catchError(async (response) => this.hadnleError(response, this)));
        break;
      case ApiMethod.POST:
        response = this.http.post(this.baseUrl + api, data)
          .pipe(catchError(async (response) => this.hadnleError(response, this)));
        break;
      case ApiMethod.PUT:
        response = this.http.put(this.baseUrl + api, data)
          .pipe(catchError(async (response) => this.hadnleError(response, this)));
        break;
      case ApiMethod.DELETE:
        response = this.http.delete(this.baseUrl + api)
          .pipe(catchError(async (response) => this.hadnleError(response, this)));
        break;
      default:
        break
    }

    return response;
  }
  /**
   * This function is used to handle the error of a api call
   * @param error
   * @param self
   */
  hadnleError(response: HttpErrorResponse, self: HttpService) {

    //if (response.error instanceof ErrorEvent) {
      this._error.whichError(response.status, response.error);
      return throwError({ error: response.error, status: response.status });
   
    //}

  }

}

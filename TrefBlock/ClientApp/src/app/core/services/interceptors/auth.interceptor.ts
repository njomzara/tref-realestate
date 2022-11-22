import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

   constructor(private storage: StorageService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (this.storage.getToken() != null) {
      const clonedRequest = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + this.storage.getToken())
      });
      return next.handle(clonedRequest);
    } else {
      return next.handle(req.clone());
    }


  }

}

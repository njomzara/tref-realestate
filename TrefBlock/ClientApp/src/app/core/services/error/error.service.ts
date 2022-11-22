import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { StorageService } from '../storage/storage.service';

export enum CustomErrorCodes {
  UN_KNOWN = 0
}

export enum RedirectionCode {

}

export enum RedirectionCode {
  HTTP_300_MULTIPLE_CHOICES = 300
}

export enum ServerError {
  HTTP_500_INTERNAL_SERVER_ERROR = 500
}

export enum SuccessCodes {
  HTTP_200_OK = 200
}

export enum ClientError {
  HTTP_400_BAD_REQUEST = 400,
  HTTP_401_UNAUTHENTICATED = 401,
  HTTP_403_UNAUTHORIZED = 403,
  HTTP_405_METHOD_NOT_ALLOWED = 405,
}

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(private toastr: ToastrService, private router: Router, private storage: StorageService) { }

  /**
   * Handles particular HTTP status, toasting message and title
   * inside respose.error object
   * 
   * @param responseStatus
   * @param error
   */
  whichError(responseStatus: number, error: any) {
    switch (responseStatus) {
      case CustomErrorCodes.UN_KNOWN:
        this.toastr.error(error.message);
        break;
      case ClientError.HTTP_400_BAD_REQUEST:
        this.toastr.error(error.text, error.title);
        break;
      case ClientError.HTTP_405_METHOD_NOT_ALLOWED:
        this.toastr.error(error.messageText, error.messageTitle);
        break;
      case ClientError.HTTP_401_UNAUTHENTICATED:
        if (error) {
          this.toastr.error(error.messageText, error.messageTitle);
        }
        this.storage.removeToken();
        this.router.navigate(['/auth/login']); 
        break;
      case ClientError.HTTP_403_UNAUTHORIZED:
        this.router.navigate(['/forbidden']);
        break;
      default:
        this.toastr.error('Unknown Error Code');
    }
  }

  /**
   * Send success notification
   * @param notificationCode
   * @param notification
   */
  userNotification(notificationCode: number, notification: string) {
    switch (notificationCode) {
      case SuccessCodes.HTTP_200_OK:
        this.toastr.success(notification);
        break;
      default:
        alert('Unknown Success Action');
    }
  }
}

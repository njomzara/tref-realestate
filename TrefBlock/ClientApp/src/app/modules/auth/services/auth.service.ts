import { Injectable } from '@angular/core';
import { HttpService } from '../../../core/services/http/http.service';
import { ApiMethod, ApiEndPoints } from '../../../core/const';
import { StorageService } from '../../../core/services/storage/storage.service';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { User } from '../../../core/models/model-main';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    private user!: User;
    private _loginStatusSubject = new Subject<boolean>();

    loginStatus = this._loginStatusSubject.asObservable();

    constructor(
      private router: Router,
      private http: HttpService,
      private storage: StorageService
    )
    {
    }

    /**
     * App login User
     * @param user = User model
     */
  logInUser(user: User): Promise<boolean> {
      return this.http.requestCall(ApiEndPoints.UserLogIn, ApiMethod.POST, user)!
        .toPromise()
        .then((response: any) => {
          this.storage.saveToken(response.token, response.user);
          this.user = response.user;
          this._loginStatusSubject.next(true);
          return true;
        }).catch(e => {
          return false;
        });
    }

    /**
     * Check if user is logged in (token will be valid)
     **/
    isLoggedIn(): Promise<boolean> {
      return this.getUser()
        .toPromise()
        .then(response =>
        {

          if (this.user === undefined) {
            this.user = response.user;
          }

          this._loginStatusSubject.next(true);

          return true;
        })
        .catch(e => {
          this._loginStatusSubject.next(false);
          return false;
        });
    }

    /**
     * App logout User
     * */
    logOutUser() {
      this.storage.removeToken();
      this.user = new User();
      this._loginStatusSubject.next(false);
      this.router.navigateByUrl('/auth/login');
    }

    /**
     * Notify subscribers that user is not logged in
     * */
    tokenExpired(): void {
      this._loginStatusSubject.next(false);
    }

    /**
     * CHECK USER - Get User details by JWT - if token expired returns HTTP401 and
     * HTTP service will redirect to login page
     * */
    getUser(): Observable<any> {
      return this.http.requestCall(ApiEndPoints.UserGet, ApiMethod.GET, "")!   
    }

    _getUser(): User {
      return this.user;
    }


  tokenExists(): boolean {
    if (this.storage.getToken() == null) {
      return false
    } else {
      return true
    }
  }
  tokenValid(): Promise<boolean> {

    return this.getUser().toPromise().then(() => {
      return true;
    }).catch(e => {
      return false;
    });

  }

}

import { Injectable } from '@angular/core';
import { UtilService } from '../util/util.service';
import { Router } from '@angular/router';
import { User } from '../../models/model-main';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private _util: UtilService, private _router: Router)
  {
  }

  saveToken(token: string, user: User): void {
    localStorage.setItem("nbtkn", token);
    localStorage.setItem("nbtkn-u", JSON.stringify(user));
  }

  getToken(): string | null {
    return localStorage.getItem("nbtkn");
  }

  getLoggedInUser(): User {
    return JSON.parse(this.getToken()!) as User;
  }

  removeToken(): void {
    localStorage.removeItem("nbtkn");
    localStorage.removeItem("nbtkn-u");
    localStorage.removeItem("vdm-config");
  }

  setLocalObject(key: string, value: any): boolean {
    try {
      localStorage.setItem(key, this._util.encrypt(JSON.stringify(value)));
      return true;
    } catch (e) {
      return false;
    }
  }

  getLocalObject(key: string): any {
    if (localStorage.getItem(key)) {
      return JSON.parse(this._util.decrypt(localStorage.getItem(key)!));
    } else {
      return null
    }
  }

}

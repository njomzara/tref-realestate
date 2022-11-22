import { Injectable } from '@angular/core';
import { AES, enc } from 'crypto-js'

@Injectable({
  providedIn: 'root'
})
export class UtilService {

  encryptKey: string = "key";

  constructor()
  { }

  /**
   * Decrypt with CryptoJS
   * @param data
   * @param key
   */
  decrypt(data: string, key: string = this.encryptKey): string {
    return AES.decrypt(data, key).toString(enc.Utf8);
  }

  /**
   * Encrypt with CryptoJS
   * @param data
   * @param key
   */
  encrypt(data: string, key: string = this.encryptKey): string {
    return AES.encrypt(data, key).toString();
  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../../../../core/services/storage/storage.service';
import { trigger, state, style, animate, transition, stagger, query, animateChild, group } from '@angular/animations';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../../core/models/model-main';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
  animations: [
    trigger('card', [
      transition(':enter', [
        style({ transform: 'translateX(100%)', opacity: 0 }),
        animate('200ms ease-in',
          style({ transform: 'translateX(0)', opacity: 1 })
        ),
      ]),
      transition(':leave', [
        animate('200ms ease-out',
          style({ transform: 'translateX(100%)', opacity: 0 })
        ),
      ])
    ])
  ],
})
export class LogInComponent implements OnInit {

  public user: User;
  public logging: boolean = false;

  constructor
    (
      private router: Router,
      private auth: AuthService,
      private storage: StorageService
    )
  {
    this.user = {} as User;
  }

  ngOnInit(): void {
    /**
     * Pervent logged in user to visit login page.
     * If token exists, send getUser request to validate if
     * token did not expire. Returns 401 if expired
     * */
    if (this.auth.tokenExists()) { // token should be deleted if redirected from 401 response status
      // Check if token is valid before redirect
      this.router.navigateByUrl('/dashboard');
    } else {
      this.auth.tokenExpired(); // Will raise login status change for subscription notification
    }
  }

  /**
   * User log in action, save token and redirects to home page
   * or bring back the login form and show toastr
   * */
  onLogIn(): void {
    this.logging = !this.logging;

    // Auth service log in User
    this.auth.logInUser(this.user)
      .then(loggedIn => {
        if (loggedIn) {
          this.router.navigateByUrl('/dashboard');
        } else {
          this.logging = !this.logging;
        }
    });
  }

  onLogOut(): void {    
    this.auth.logOutUser
  }

}




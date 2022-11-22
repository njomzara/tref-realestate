import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LogInComponent } from './pages/log-in/log-in.component';
import { SharedModule } from '../../core/modules/shared.module';
import { SharedAppModule } from '../../core/modules/shared-app.module';

@NgModule({
  declarations: [
    LogInComponent
  ],
  imports: [
    SharedModule,
    SharedAppModule,
    RouterModule.forChild([
      {
        path: 'auth',
        children: [
          {
            path: 'login',
            component: LogInComponent
          },
          {
            path: '',
             redirectTo: 'login', pathMatch: 'full'            
          }
        ]
      }
    ])
  ]
})
export class AuthModule { }

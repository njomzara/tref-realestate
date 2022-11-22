import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PageForbiddenComponent } from './modules/page-forbidden/page-forbidden.component';
import { PageNotFoundComponent } from './modules/page-not-found/page-not-found.component';

@NgModule({
  declarations: [

  ],
  imports: [
    RouterModule.forRoot([
      
      {
        path: '',
        redirectTo: 'auth',
        pathMatch: 'full'
      },
      {
        path: 'forbidden',
        component: PageForbiddenComponent
      },
      {
        path: '**',
        component: PageNotFoundComponent
      }

      /* Lazy Load Example
      {
      path: 'employee',
      loadChildren: () => import('./modules/employee/employee.module').then(m => m.EmployeeModule),
      canActivate: [AuthGuard]
      },
      */
    ], { relativeLinkResolution: 'legacy' })
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './core/app-routing.module';
import { SharedAppModule } from './core/modules/shared-app.module';
import { SharedModule } from './core/modules/shared.module';
import { AuthModule } from './modules/auth/auth.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    GooglePlaceModule,
    BrowserModule,
    HttpClientModule,
    ToastrModule.forRoot({ positionClass: 'toast-top-center' }),
    SharedModule,
    SharedAppModule,
    //AuthModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

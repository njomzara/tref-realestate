import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule
  ],
  exports: [

    // Angular modules
    CommonModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,    
    MaterialModule,
    
    // 3rd Party modules - after Angular

  ]
})
export class SharedModule { }

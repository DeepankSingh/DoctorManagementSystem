import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AddFormComponent } from './components/add-form/add-form.component';

@NgModule({
  declarations: [
    AppComponent,
    DoctorListComponent,
    AddFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})

export class AppModule { }

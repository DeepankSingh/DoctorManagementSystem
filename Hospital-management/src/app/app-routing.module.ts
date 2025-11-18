import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { AddFormComponent } from './components/add-form/add-form.component';

const routes: Routes = [
{ path: 'add-registration', component: AddFormComponent },
{ path: 'add-registration/:id', component: AddFormComponent },
  { path: 'doctors', component: DoctorListComponent },

  // default route → redirect / to /doctors
  { path: '', redirectTo: 'doctors', pathMatch: 'full' },

  // wildcard route → redirect any invalid URL
  { path: '**', redirectTo: 'doctors' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

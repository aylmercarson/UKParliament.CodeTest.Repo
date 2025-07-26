import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonManagementComponent } from './components/person.management/person.management.component';

const routes: Routes = [
    { path: '', component: PersonManagementComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

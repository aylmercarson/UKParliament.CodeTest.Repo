import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PersonManagementComponent } from './components/person.management/person.management.component';

const routes: Routes = [
    { path: 'test', component: HomeComponent, pathMatch: 'full' },
    { path: '', component: PersonManagementComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
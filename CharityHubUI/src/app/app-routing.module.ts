import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'charity/organizations', pathMatch: 'full' },
  { path: 'user', loadChildren: 'app/home/home.module#HomeModule' },
  { path: 'charity', loadChildren: 'app/charity/charity.module#CharityModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

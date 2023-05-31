import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddEditPetComponent, PetViewComponent } from './components';
import { PetsListComponent } from './components/pets-list/pets-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'petlist', pathMatch: 'full' }
  ,
  { path: 'petlist', component: PetsListComponent }
  ,
  { path: 'addpet', component: AddEditPetComponent }
  ,
  { path: 'viewpet/:id', component: PetViewComponent }
  ,
  { path: 'editpet/:id', component: AddEditPetComponent }
  ,
  { path: '**', redirectTo: 'petlist', pathMatch: 'prefix' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

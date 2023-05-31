import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddEditPetComponent, PetsListComponent, PetViewComponent } from './components';
import { SharedModule } from './shared';

@NgModule({
  declarations: [
    AppComponent,
    AddEditPetComponent,
    PetsListComponent,
    PetViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

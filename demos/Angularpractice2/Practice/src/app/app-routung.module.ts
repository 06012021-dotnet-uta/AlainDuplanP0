import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerlistComponent } from './playerlist/playerlist.component';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'playerlist', component: PlayerlistComponent},
  {path: 'landing', component: LandingComponent},
  {path: '', redirectTo:'**', pathMatch:'full'},
  {path: '**', component: HomeComponent}
]


@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports : [RouterModule]
})
export class AppRoutungModule { }

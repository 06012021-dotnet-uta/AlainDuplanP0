import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerlistComponent } from './playerlist/playerlist.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'playerlist', component: PlayerlistComponent}
]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports : [RouterModule]
})
export class AppRoutungModule { }

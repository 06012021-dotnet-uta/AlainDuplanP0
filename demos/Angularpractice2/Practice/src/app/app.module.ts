import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LandingComponent } from './landing/landing.component';
import { FormsModule } from '@angular/forms';
import { ChildComponent } from './child/child.component';
import { AppRoutungModule } from './app-routung.module';
import { PlayerlistComponent } from './playerlist/playerlist.component';
//import { StringifyOptions } from 'querystring';

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    ChildComponent,
    PlayerlistComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutungModule,
    //StringifyOptions
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

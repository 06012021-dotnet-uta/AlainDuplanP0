import { Component, OnInit } from '@angular/core';
import { Player } from '../player';

@Component({
  selector: 'app-playerlist',
  templateUrl: './playerlist.component.html',
  styleUrls: ['./playerlist.component.css']
})
export class PlayerlistComponent implements OnInit {

  playerArr?: Player[];
  chosen?:Player;
  constructor() { }

  ngOnInit(): void {
    this.playerArr = [
      { personid: 123, fname: 'BO', lname: 's5s', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 420 },
      { personid: 143, fname: 'NO', lname: 'sss', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 4200 },
      { personid: 163, fname: 'LO', lname: 'qqw', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 420 },
      { personid: 153, fname: 'SO', lname: 'qs', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 4000 },
      { personid: 173, fname: 'SO', lname: 'qww', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 2000 },
      { personid: 183, fname: 'Ldp', lname: 'wwq', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 420800 },
      { personid: 193, fname: 'PS', lname: 'qww', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 452000 },


    ]
  }

  playerdetails(personid:number):void{
    this.chosen = this.playerArr?.find(x => x.personid == personid);
  }

  SortByAgeFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.myage > b.myage) ? 1 : -1);
  }

  SortByFnameFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.fname.toLowerCase() > b.fname.toLowerCase()) ? 1 : -1);
  }

  SortByCountryFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.mycountry.toLowerCase() > b.mycountry.toLowerCase()) ? 1 : -1);
  }

  SortByPersonIdFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.personid > b.personid) ? 1 : -1);
  }

}

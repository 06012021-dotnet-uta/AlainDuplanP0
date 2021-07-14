import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Player } from './player';

@Injectable({
  providedIn: 'root'
})
export class PlayerserviceService {

  constructor() { }

  GetPlayerlist(): Observable<Player[]>{
    return of(
      [
      { personid: 123, fname: 'Matt', lname: 'Moore', mycountry: 'USA', street: '123 main', state: 'Arizona', city: 'Alvarado', myage: 49 },
         { personid: 1337, fname: 'malia', lname: 'labor', mycountry: 'America', street: '123 main', state: 'Arizona', city: 'Tucson', myage: 28 },
        { personid: 4689, fname: 'Smith', lname: 'Fox', mycountry: 'India', street: '34 NW', state: 'Florida', city: 'Orlando', myage: 34 },
         { personid: 777, fname: 'lucky', lname: 'playguy', mycountry: 'USA', street: '1 penobscot bay', state: 'Maine', city: 'Stockton', myage: 55 },
         { personid: 120, fname: 'Dostoevsky ', lname: 'Fyodor', mycountry: 'Russia', street: '123 Ocean Ave', state: 'Texas', city: 'Austin', myage: 35 },
         { personid: 12, fname: 'John', lname: 'Doe', mycountry: 'United States', street: '123 hestnut lane', state: 'Ohio', city: 'Springfield', myage: 40 },
        { personid: 420, fname: 'Snoop', lname: 'Dog', mycountry: 'America', street: '404 Main Street', state: 'New York', city: 'The Bronx', myage: 49 },
         { personid: 56, fname: 'Luffy', lname: 'Monkey D.', mycountry: 'Brazil', street: '1000 Sunny', state: 'New World', city: 'Dressrosa', myage: 19 }
       ]);
  }
}

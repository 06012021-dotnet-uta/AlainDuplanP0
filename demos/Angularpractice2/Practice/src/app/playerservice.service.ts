import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Player } from './player';

@Injectable({
  providedIn: 'root'
})
export class PlayerserviceService {
  url: string = 'https://localhost:5001/api/RpsGame/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  GetPlayerlist(): Observable<Player[]> {
    // this is where your httpclient GET, POST, etc methods will be
    // return of(
    //   [
    //     { personid: 123, fname: 'Matt', lname: 'Moore', mycountry: 'USA', street: '123 main', state: 'Arizona', city: 'Alvarado', myage: 49 },
    //     { personid: 1337, fname: 'malia', lname: 'labor', mycountry: 'America', street: '123 main', state: 'Arizona', city: 'Tucson', myage: 28 },
    //     { personid: 4689, fname: 'Smith', lname: 'Fox', mycountry: 'India', street: '34 NW', state: 'Florida', city: 'Orlando', myage: 34 },
    //     { personid: 777, fname: 'lucky', lname: 'playguy', mycountry: 'USA', street: '1 penobscot bay', state: 'Maine', city: 'Stockton', myage: 55 },
    //     { personid: 120, fname: 'Dostoevsky ', lname: 'Fyodor', mycountry: 'Russia', street: '123 Ocean Ave', state: 'Texas', city: 'Austin', myage: 35 },
    //     { personid: 12, fname: 'John', lname: 'Doe', mycountry: 'United States', street: '123 hestnut lane', state: 'Ohio', city: 'Springfield', myage: 40 },
    //     { personid: 420, fname: 'Snoop', lname: 'Dog', mycountry: 'America', street: '404 Main Street', state: 'New York', city: 'The Bronx', myage: 49 },
    //     { personid: 56, fname: 'Luffy', lname: 'Monkey D.', mycountry: 'Brazil', street: '1000 Sunny', state: 'New World', city: 'Dressrosa', myage: 19 }
    //   ]);
    // return this.http.get<Player[]>(`${this.url}` + 'playerList');

    return this.http.get<Player[]>('https://localhost:5001/api/RpsGame/PlayerList');
  }

  AddPlayer(p: Player): Observable<Player> {
    //this MAY not be correct
    return this.http.post<Player>(`${this.url}CreateNewPlayer/`, p, this.httpOptions)

  }



  //create any methods that are relevant to this service heres
}
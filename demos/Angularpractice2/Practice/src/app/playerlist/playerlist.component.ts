import { Component, OnInit } from '@angular/core';
import { Player } from '../player';
import { PlayerserviceService } from '../playerservice.service';

@Component({
  selector: 'app-playerlist',
  templateUrl: './playerlist.component.html',
  styleUrls: ['./playerlist.component.css']
})
export class PlayerlistComponent implements OnInit {

  playerArr?: Player[];
  chosen?:Player;
  showAddplayer: boolean = false;
  constructor(private playerservice:PlayerserviceService) { }

  ngOnInit(): void {
    this.playerservice.GetPlayerlist().subscribe( //first subscribe, second error, callback finally
      x => this.playerArr = x,
      y => console.log(y),
      () => console.log('complete callback')
    );


    
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

  AddPlayerParent(event: Player): void {
    //call the service function to add the player to the Db.
    this.playerservice.AddPlayer(event).subscribe(
      x => this.playerArr?.push(x),
      y => console.log('there was a problem adding the player')
    );
  }

}

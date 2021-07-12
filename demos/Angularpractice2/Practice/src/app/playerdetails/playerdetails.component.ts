import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../player';

@Component({
  selector: 'app-playerdetails',
  templateUrl: './playerdetails.component.html',
  styleUrls: ['./playerdetails.component.css']
})
export class PlayerdetailsComponent implements OnInit {

  @Input() player2?: Player;
  constructor() { }

  ngOnInit(): void {
  }

}

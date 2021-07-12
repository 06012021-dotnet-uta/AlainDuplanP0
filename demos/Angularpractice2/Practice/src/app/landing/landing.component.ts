import { Component, OnInit } from '@angular/core';
import { Person } from '../person';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})

export class LandingComponent implements OnInit {

  pageTitle: string = 'This is the first component we\'ve made.';
  input1: string = '';
  clicked: boolean = false;
  sx: number = 0;
  sy: number = 0;
  input2: any;
  input22: any;
  something3: string = 'something3';
  something: string = 'something';
  something4?: string;
  passTochildVar?: string;
  valuePassedFromChild?: string;
  people: Person[] = [
    { name1: 'Dr Nice', age: 10, country: 'USA' },
    { name1: 'Alex', age: 15, country: 'USA' },
    { name1: 'Max', age: 20, country: 'USA' },
    { name1: 'Dr Nice', age: 100, country: 'USA' },
    { name1: 'Alex', age: 55, country: 'USA' },
    { name1: 'Max', age: 209, country: 'USA' },
  ];
  maxAge1: number = 0;

  //constructor is used to set starting values of internal variables only
  // it has very little logic.
  constructor() { }

  //ngOninit() is used to set up any 
  // properties that require any outside requests.
  ngOnInit(): void {

  }

  Input1Func(event: KeyboardEvent): void {
    // console.log(event.key);
    if (event.key.length > 1) {
      console.log('There was not a key pressed tha twas a letter.');
    }
    else {
      this.input1 += event.key;
      console.log('keyup event registered');
    }

  }

  Clickt() {
    this.clicked = !this.clicked;
  }

  textAreaFunc(event: MouseEvent): void {
    // console.log(event);
    this.sx = event.screenX;
    this.sy = event.screenY;
  }

  MaxAgeFunc(age: string): void {
    this.maxAge1 = Number(age);
  }

  DispayIfChanged(s: string): void {
    this.something4 = s;
  }

  PassToChildFunc(p: string): void {
    this.passTochildVar = p;
  }

  GetEventEmitted(event: string): void {
    this.valuePassedFromChild = event;
  }

}
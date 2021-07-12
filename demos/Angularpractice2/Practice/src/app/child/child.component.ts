import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {
  @Input() passedFromParent?: string; // this value is passed from the parent
  @Output() passToParentEventEmitter = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }

  PassToParentFunc(p: string): void {
    //whatever setup you need... like create a object, etc
    this.passToParentEventEmitter.emit(p);// emit that value or obj to the parent.
  }

}
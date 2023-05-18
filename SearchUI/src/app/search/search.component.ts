import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  
  public searchValue: string = "";
  
  constructor() { }
  
  ngOnInit(): void {
  }
  
  onSearchValueChanged(e: string): void {
    console.log('onSearchValueChanged');
  }

}

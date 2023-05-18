import { Component, Input, OnInit } from '@angular/core';
import { File } from '../models/File';
import { App } from '../models/App';
import files from '../data/Files';
import apps from '../data/Apps';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent implements OnInit {
  
  @Input()
  get searchValue(): string { return this._searchValue; }
  set searchValue(searchValue: string) {
    this._searchValue = searchValue;
    if (this.searchValue !== "") {
      this.searchResults = this.search(this._searchValue, this._files.concat(this._apps).map(x => x.name));
      this.style = this.searchResults.length > 0 ? "" : "display: none;";
    }
    
    else {
      this.style = "display: none;";
    }
  }
  
  public style: string = "display: none;";
  
  public searchResults: string[] = [];
  
  private _files: File[] = files;
  
  private _apps: App[] = apps;
  
  private _searchValue = '';
  
  constructor() { }

  ngOnInit(): void {
  }
  
  private search(searchValue: string, items: string[]): string[] {
    let results: string[] = [];
    for (let item of items) {
      if (item.substring(0, searchValue.length) === searchValue) {
        results.push(item);
      }
    }
    
    return results;
  }

}

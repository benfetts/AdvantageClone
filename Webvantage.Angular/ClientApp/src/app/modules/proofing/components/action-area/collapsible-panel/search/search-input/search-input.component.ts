import { Component, OnInit } from '@angular/core';
import { ISearchOptions } from '../../../../../interfaces/search-options';
import { SearchService } from '../../../../../services/search.service';

@Component({
  selector: 'proof-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.css']
})
export class SearchInputComponent implements OnInit {

  constructor(private searchService: SearchService) { }

  searchOptions: ISearchOptions = {
    caseSensitive: true,  // match case
    wholeWord: true,      // match whole words only
    wildcard: false,      // allow using '*' as a wildcard value
    regex: false,         // string is treated as a regular expression
    searchUp: false,      // search from the end of the document upwards
    ambientString: true,  // return ambient string as part of the result
    searchPhrase: ""
  };

  ngOnInit(): void {
  }

  Search(): void {
    this.searchService.setSearchOptions(this.searchOptions);
  }
}

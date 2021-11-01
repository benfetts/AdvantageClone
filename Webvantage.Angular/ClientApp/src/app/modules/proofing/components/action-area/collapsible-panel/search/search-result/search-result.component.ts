import { Component, Input, OnInit } from '@angular/core';
import { ISearchResults } from '../../../../../interfaces/search-results';


@Component({
  selector: 'proof-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {

  constructor() { }

  @Input() public searchResult: ISearchResults;

  ngOnInit(): void {
  }

}

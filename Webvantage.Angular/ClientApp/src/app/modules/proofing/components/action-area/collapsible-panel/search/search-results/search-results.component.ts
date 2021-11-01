import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ISearchResults } from '../../../../../interfaces/search-results';
import { SearchService } from '../../../../../services/search.service';

@Component({
  selector: 'proof-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {

  constructor(private searchService: SearchService,
    private ref: ChangeDetectorRef) { }

  searchResults: ISearchResults[] = null;

  ngOnInit(): void {
    this.searchService.getSearchResults().subscribe((results: ISearchResults[]) => {
      this.searchResults = results;
      this.ref.detectChanges();
    });
  }
  resultClicked(index: number) {

    console.log("selected ", index );

    this.searchResults.forEach((v, i, a) => {
      a[i].active = false;
    });

    this.searchResults[index].active = true;
    this.ref.detectChanges();

    this.searchService.setSelectedResult(this.searchResults[index]);
  }
}

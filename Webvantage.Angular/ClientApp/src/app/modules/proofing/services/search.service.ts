import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { ISearchOptions } from "../interfaces/search-options";
import { ISearchResults } from "../interfaces/search-results";
import { BaseService } from "./base.service";


@Injectable({
  providedIn: 'root'
})
export class SearchService extends BaseService {

  private SearchOptions: BehaviorSubject<ISearchOptions> = new BehaviorSubject<ISearchOptions>(null);
  private SearchResults: BehaviorSubject<ISearchResults[]> = new BehaviorSubject<ISearchResults[]>(null);
  private SelectedResult: BehaviorSubject<ISearchResults> = new BehaviorSubject<ISearchResults>(null);
  private clearSearchText: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  getSearchOptions(): Observable<ISearchOptions> {
    return this.SearchOptions;
  }

  setSearchOptions(options: ISearchOptions): void {
    console.log(options);
    this.SearchOptions.next(options);
  }

  getSearchResults(): Observable<ISearchResults []> {
    return this.SearchResults;
  }

  setSearchResults(searchResults: ISearchResults []): void {
    this.SearchResults.next(searchResults);
  }

  getSelectedResult(): Observable<ISearchResults> {
    return this.SelectedResult;
  }

  setSelectedResult(searchResults: ISearchResults): void {
    this.SelectedResult.next(searchResults);
  }

  clearSearch(): void {
    this.clearSearchText.next(true);
  }

  getClearSearchText(): Observable<boolean> {
    return this.clearSearchText;
  }
}

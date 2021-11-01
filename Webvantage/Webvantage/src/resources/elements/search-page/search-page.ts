import { customElement, bindable } from 'aurelia-framework'

@customElement('wv-search-page')
export class SearchPage {

    @bindable title: string = 'Search';
    @bindable showAdvancedFilters: boolean = true;
    @bindable onSearch;
    @bindable showSearch: boolean = true;

    searchInputExpanded = false;
    collapsed = true;

    expandSearch() {
        this.searchInputExpanded = true;
    }
    collapseSearch() {
        this.searchInputExpanded = false;
    }


    constructor() {
        
    }

}

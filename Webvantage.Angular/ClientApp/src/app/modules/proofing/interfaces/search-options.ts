export interface ISearchOptions {
  caseSensitive: boolean,  // match case
  wholeWord: boolean,      // match whole words only
  wildcard: boolean,      // allow using '*' as a wildcard value
  regex: boolean,         // string is treated as a regular expression
  searchUp: boolean,      // search from the end of the document upwards
  ambientString: boolean,  // return ambient string as part of the result
  searchPhrase: string;
}

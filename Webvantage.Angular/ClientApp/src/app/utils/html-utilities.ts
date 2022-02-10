export class HtmlUtilites {
  static isEmptyHtml(html: string) : boolean {
    const trimmedHtml = html.trim().replace(/ /g, '&nbsp;') //there are spaces between nbsps
      .replace(/(?:^(?:&nbsp;)+)|(?:(?:&nbsp;)+$)/g, '');
    return trimmedHtml.trim().length == 0;
  }
}

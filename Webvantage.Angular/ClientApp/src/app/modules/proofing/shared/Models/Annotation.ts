export interface IAnnotation {
  name: string;
  draw: any;
  id: number,
  markupXml: string,
  markup: string,
  empCode: string,
  documentId: number,
  markupTypeId: number,
  commentId: number,
  seqNbr?: string,
  draft: boolean,
  alertId: number
}

export class wvAnnotation implements IAnnotation {
  name: string;
  draw: any;
  seqNbr?: string;
  draft: boolean = true;
  alertId: number;
  //id: number;
  //markupXml: string;
  //markup: string;
  //empCode: string;
  //documentId: number;
  //markupTypeId: number;
  //alertId: number;

  constructor(
    public id: number,
    public markupXml: string,
    public markup: string,
    public empCode: string,
    public documentId: number,
    public markupTypeId: number,
    public commentId: number
  ) {
  }
}

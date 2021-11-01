
export interface ITextSelect {
  pageNumber: number;
  x: number;
  y: number;
  Width: number;
  Height: number;
  Tool?: string;
  Text?: string;
  quads: Array<IQuad>;
}


export interface IQuad {
  x1: number;
  y1: number;
  x2: number;
  y2: number;
  x3: number;
  y3: number;
  x4: number;
  y4: number;
}

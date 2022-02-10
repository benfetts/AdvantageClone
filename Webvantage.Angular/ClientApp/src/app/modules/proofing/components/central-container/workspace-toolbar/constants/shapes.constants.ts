import { IDropDown } from '../../../../interfaces/drop-down';

export const shapesTypes: IDropDown[] = [
  {
    text: ' ',
    selected: false,
    imageUrl: 'assets/icons/shape-tools/shapes.svg'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/shape-tools/rectangle.svg',
    selected: false,
    name: 'AnnotationCreateRectangle'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/shape-tools/ellipse.svg',
    selected: false,
    name: 'AnnotationCreateEllipse'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/shape-tools/octagon.svg',
    selected: false,
    name: 'AnnotationCreatePolygon'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/shape-tools/Cloud.svg',
    selected: false,
    name: 'AnnotationCreatePolygonCloud'
  },
  {
   text: ' ',
   imageUrl: 'assets/icons/note.svg',
   selected: false,
   name: 'AnnotationCreateSticky'
  },
];

export const textTypes: IDropDown[] = [
  {
    text: ' ',
    selected: false,
    imageUrl: 'assets/icons/shape-tools/text.svg'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/textarea/highlight.svg',
    selected: false,
    name: 'AnnotationCreateTextHighlight'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/textarea/underline.svg',
    selected: false,
    name: 'AnnotationCreateTextUnderline'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/textarea/strikeout.svg',
    selected: false,
    name: 'AnnotationCreateTextStrikeout'
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/textarea/squiggly.svg',
    selected: false,
    name: 'AnnotationCreateTextSquiggly'
  },
];

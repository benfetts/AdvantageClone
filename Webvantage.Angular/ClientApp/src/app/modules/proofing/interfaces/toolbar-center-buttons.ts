import { IButtonProperties } from './button-properties';
import { IDropDown } from './drop-down';

interface IButtonsCenterProperties extends IButtonProperties {
  name: string;
  imageUrl?: string;
}

interface IButtonsCenterPropertiesShapes extends IButtonsCenterProperties {
  shapeTypes: IDropDown[];
}

interface IButtonsCenterPropertiesText extends IButtonsCenterProperties {
  textTypes: IDropDown[];
}

export interface IToolbarCenterButtons {
  handSpread: IButtonsCenterProperties;
  brush: IButtonsCenterProperties;
  shapes: IButtonsCenterPropertiesShapes;
  text: IButtonsCenterPropertiesText;
  selection: IButtonsCenterProperties;
  pasteImage: IButtonsCenterProperties;
  link: IButtonsCenterProperties;
  arrowFrom: IButtonsCenterProperties;
  magnifyingGlass: IButtonsCenterProperties;
  garbageCan: IButtonsCenterProperties;
  pageNavigation: IButtonsCenterProperties;
  bottomNavigation: IButtonsCenterProperties;
  version: IButtonsCenterProperties;
  reticle: IButtonsCenterProperties;
  rotateLeft: IButtonsCenterProperties;
  textArea: IButtonsCenterProperties;
  compare: IButtonsCenterProperties;
  markerTool: IButtonsCenterProperties;
  overlay: IButtonsCenterProperties;
  arrow: IButtonsCenterProperties;
}

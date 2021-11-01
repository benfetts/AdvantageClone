import { IButtonProperties } from './button-properties';

interface IButtonsBottomProperties extends IButtonProperties {
  name: string;
  imageUrl?: string;
}

interface IVersionsTypes extends IButtonsBottomProperties {
  selectedType: string;
}

export interface IToolbarBottomButtons {
  folderOpen: IButtonsBottomProperties;
  fileManagerMin: IButtonsBottomProperties;
  fileManagerMax: IButtonsBottomProperties;
  compare: IButtonsBottomProperties;
  markerTool: IButtonsBottomProperties;
  showPixelsDifferences: IButtonsBottomProperties;
  lock: IButtonsBottomProperties;
  versions: IVersionsTypes;
}

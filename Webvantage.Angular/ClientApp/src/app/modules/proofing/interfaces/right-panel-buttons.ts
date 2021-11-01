import { IButtonProperties } from './button-properties';

interface IButtonsRightPanelProperties extends IButtonProperties {
  name: string;
  imageUrl?: string;
}

//interface IButtonExpanded extends IButtonsRightPanelProperties {
//  onlyOneOpened: boolean;
//}

export interface IRightPanelButtons {
  expanded: IButtonsRightPanelProperties;
  feedback: IButtonsRightPanelProperties;
  review: IButtonsRightPanelProperties;
  assetInfo: IButtonsRightPanelProperties;
  search: IButtonsRightPanelProperties;
}

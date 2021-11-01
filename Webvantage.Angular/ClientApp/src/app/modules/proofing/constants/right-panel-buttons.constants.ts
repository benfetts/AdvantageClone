import { IRightPanelButtons } from '../interfaces/right-panel-buttons';
import { RIGHT_PANEL_BUTTONS_TYPES } from './types/right-panel-buttons-types.constants';

export const RIGHT_PANEL_BUTTONS_CONSTANTS: IRightPanelButtons = {
  expanded: {
    name: RIGHT_PANEL_BUTTONS_TYPES.EXPANDED,
    selected: false,
    imageUrl: 'assets/icons/side-panel/toggle-panel.svg'
  },
  feedback: {
    name: RIGHT_PANEL_BUTTONS_TYPES.FEEDBACK,
    selected: false,
    imageUrl: 'assets/icons/side-panel/feedback.svg'
  },
  review: {
    name: RIGHT_PANEL_BUTTONS_TYPES.REVIEW,
    selected: false,
    imageUrl: 'assets/icons/side-panel/review.svg'
  },
  assetInfo: {
    name: RIGHT_PANEL_BUTTONS_TYPES.ASSET_INFO,
    selected: false,
    imageUrl: 'assets/icons/side-panel/asset-info.svg'
  },
  search: {
    name: RIGHT_PANEL_BUTTONS_TYPES.SEARCH,
    selected: false,
    imageUrl: 'assets/icons/magnifying_glass.svg'
  }
};

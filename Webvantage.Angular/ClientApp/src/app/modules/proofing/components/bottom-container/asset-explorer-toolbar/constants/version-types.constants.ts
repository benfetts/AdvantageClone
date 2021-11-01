import { IDropDown } from '../../../../interfaces/drop-down';
import { VIEW_VERSIONS_TYPES } from '../../../../constants/types/view-versions-types';

export const versionsTypes: IDropDown[] = [
  {
    text: ' ',
    imageUrl: 'assets/icons/view-versions/split-view.svg',
    name: VIEW_VERSIONS_TYPES.SPLIT_VIEW
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/view-versions/split-vertical.svg',
    name: VIEW_VERSIONS_TYPES.SPLIT_VERTICAL
  },
  {
    text: ' ',
    imageUrl: 'assets/icons/view-versions/split-horizontal.svg',
    name: VIEW_VERSIONS_TYPES.SPLIT_HORIZONTAL
  }
];

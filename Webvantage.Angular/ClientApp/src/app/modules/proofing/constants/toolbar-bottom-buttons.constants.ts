import { IToolbarBottomButtons } from '../interfaces/toolbar-bottom-buttons';
import { VIEW_VERSIONS_TYPES } from './types/view-versions-types';
import { BOTTOM_BUTTONS_TYPES } from './types/bottom-buttons-types.constants';

export const BUTTON_BOTTOM_TYPES: IToolbarBottomButtons = {
  folderOpen: {
    name: BOTTOM_BUTTONS_TYPES.FOLDER_OPEN,
    selected: true,
    imageUrl: 'assets/icons/bottom-toolbar/folder_open.svg'
  },
  fileManagerMin: {
    name: BOTTOM_BUTTONS_TYPES.FILE_MANAGER_MIN,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/file_manager_min.svg'
  },
  fileManagerMax: {
    name: BOTTOM_BUTTONS_TYPES.FILE_MANAGER_MAX,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/file_manager_max.svg'
  },
  compare: {
    name: BOTTOM_BUTTONS_TYPES.COMPARE,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/compare.svg'
  },
  markerTool: {
    name: BOTTOM_BUTTONS_TYPES.MARKER_TOOL,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/marker_tool.svg'
  },
  showPixelsDifferences: {
    name: BOTTOM_BUTTONS_TYPES.SHOW_PIXELS_DIFFERENCES,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/show_pixels_differences.svg'
  },
  lock: {
    name: BOTTOM_BUTTONS_TYPES.LOCK,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/lock.svg'
  },
  versions: {
    name: BOTTOM_BUTTONS_TYPES.VERSIONS,
    selected: false,
    selectedType: VIEW_VERSIONS_TYPES.ONE_ASSET
  }
};

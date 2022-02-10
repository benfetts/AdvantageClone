import { IToolbarCenterButtons } from '../interfaces/toolbar-center-buttons';
import { shapesTypes, textTypes } from '../components/central-container/workspace-toolbar/constants/shapes.constants';
import { CENTRAL_BUTTONS_TYPES } from './types/central-buttons-types.constants';

export const buttonCenterTypes: IToolbarCenterButtons = {
  handSpread: {
    name: CENTRAL_BUTTONS_TYPES.HAND_SPREAD,
    selected: false,
    imageUrl: 'assets/icons/hand_spread.svg'
  },
  brush: {
    name: CENTRAL_BUTTONS_TYPES.BRUSH,
    selected: false,
    imageUrl: 'assets/icons/brush.svg'
  },
  shapes: {
    name: CENTRAL_BUTTONS_TYPES.SHAPES,
    selected: false,
    imageUrl: '',
    shapeTypes: shapesTypes,
  },
  text: {
    name: CENTRAL_BUTTONS_TYPES.TEXT,
    selected: false,
    imageUrl: '',
    textTypes: textTypes,
  },
  selection: {
    name: CENTRAL_BUTTONS_TYPES.SELECTION,
    selected: false,
    imageUrl: 'assets/icons/selection.svg'
  },
  pasteImage: {
    name: CENTRAL_BUTTONS_TYPES.PASTE_IMAGE,
    selected: false,
    imageUrl: 'assets/icons/photo_landscape.svg'
  },
  link: {
    name: CENTRAL_BUTTONS_TYPES.LINK,
    selected: false,
    imageUrl: 'assets/icons/link.svg'
  },
  arrowFrom: {
    name: CENTRAL_BUTTONS_TYPES.ARROW_FROM,
    selected: false,
    imageUrl: 'assets/icons/arrow_from.svg'
  },
  magnifyingGlass: {
    name: CENTRAL_BUTTONS_TYPES.MAGNIFYING_GLASS,
    selected: false,
    imageUrl: 'assets/icons/magnifying_glass.svg'
  },
  garbageCan: {
    name: CENTRAL_BUTTONS_TYPES.GARBAGE_CAN,
    selected: false,
    imageUrl: 'assets/icons/garbage_can.svg'
  },
  bottomNavigation: {
    name: CENTRAL_BUTTONS_TYPES.BOTTOM_NAVIGATION,
    selected: true,
    imageUrl: 'assets/icons/view-versions/split-horizontal.svg'
  },
  version: {
    name: CENTRAL_BUTTONS_TYPES.VERSION,
    selected: false,
    imageUrl: 'assets/icons/switch.svg'
  },
  pageNavigation: {
    name: CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION,
    selected: false,
    imageUrl: 'assets/icons/window_split_hor.svg'
  },
  reticle: {
    name: CENTRAL_BUTTONS_TYPES.RETICLE,
    selected: false,
    imageUrl: 'assets/icons/reticle.svg'
  },
  rotateLeft: {
    name: CENTRAL_BUTTONS_TYPES.ROTATE_LEFT,
    selected: false,
    imageUrl: 'assets/icons/rotate_left.svg'
  },
  textArea: {
    name: CENTRAL_BUTTONS_TYPES.TEXT_AREA,
    selected: true
  },
  compare: {
    name: CENTRAL_BUTTONS_TYPES.COMPARE,
    selected: false,
    imageUrl: 'assets/icons/switch.svg'
  },
  compare_horizontal: {
    name: CENTRAL_BUTTONS_TYPES.COMPARE_HORIZONTAL,
    selected: false,
    imageUrl: 'assets/icons/switch.svg'
  },
  markerTool: {
    name: CENTRAL_BUTTONS_TYPES.MARKER_TOOL,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/marker_tool.svg'
  },
  overlay: {
    name: CENTRAL_BUTTONS_TYPES.OVERLAY,
    selected: false,
    imageUrl: 'assets/icons/bottom-toolbar/show_pixels_differences.svg'
  },
  arrow: {
    name: CENTRAL_BUTTONS_TYPES.ARROW,
    selected: false,
    imageUrl: 'assets/icons/shapes/arrow.svg'
  }
};

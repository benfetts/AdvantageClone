"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.BUTTON_CENTER_TYPES = void 0;
var shapes_constants_1 = require("../components/central-container/workspace-toolbar/constants/shapes.constants");
exports.BUTTON_CENTER_TYPES = {
    handSpread: {
        name: "handSpread" /* HAND_SPREAD */,
        selected: false,
        imageUrl: 'assets/icons/hand_spread.svg'
    },
    brush: {
        name: "brush" /* BRUSH */,
        selected: false,
        imageUrl: 'assets/icons/brush.svg'
    },
    shapes: {
        name: "shapes" /* SHAPES */,
        selected: false,
        imageUrl: '',
        shapeTypes: shapes_constants_1.shapesTypes,
    },
    text: {
        name: "text" /* TEXT */,
        selected: false,
        imageUrl: '',
        textTypes: shapes_constants_1.textTypes,
    },
    selection: {
        name: "selection" /* SELECTION */,
        selected: false,
        imageUrl: 'assets/icons/selection.svg'
    },
    pasteImage: {
        name: "pasteImage" /* PASTE_IMAGE */,
        selected: false,
        imageUrl: 'assets/icons/photo_landscape.svg'
    },
    link: {
        name: "link" /* LINK */,
        selected: false,
        imageUrl: 'assets/icons/link.svg'
    },
    arrowFrom: {
        name: "arrowFrom" /* ARROW_FROM */,
        selected: false,
        imageUrl: 'assets/icons/arrow_from.svg'
    },
    magnifyingGlass: {
        name: "magnifyingGlass" /* MAGNIFYING_GLASS */,
        selected: false,
        imageUrl: 'assets/icons/magnifying_glass.svg'
    },
    garbageCan: {
        name: "garbageCan" /* GARBAGE_CAN */,
        selected: false,
        imageUrl: 'assets/icons/garbage_can.svg'
    },
    pageNavigation: {
        name: "pageNavigation" /* PAGE_NAVIGATION */,
        selected: false,
        imageUrl: 'assets/icons/window_split_hor.svg'
    },
    bottomNavigation: {
        name: "bottomNavigation" /* BOTTOM_NAVIGATION */,
        selected: true,
        imageUrl: 'assets/icons/view-versions/split-horizontal.svg'
    },
    version: {
        name: "version" /* VERSION */,
        selected: false,
        imageUrl: 'assets/icons/versions.svg'
    },
    reticle: {
        name: "reticle" /* RETICLE */,
        selected: false,
        imageUrl: 'assets/icons/reticle.svg'
    },
    rotateLeft: {
        name: "rotateLeft" /* ROTATE_LEFT */,
        selected: false,
        imageUrl: 'assets/icons/rotate_left.svg'
    },
    textArea: {
        name: "textArea" /* TEXT_AREA */,
        selected: true
    },
    compare: {
        name: "compare" /* COMPARE */,
        selected: false,
        imageUrl: 'assets/icons/switch.svg'
    },
    markerTool: {
        name: "markerTool" /* MARKER_TOOL */,
        selected: false,
        imageUrl: 'assets/icons/bottom-toolbar/marker_tool.svg'
    },
    overlay: {
        name: "overlay" /* OVERLAY */,
        selected: false,
        imageUrl: 'assets/icons/bottom-toolbar/show_pixels_differences.svg'
    },
    arrow: {
        name: "arrow" /* ARROW */,
        selected: false,
        imageUrl: 'assets/icons/shape-tools/arrow.svg'
    }
};
//# sourceMappingURL=toolbar-center-buttons.constants.js.map
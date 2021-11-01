import { FIFTY_PERCENT, ONE_HUNDRED_PERCENT } from '../../../../constants/size-values.constants';
import { PAGES } from '../../../../constants/pages.constants';

export const VIEW_CONTAINER = {
  first: {
    showPageViewer: false,
    selected: false,
    kendoCardWidth: ONE_HUNDRED_PERCENT,
    containerWidth: FIFTY_PERCENT,
    currentPage: {
      id: 1,
      selected: true,
      imageUrl: 'assets/images/test-image.jpg'
    },
    pages: JSON.parse(JSON.stringify(PAGES))
  },
  second: {
    showPageViewer: false,
    selected: false,
    kendoCardWidth: ONE_HUNDRED_PERCENT,
    containerWidth: FIFTY_PERCENT,
    currentPage: {
      id: 1,
      selected: true,
      imageUrl: 'assets/images/test-image.jpg'
    },
    pages: JSON.parse(JSON.stringify(PAGES))
  }
};

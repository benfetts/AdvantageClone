import { AssetInfo } from '../interfaces/asset-info';

interface TableDataMock {
  name: string;
  data: {
    type: string,
    value: string | string[]
  };
}

const ASSET_MAIN_INFO: TableDataMock[] = [
  {
    name: 'Title',
    data: {
      type: 'string',
      value: 'kek.jpg'
    }
  },
  {
    name: 'Status',
    data: {
      type: 'string',
      value: 'Under Review'
    }
  },
  {
    name: 'Description',
    data: {
      type: 'string',
      value: 'Bla bla bla bla bla bla bla'
    }
  },
  {
    name: 'Version',
    data: {
      type: 'string',
      value: '3'
    }
  },
  {
    name: 'Created Date',
    data: {
      type: 'date',
      value: '2020-05-18 2:51 AM'
    }
  },
  {
    name: 'Created By',
    data: {
      type: 'string',
      value: 'Alan Able'
    }
  },
  {
    name: 'Last Modified',
    data: {
      type: 'date',
      value: '2020-05-19 9:40 AM'
    }
  },
  {
    name: 'Asset URL',
    data: {
      type: 'url',
      value: 'https://google.com'
    }
  },
  {
    name: 'Tags',
    data: {
      type: 'tags',
      value: ['tag1', 'tag2']
    }
  }
];

const ASSET_FILE_INFO: TableDataMock[] = [
  {
    name: 'File Name',
    data: {
      type: 'string',
      value: 'kek.jpg'
    }
  },
  {
    name: 'Type',
    data: {
      type: 'string',
      value: 'Image'
    }
  },
  {
    name: 'Dimensions',
    data: {
      type: 'string',
      value: 'w:284px h:177px'
    }
  },
  {
    name: 'File Size',
    data: {
      type: 'string',
      value: '8.17 KB'
    }
  }
];

const ASSET_VERSIONS_INFO: TableDataMock[] = [
  {
    name: 'Version 2',
    data: {
      type: 'version',
      value: '2020-05-15'
    }
  },
  {
    name: 'Version 2',
    data: {
      type: 'version',
      value: '2020-05-15'
    }
  }
];

export const ASSET_INFO_MOCK: AssetInfo[] = [
  {
    description: 'Asset',
    tableData: ASSET_MAIN_INFO
  },
  {
    description: 'File',
    tableData: ASSET_FILE_INFO
  },
  {
    description: 'Versions',
    tableData: ASSET_VERSIONS_INFO
  },
  {
    description: 'Additional Info',
    tableData: null
  }
];

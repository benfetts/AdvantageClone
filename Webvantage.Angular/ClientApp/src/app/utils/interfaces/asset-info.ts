export interface TableDataMock {
  name: string;
  data: {
    type: string,
    value: string | string[]
  };
}

export interface AssetInfo {
  description: string;
  tableData: TableDataMock[];
}

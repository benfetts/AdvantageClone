import { ASSET } from '../../../../../constants/types/asset-info-table/asset-table.constants';

export interface IAssetInfoColumn {
  name: string;
  title: string;
}

export const Asset: IAssetInfoColumn[] = [
  //"documentId",
  {
    name: "fileName", title: ASSET.TITLE
  },
  //{
  //  name: "description", title: ASSET.DESCRIPTION
  //},
  {
    name: "version", title: ASSET.VERSION
  },
  {
    name: "uploadDate", title: ASSET.CREATED_DATE
  },
  //{
  //  name: "isLatestDocument", title: ASSET.LATEST_DOCUMENT
  //},
  {
    name: "latestMarkupDate", title: ASSET.LATEST_MARKUP_DATE
  },
  {
    name: "latestMarkupFullName", title: ASSET.LATEST_MARKUP_FULL_NAME
  },
  //{
  //  name: "mimeType", title: ASSET.
  //},
  //{
  //  name: "tags", title: ASSET.CREATED_DATE
  //},
  //{
  //  name: "thumbnail", title: ASSET.CREATED_DATE
  //},
  //{
  //  name: "totalApproves", title: ASSET.TOTAL_APPROVES
  //},
  //{
  //  name: "totalDefers", title: ASSET.TOTAL_DEFERS
  //},
  //{
  //  name: "totalRejects", title: ASSET.TOTAL_REJECTS
  //},
  {
    name: "totalMarkups", title: ASSET.TOTAL_MARKUPS
  },
  {
    name: "totalVersions", title: ASSET.TOTAL_VERSIONS
  },
  {
    name: "totalVersionsForAlertID", title: ASSET.TOTAL_VERSIONS_FOR_ALERT_ID
  },

  //{
  //  name: "userFullName", title: ASSET.CREATED_BY
  //},
  //{
  //  name: "tags", title: ASSET.TAGS
  //}
];

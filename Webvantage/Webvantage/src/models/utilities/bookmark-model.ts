import { ModelBase } from 'models/base/model-base';

export class BookmarkModel extends ModelBase {

    FolderName: string;
    Id: number;
    BookmarkType: number;
    UserCode: string;
    Name: string;
    PageURL: string;
    Description: string;
    SequenceNumber: number;
    GroupingText: string;
    ColorIndicatorCSSClass: string;
    IndicatorAbbreviation: string;

}

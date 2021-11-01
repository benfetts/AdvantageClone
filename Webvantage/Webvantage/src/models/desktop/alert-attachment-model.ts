import { ModelBase } from 'models/base/model-base';

export class AlertAttachmentModel extends ModelBase {

    private _Generated: Date;
    private _LastMarkupDate: Date;

    ID: number;
    DocumentID: number;
    AlertID: number;
    FileName: string;
    get Generated(): Date {
        return this._Generated;
    }
    set Generated(value: Date) {
        this._Generated = this.getDate(value);
    }
    EmployeeFullName: string;
    MIMEType: string;
    FileSize: number;
    FileSizeKB: number;
    Description: string;
    UserCode: string;
    IsPrivate: string;
    PrivateFlag: number;
    ProofHQUrl: string;
    HistoryCount: number;
    FileTypeLabel: string;
    FileType: string;
    AllowComments: boolean;
    CssClass: string;
    FileSizeDisplay: string;
    JobNumber: number;
    JobComponentNumber: number;
    SequenceNumber: number;
    IsAlertAttachment: number;
    IsTaskDocument: boolean;
    ProofingURL: string;
    RepositoryFileName: string;
    Thumbnail: string;
    VersionNumber: number;
    RawVersionNumber: number;
    SelectedCSS: string = "";
    IsDefaultSelected: boolean = false;
    TotalVersions: number;
    TotalVersionsForAlertID: number;
    TotalApproved: number;
    TotalRejected: number;
    TotalDeferred: number;
    TotalMarkups: number;
    IsLatest: boolean = false;
    get LastMarkupDate(): Date {
        return this._LastMarkupDate;
    }
    set LastMarkupDate(value: Date) {
        this._LastMarkupDate = this.getDate(value);
    }
    LastMarkupFullName: string;
    GeneratedString: string;
    LastMarkupDateString: string;
    getViewAttachmentUrl(): string {
        if (this.FileName.toUpperCase().endsWith(".PDF")) {
            return "Documents_PDFViewer.aspx?DocumentID=" + this.DocumentID.toString() + "&PageNumber=1&AlertID=" + this.AlertID.toString();
        } else if (this.FileName.toUpperCase().endsWith(".DOC") || this.FileName.toUpperCase().endsWith(".DOCX")) {
            return "Documents_WordViewer.aspx?DocumentID=" + this.DocumentID.toString() + "&PageNumber=1";
        } else if (this.FileName.toUpperCase().endsWith(".GIF") || this.FileName.toUpperCase().endsWith(".JPEG") || this.FileName.toUpperCase().endsWith(".JPG") || this.FileName.toUpperCase().endsWith(".PJPEG") || this.FileName.toUpperCase().endsWith(".PNG") || this.FileName.toUpperCase().endsWith(".TIFF") || this.FileName.toUpperCase().endsWith(".BMP")) {
            return "Documents_ImageViewer.aspx?DocumentID=" + this.DocumentID.toString() + "&PageNumber=1";
        } else if (this.FileName.toUpperCase().endsWith(".MSG")) {
            return "Documents_MSGViewer.aspx?DocumentID=" + this.DocumentID.toString() + "&PageNumber=1";
        } else if (this.FileName.toUpperCase().endsWith(".XLS") || this.FileName.toUpperCase().endsWith(".XLSX")) {
            return "Documents_ExcelViewer.aspx?DocumentID=" + this.DocumentID.toString() + "&PageNumber=0";
        }
        return;
    }
    //currently the supported icon types emmulates the same file extensions 
    //the proofing tool supports.
    getThumbnailViewIcon(): string {
        let fileClass = "";
        
        if (this.Thumbnail) {
            fileClass = "";
        } else {
            if (this.FileTypeLabel.toUpperCase() == "PDF") {
                fileClass = "wvi wvi-file-pdf-regular";
            } else if (this.FileTypeLabel.toUpperCase() == "W") {
                fileClass = "wvi wvi-file-word-regular";
            } else if (this.FileTypeLabel.toUpperCase() == "XL") {
                fileClass = "wvi wvi-excel-logo";
            } else if (this.FileTypeLabel.toUpperCase() == "PP") {
                fileClass = "wvi wvi-file-powerpoint-regular";
            } else {
                fileClass = "wvi wvi-file-image-regular";
            }
        }

        return fileClass;
    }
    constructor() {
        super();
    }
}

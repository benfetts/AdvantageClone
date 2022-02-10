import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { DocumentVersionService } from '../../../../services/document-version.service';

@Component({
  selector: 'proof-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit{
  @Input() public itemType: string;
  @Input() public thumbnail: boolean;
  @Input() public showVersions = false;
  @Input() public fileName: string;
  @Input() public selected: boolean = true;
  @Input() public imageThumbnail: any;
  @Input() public extension: string;
  @Input() public mimeType: string;
  @Input() public documentId: number;
  @Input() public commentsDisplayed: boolean = false;

  version: string = 'Version';

  constructor(private documentVersionService: DocumentVersionService,
    private ref: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    this.documentVersionService.getVersion(this.documentId).subscribe((version) => {
      this.version = "Version " + version;
      this.ref.detectChanges();
    });
  }

  public isImage(): boolean {
    return this.mimeType.includes('image');
  }

  public getClass(): string {
    var rv: string;
    if (this.extension == 'pdf') {
      rv = "wvi-file-pdf-regular";
    } else if (this.extension == 'doc' || this.extension == 'docx') {
      rv = "wvi wvi-file-word-regular";
    } else if (this.extension == 'csv' || this.extension == 'xls' || this.extension == 'xlsx') {
      rv = "wvi wvi-excel-logo";
    } else if (this.extension == 'ppt' || this.extension == 'pptx') {
      rv = "wvi wvi-file-powerpoint-regular";
    } else {
      rv = "wvi-file-image-regular";
    }
    return rv;
  }
}

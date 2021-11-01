import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

import { FILE_NAME_TYPES } from '../../../constants/types/file-name-types';

const IMAGE_URL_FILE = 'assets/icons/file.svg';
const IMAGE_URL_FILES = 'assets/icons/files.svg';

const MAX_LENGTH = 60;
const FILE_NAME_LENGTH = 6;
const INNER_TEXT = 'V2';

@Component({
  selector: 'fool-file-name',
  templateUrl: './file-name.component.html',
  styleUrls: ['./file-name.component.scss']
})
export class FileNameComponent implements OnInit, OnChanges {
  @Input() public showDeleteButton = false;
  @Input() public showVersions = false;
  @Input() public isFrameContainer = false;
  @Input() public isToolbarContainer = false;
  @Input() public isLinkContainer = false;
  @Input() public isImageUploadContainer = false;
  @Input() public fileName = 'File_name_233.png';
  @Input() public textInIcon = INNER_TEXT;
  @Input() public componentType;
  @Input() public innerText = 'Current';
  @Input() public imageUrl = 'assets/icons/file.svg';
  @Input() public assetsTypes;
  @Input() public maxLength = MAX_LENGTH;
  @Input() public fileNameLength = FILE_NAME_LENGTH;

  public oneAssetType = FILE_NAME_TYPES.ONE_ASSET;
  public noSplitType = FILE_NAME_TYPES.NO_SPLIT;
  public relatedAssetsType = FILE_NAME_TYPES.RELATED_ASSETS;
  public imageContainerType = FILE_NAME_TYPES.IMAGE_CONTAINER;

  public ngOnInit() {
    this.fileName = this.fileName.length > this.maxLength
      ? `${this.fileName.slice(0, this.fileNameLength)}...`
      : this.fileName;
  }

  public ngOnChanges(changes: SimpleChanges) {
    if (this.assetsTypes === FILE_NAME_TYPES.ONE_ASSET) {
      this.imageUrl = IMAGE_URL_FILES;
    } else {
      this.imageUrl = IMAGE_URL_FILE;
    }
  }
}

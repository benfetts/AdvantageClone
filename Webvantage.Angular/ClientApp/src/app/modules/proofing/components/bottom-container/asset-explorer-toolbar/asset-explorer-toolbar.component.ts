import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { FILE_NAME_TYPES } from '../../../constants/types/file-name-types';
import { VersionsAssetFileService } from '../../../services/versions-asset-file.service';
import { IDropDown } from '../../../interfaces/drop-down';
import { ComparisonService } from '../../../services/comparison.service';
import { IToolbarBottomButtons } from '../../../interfaces/toolbar-bottom-buttons';
import { BottomPanelButtonsService } from '../../../services/bottom-panel-buttons.service';
import { MAX_AMOUNT_OF_COMPARISON_FILES } from '../../../constants/size-values.constants';
import { LIST_OF_ITEMS } from './constants/items-types.constants';
import { ASSETS_TYPE } from './constants/assets-types.constants';
import { versionsTypes } from './constants/version-types.constants';
import { ITooltip } from '../../../interfaces/tooltip';
import { TOOLTIPS } from '../../../constants/tooltips.constants';
import { BOTTOM_BUTTONS_TYPES } from '../../../constants/types/bottom-buttons-types.constants';

const LOCK = BOTTOM_BUTTONS_TYPES.LOCK;
const DIALOG_WINDOW_TEXT = 'You cannot compare against an asset that is already open';

@Component({
  selector: 'proof-asset-explorer-toolbar',
  templateUrl: './asset-explorer-toolbar.component.html',
  styleUrls: ['./asset-explorer-toolbar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class AssetExplorerToolbarComponent implements OnInit {
  public listItems: string[] = LIST_OF_ITEMS;
  public buttons: Observable<IToolbarBottomButtons>;
  public fileNameType = FILE_NAME_TYPES.IMAGE_CONTAINER;
  public itemTypes: Observable<string>;
  public assetsTypes = ASSETS_TYPE;
  public relatedAssets = FILE_NAME_TYPES.RELATED_ASSETS;
  public dialogWindowOpened = false;
  public dialogWindowText = DIALOG_WINDOW_TEXT;
  public versionsTypes: IDropDown[] = versionsTypes;
  public tooltips: ITooltip = TOOLTIPS;

  constructor(private comparisonService: ComparisonService,
    private versionsAssetFileService: VersionsAssetFileService,
    private bottomPanelButtonsService: BottomPanelButtonsService) {
  }

  public ngOnInit(): void {
    this.buttons = this.bottomPanelButtonsService.getBottomPanelButtons();
    this.itemTypes = this.versionsAssetFileService.getAssetVersion();
  }

  get compareAndfileManagerMaxButtons() {
    return this.buttons.pipe(
      map((buttons: IToolbarBottomButtons) => {
        return {
          compareButton: buttons.compare.selected,
          fileManagerMaxButton: buttons.fileManagerMax.selected,
        };
      })
    );
  }

  public selectedButton(value: string): void {
    //this.bottomPanelButtonsService.setBottomPanelButtons(value);
    if (value === LOCK) {
      this.dialogWindowOpened = true;
    }
  }

  public setDialogWindowClosed(value: boolean): void {
    this.dialogWindowOpened = value;
    //this.bottomPanelButtonsService.setBottomPanelButtons(LOCK);
  }

  public showButtonsOnComprasion({ compareButton, fileManagerMaxButton }, comprasionFilesAmount: number): boolean {
    return compareButton && !fileManagerMaxButton && (comprasionFilesAmount === MAX_AMOUNT_OF_COMPARISON_FILES);
  }
}

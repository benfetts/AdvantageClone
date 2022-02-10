import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FILE_NAME_TYPES } from '../../constants/types/file-name-types';

import { IToolbarCenterButtons } from '../../interfaces/toolbar-center-buttons';
import { BottomPanelButtonsService } from '../../services/bottom-panel-buttons.service';
import { CenterPanelButtonsService } from '../../services/center-panel-buttons.service';
import { ComparisonService } from '../../services/comparison.service';
import { VersionsAssetFileService } from '../../services/versions-asset-file.service';

@Component({
  selector: 'proof-bottom-container',
  templateUrl: './bottom-container.component.html',
  styleUrls: ['./bottom-container.component.scss']
})
export class BottomContainerComponent implements OnInit {
  public showExplorer: Observable<IToolbarCenterButtons>;
  public versions: boolean = true;

  constructor(private bottomPanelButtonsService: BottomPanelButtonsService,
    private centerPanelButtonsService : CenterPanelButtonsService,
    private versionsAssetFileService: VersionsAssetFileService,
    private comparisonService: ComparisonService,
    private ref: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    this.showExplorer = this.centerPanelButtonsService.getCentralPanelButtons();

    this.versionsAssetFileService.getAssetVersion().subscribe((version) => {
      if (version == FILE_NAME_TYPES.VERSIONS) {
        this.versions = true;
      }
      else {
        this.versions = false;
      }
    });
  }
}

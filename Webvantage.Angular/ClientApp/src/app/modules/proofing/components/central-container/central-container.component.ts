import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';

import { IToolbarBottomButtons } from '../../interfaces/toolbar-bottom-buttons';
import { BottomPanelButtonsService } from '../../services/bottom-panel-buttons.service';
import { IDropDown } from '../../interfaces/drop-down';
import { WorkspaceContainerComponent } from './workspace-container/workspace-container.component';

@Component({
  selector: 'proof-central-container',
  templateUrl: './central-container.component.html',
  styleUrls: ['./central-container.component.scss']
})
export class CentralContainerComponent implements OnInit {
  public bottomPanelButtons: Observable<IToolbarBottomButtons>;

  //@ViewChild(WorkspaceContainerComponent)
  //private workspaceContainer: WorkspaceContainerComponent;

  constructor(private bottomPanelButtonsService: BottomPanelButtonsService) {
  }

  public ngOnInit(): void {
    this.bottomPanelButtons = this.bottomPanelButtonsService.getBottomPanelButtons();
  }
}

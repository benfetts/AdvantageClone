import { Component, OnInit, ViewEncapsulation, ChangeDetectorRef, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';

import { IToolbarCenterButtons } from '../../../interfaces/toolbar-center-buttons';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';
import { RightPanelButtonsService } from '../../../services/right-panel-buttons.service';
import { IRightPanelButtons } from '../../../interfaces/right-panel-buttons';
import { FlagConstants } from './constants/flag.constants';
import { IFlag } from '../../../interfaces/flag';
import { TEXTAREA_EDIT_BUTTONS } from './constants/textarea-edit-buttons.constants';
import { AnnotationService } from '../../../services/annotation.service';
import {  IAnnotation } from '../../../shared/Models/Annotation';
import { TextSelectService } from '../../../services/text-select.service';
import { ITextSelect } from '../../../constants/types/quad-typets';
import { IButtonsTextEditProperties } from '../../../interfaces/text-buttons';
import { DescriptionComponent } from './components/description/description.component';
import { IFeedback } from '../../../interfaces/feedback';
import { FeedbackService } from '../../../services/feedback.service';
import { filter, map } from 'rxjs/operators';
import { RIGHT_PANEL_BUTTONS_TYPES } from '../../../constants/types/right-panel-buttons-types.constants';
import { SearchService } from '../../../services/search.service';

@Component({
  selector: 'proof-collapsible-panel',
  templateUrl: './collapsible-panel.component.html',
  styleUrls: ['./collapsible-panel.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CollapsiblePanelComponent implements OnInit {
  public centralPanelButtons: Observable<IToolbarCenterButtons>;
  public rightPanelButtons: Observable<IRightPanelButtons>;
  public selectedAnnotation: IAnnotation;
  public editTextButtons = TEXTAREA_EDIT_BUTTONS;
  public flag: IFlag = FlagConstants;
  public selectedText: ITextSelect;
  public description: string = '';

  @ViewChild(DescriptionComponent) public descriptionComponent: DescriptionComponent;

  public ToolSize: number = 5;
  public ToolOpacity: number = 1;
  public disabled: boolean = true;

  public draftText: string = "";
  public opened = false;

  constructor(private centralPanelButtonsService: CenterPanelButtonsService,
    private rightPanelButtonsService: RightPanelButtonsService,
    private annotationService: AnnotationService,
    private textSelectService: TextSelectService,
    private searchService: SearchService,
    private ref: ChangeDetectorRef) {

  }

  public ngOnInit(): void {
    this.centralPanelButtons = this.centralPanelButtonsService.getCentralPanelButtons();
    this.rightPanelButtons = this.rightPanelButtonsService.getRightPanelButtons();

    this.rightPanelButtonsService.getRightPanelButtons().pipe(map(buttons=> buttons.expanded)).subscribe((fubar) => {
      console.log(this.selectedAnnotation);
      if (fubar.selected == false && this.selectedAnnotation != null && this.selectedAnnotation.draft) {
        this.draftText = this.selectedAnnotation.markup;

        console.log(this.draftText);

        this.opened = true;
      }
      else if (fubar.selected == true && this.selectedAnnotation != null && this.selectedAnnotation.draft) {
        this.description = this.selectedAnnotation.markup;
      }
    });

    this.rightPanelButtonsService.getRightPanelButtons().pipe(map(buttons => buttons.search)).subscribe((search) => {
      if (search.selected == false) {
        this.searchService.clearSearch();
        this.searchService.setSearchOptions(null);
      }
    });

    this.textSelectService.getSelectedText()
      .subscribe((selectedText) => {
        this.selectedText = selectedText;
        this.description = selectedText.Text;
        this.ref.detectChanges();
      });

    this.annotationService.getSelected().subscribe((annotation) => {
      this.selectedAnnotation = annotation;
      if (this.selectedAnnotation != null) {
        this.disabled = !this.selectedAnnotation.draft;
      }
      else {
        this.disabled = true;
      }
      this.ref.detectChanges();
    });

    this.annotationService.getToolSize().subscribe((size) => {
      this.ToolSize = size;
    });

    this.annotationService.getToolOpacity().subscribe((opacity) => {
      this.ToolOpacity = opacity;
    });
  }

  public close(status) {
    console.log(`Dialog result: ${status}`);
    if (status == 'yes') {
      this.annotationService.deleteDraftAnnotations();

      //this.approvalService.approve(this.approvalStatus, this.document?.documentId);
    }
    else {
      this.rightPanelButtonsService.setRightPanelButtons(RIGHT_PANEL_BUTTONS_TYPES.EXPANDED);
    }
    this.opened = false;
  }

  public onFlagClick(event): void {
    event.stopPropagation();
    this.flag.flagChecked = !this.flag.flagChecked;
  }

  public ColorChange(event): void {
    this.annotationService.setSelectedColor(event);
  }

  public ColorTextChange(event): void {

  }

  public changeSize(event): void {
    this.annotationService.setToolSize(event);
  }

  public changeOpacity(event): void {
    this.annotationService.setToolOpacity(event);
  }

  public setSelectedButton(editTextButton: IButtonsTextEditProperties): void {
    if ((editTextButton.name == 'Highlight' || editTextButton.name == 'Underline' || editTextButton.name == 'Delete' || editTextButton.name == 'Replace') && this.selectedText) {
      this.selectedText.Tool = editTextButton.name;
      this.textSelectService.setNewTextAnnotation(this.selectedText);
    }
  }

  //public textChanged(text: string) {
  //  console.log('textChanged', text);

  //  if (this.selectedAnnotation?.draft) {
  //    this.draftText = text;
  //  }
  //  else {
  //    this.draftText = '';
  //  }
  //}

//  public descriptionSaveClicked(description: string): void {
//    //here we need to create the annotations
//  }
}

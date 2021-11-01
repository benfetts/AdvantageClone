import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';

import { IDropDown } from '../../../interfaces/drop-down';
import { DROP_DOWN_TYPES } from '../../../constants/types/drop-down-types.constants';
import { BottomPanelButtonsService } from '../../../services/bottom-panel-buttons.service';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';
import { SliderToolService } from '../../../services/slider-tool.service';


const ARROW_TYPES = {
  'opened': 'assets/icons/arrow-opened.svg',
  'closed': 'assets/icons/arrow-closed.svg'
};

@Component({
  selector: 'proof-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DropDownComponent implements OnInit {
  @Input() public data: IDropDown[];
  @Input() public imageUrl: string;
  @Input() public value: string;
  @Input() public disabled: boolean = false;
  @Input() public dropDownType = DROP_DOWN_TYPES.TOOLS;
  @Output() public dropDownToggle = new EventEmitter<boolean>();
  @Output() public dropDownOpen = new EventEmitter<boolean>();

  public isOpen = false;
  public componentType;
  public image: string;
  public popupSettings;
  public topToolbarType = DROP_DOWN_TYPES.TOOLS;
  public dropDownData: IDropDown[];
  public rangerSelect = DROP_DOWN_TYPES.PERCENTS_RANGER;
  public bottomToolbarType = DROP_DOWN_TYPES.VERSIONS_SELECTOR;
  public imgArrow = ARROW_TYPES['opened'];

  constructor(private bottomPanelButtonsService: BottomPanelButtonsService,
    private centerPanelButtonsService: CenterPanelButtonsService,
    private sliderToolService: SliderToolService) {
  }

  public ngOnInit(): void {
    this.image = this.imageUrl;
    this.dropDownData = (this.dropDownType === this.topToolbarType || this.dropDownType === DROP_DOWN_TYPES.TEXT) ? this.data.slice(1) : this.data;
    this.componentType = this.dropDownType;
    this.popupSettings = this.dropDownType === DROP_DOWN_TYPES.PERCENTS_RANGER
      ? {popupClass: this.componentType, align: 'right', appendTo: 'root'}
      : {popupClass: this.componentType};
  }

  public onOpen(): void {
    this.isOpen = true;
    this.imgArrow = ARROW_TYPES['closed'];
    this.dropDownToggle.emit(true);
    this.dropDownOpen.emit(true);
  }

  public onClose(): void {
    this.isOpen = false;
    this.imgArrow = ARROW_TYPES['opened'];
    this.dropDownToggle.emit(false);
  }

  public onItemClick(item: IDropDown): void {
    this.image = item.imageUrl;
    if (this.componentType === this.bottomToolbarType) {
      this.bottomPanelButtonsService.setViewVersion(item.name);
    }
    else if (this.dropDownType == DROP_DOWN_TYPES.TOOLS) {
        this.centerPanelButtonsService.setShapesButtons(item.name);
    }
    else if (this.dropDownType === DROP_DOWN_TYPES.TEXT) {
      console.log(item.name);
      this.centerPanelButtonsService.setTextButtons(item.name);
    }
    else if (this.componentType === this.rangerSelect) {
      this.sliderToolService.setFitMode(item.name);
    }
  }

  public isBottomToolbar(type: string): boolean {
    return type === this.bottomToolbarType;
  }
}

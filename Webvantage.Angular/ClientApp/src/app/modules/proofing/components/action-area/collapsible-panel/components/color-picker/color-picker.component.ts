import { Component, ViewEncapsulation, ViewChild, EventEmitter, Output, ChangeDetectorRef, OnInit, Input } from '@angular/core';
import { AnnotationService } from '../../../../../services/annotation.service';

import { PALETTE_COLORS_HEADER, RED_SHADES, GREEN_SHADES, black, darkBlue, curiousBlue, blue, greenLight, green, red, LIGHTGREEN_SHADES, BLUE_SHADES, CURIOUSBLUE_SHADES, DARKBLUE_SHADES, GREY_SHADES } from '../../../constants/palette-header-colors.constants';

@Component({
  selector: 'proof-color-picker',
  templateUrl: './color-picker.component.html',
  styleUrls: ['./color-picker.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ColorPickerComponent implements OnInit {
  public palette: string[] = PALETTE_COLORS_HEADER;
  public paletteLarge: string[] = RED_SHADES;
  @Input() disabled: boolean = true;
  @Output()
  public ColorChange: EventEmitter<string> = new EventEmitter<string>();

  constructor(private annotationService: AnnotationService,
    private ref: ChangeDetectorRef) {

  }

  public ngOnInit(): void {
    this.annotationService.getSelectedColor().subscribe((color) => {
      this.SetColor(color);
    })
  }

  public SetColor(color: string) {
    //black, red, green, greenLight, blue, curiousBlue, darkBlue
    var colors = [GREY_SHADES, RED_SHADES, GREEN_SHADES,LIGHTGREEN_SHADES, BLUE_SHADES, CURIOUSBLUE_SHADES, DARKBLUE_SHADES];
    colors.forEach((v : Array<string>, i, a) => {
      var found = v.find(element => { return element.toUpperCase() == color.toUpperCase(); });

      if (found) {
        //this.palleteChange(PALETTE_COLORS_HEADER[i]);
        this.paletteLarge = v;
        this.ref.detectChanges();
      }
    });
  }

  public palleteChange(e: string) {
    console.log(e);

    switch (e.toUpperCase()) {
      case black: {
        this.paletteLarge = GREY_SHADES;
        break;
      }
      case red: {
        this.paletteLarge = RED_SHADES;
        break;
      }
      case green: {
        this.paletteLarge = GREEN_SHADES;
        break;
      }
      case greenLight: {
        this.paletteLarge = LIGHTGREEN_SHADES;
        break;
      }
      case blue: {
        this.paletteLarge = BLUE_SHADES;
        break;
      }
      case curiousBlue: {
        this.paletteLarge = CURIOUSBLUE_SHADES;
        break;
      }
      case darkBlue: {
        this.paletteLarge = DARKBLUE_SHADES;
        break;
      }
    }

    this.ColorChange.emit(e);

    this.ref.detectChanges();
  }

  public NewColor(e) {
    console.log(e);
    this.ColorChange.emit(e);
  }
}

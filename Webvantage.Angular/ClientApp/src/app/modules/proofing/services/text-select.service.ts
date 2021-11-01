import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { ITextSelect } from '../constants/types/quad-typets';


@Injectable({
  providedIn: 'root'
})
export class TextSelectService {

  textSelected: BehaviorSubject<ITextSelect> = new BehaviorSubject<ITextSelect>({pageNumber: 0, quads: null,x:0,y:0,Width:0,Height:0});
  newTextAnnotation: BehaviorSubject<ITextSelect> = new BehaviorSubject<ITextSelect>({ pageNumber: 0, quads: null, x: 0, y: 0, Width: 0, Height: 0 });
  constructor() {

  }

  getSelectedText(): Observable<ITextSelect> {
    return this.textSelected;
  }

  getNewTextAnnotation(): Observable<ITextSelect> {
    return this.newTextAnnotation;
  }

  setSelectedText(textSelected: ITextSelect): void {
    this.textSelected.next(textSelected);
  }

  setNewTextAnnotation(textSelected: ITextSelect): void {
    this.newTextAnnotation.next(textSelected);
  }

}

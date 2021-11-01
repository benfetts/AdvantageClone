import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { FILE_TYPES } from '../constants/types/file-types';

@Injectable({
  providedIn: 'root'
})
export class SelectedFileTypeService {
  private fileType: BehaviorSubject<string> = new BehaviorSubject<string>(FILE_TYPES.IMAGE);

  public setFileType(value: string): void {
    this.fileType.next(value);
  }

  public getFileType(): Observable<string> {
    return this.fileType;
  }
}

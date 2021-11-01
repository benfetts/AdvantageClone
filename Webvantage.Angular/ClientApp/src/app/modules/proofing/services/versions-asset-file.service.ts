import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { FILE_NAME_TYPES } from '../constants/types/file-name-types';

@Injectable({
  providedIn: 'root'
})
export class VersionsAssetFileService {
  private assetVersion: BehaviorSubject<string> = new BehaviorSubject<string>(FILE_NAME_TYPES.VERSIONS);

  public setAssetVersion(value: string): void {
    this.assetVersion.next(value);
  }

  public getAssetVersion(): Observable<string> {
    return this.assetVersion;
  }
}

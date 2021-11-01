import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LINK_TOOL_TYPES } from '../constants/types/link-tool-types';

@Injectable({
  providedIn: 'root'
})
export class LinkToolService {
  private linkTool: BehaviorSubject<string> = new BehaviorSubject<string>(LINK_TOOL_TYPES.LINK_TO_ASSET);

  public setLinkToolType(value: string): void {
    this.linkTool.next(value);
  }

  public getLinkToolType(): Observable<string> {
    return this.linkTool;
  }
}

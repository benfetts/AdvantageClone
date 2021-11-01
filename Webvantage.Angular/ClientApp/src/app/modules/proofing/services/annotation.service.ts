import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { IAnnotation, wvAnnotation } from '../shared/Models/Annotation';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { FeedbackService } from './feedback.service';
import { ActiveFileService } from './active-file.service';
import { BaseService } from './base.service';
import { catchError, filter, map, retry } from 'rxjs/operators';
import { UpdateWVService } from './update-wv-alert.service';
import { CenterPanelButtonsService } from './center-panel-buttons.service';
import { IDocument } from '../interfaces/document';
import { SignalrService } from './signalr.services';

@Injectable({
  providedIn: 'root'
})
export class AnnotationService extends BaseService {

  private Selected$: BehaviorSubject<IAnnotation> = new BehaviorSubject<IAnnotation>(null);
  private selected: IAnnotation = new wvAnnotation(0, '', '', '', 0, 0, 0);
  private annotations: IAnnotation[] = [];
  private annotations$: BehaviorSubject<IAnnotation[]> = new BehaviorSubject<IAnnotation[]>(null);
  private ComparisonAnnotations: BehaviorSubject<IAnnotation[]> = new BehaviorSubject<IAnnotation[]>(null);
  private currentColor: BehaviorSubject<string> = new BehaviorSubject<string>('');
  private toolSize: BehaviorSubject<number> = new BehaviorSubject<number>(5);
  private toolOpacity: BehaviorSubject<number> = new BehaviorSubject<number>(1);
  private dl: string = '';
  private document: IDocument = null;
  private draftAnotations: IAnnotation[] = [];
  private draftAnotations$: BehaviorSubject<IAnnotation[]> = new BehaviorSubject<IAnnotation[]>([]);

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private feedbackService: FeedbackService,
    private updateWVService: UpdateWVService,
    private activeFileService: ActiveFileService,
    private centerPanelButtonsService: CenterPanelButtonsService,
    private signalrService: SignalrService) {
    super();
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });

    this.Selected$.next(this.selected);

    this.activeFileService.getDocument().pipe(filter(x => x != null)).subscribe(document => {
      this.document = document;
    });

    this.centerPanelButtonsService.getCentralPanelButtons().pipe(map(buttons => {
      return buttons.garbageCan;
    }), filter(x => x.selected == true))
      .subscribe((e) => {
        this.deleteDraftAnnotations();
      });
  }

  getDraftAnnotationCount(): number {
    if (this.draftAnotations) {
      return this.draftAnotations.length;
    }

    return 0;
  }

  getAllWithCommentId(commentId: number): IAnnotation[] {
    var rv: IAnnotation[] = [];

    if (this.annotations) {
      rv = this.annotations.filter((v, i, a) => {
        return v.commentId == commentId;
      });
    }

    return rv;
  }

  getAnnotations(): Observable<IAnnotation[]> {
    return this.annotations$;
  }

  getAnnotationValues(): IAnnotation[] {
    return this.annotations;
  }

  getComparisonAnnotations(): Observable<IAnnotation[]> {
    return this.ComparisonAnnotations;
  }

  getSelected(): Observable<IAnnotation> {
    return this.Selected$;
  }

  getSelectedValue(): IAnnotation {
    return this.Selected$.getValue();
  }

  setSelected(annotation: wvAnnotation) {
    this.selected = annotation;
    this.Selected$.next(this.selected);
  }

  getByAU(au: string): wvAnnotation {

    if (this.selected != null && this.selected.name == au) {
      return this.selected;
    }

    var annotation: wvAnnotation = null;
    annotation = this.annotations.find((v) => {
      return v.name == au;
    });

    if (annotation == null) {
      annotation = this.draftAnotations.find((v) => {
        return v.name == au;
      });
    }

    return annotation;
  }

  getById(id: number): wvAnnotation {
    var annotation: wvAnnotation;
    annotation = this.annotations.find((v) => {
      return v.id == id;
    });
    return annotation;
  }

  setSelectedByAU(au: string) {

    var annotation = this.getByAU(au);

    //stop the propigation of the select if the comment id is the same.
    if (annotation == null || this.selected == null || annotation.commentId != this.selected.commentId) {
      this.setSelected(annotation);
    }
  }

  setSelectedById(markupId: number) {
    var annotation = this.getById(markupId);

    if (annotation != null) {
      this.setSelected(annotation);
    }
    else {
      console.log('get annotation by id returned null.');
    }
  }

  setDrafatComment(comment: string) {
    this.draftAnotations.forEach((v, i, a) => {
      a[i].markup = comment;
    })
  }

  setSelectedColor(string) {
    this.currentColor.next(string);
  }

  getSelectedColor(): Observable<string> {
    return this.currentColor;
  }

  setToolSize(size: number) {
    this.toolSize.next(size);
  }

  getToolSize(): Observable<number> {
    return this.toolSize;
  }

  setToolOpacity(size: number) {
    this.toolOpacity.next(size);
  }

  getToolOpacity(): Observable<number> {
    return this.toolOpacity;
  }

  draftAnnotation(annotation: wvAnnotation): void {
    //set the draft annotation as the active annotation

    //set this as the selected one so we can adjust the color and stuff
    this.setSelected(annotation);

    this.draftAnotations.push(annotation);
    this.draftAnotations$.next(this.draftAnotations);
  }

  deleteDraftAnnotations(): void {
    this.draftAnotations = [];
    this.draftAnotations$.next(this.draftAnotations);
    this.setSelected(null);
  }

  getDraftAnnotations(): Observable<IAnnotation[]> {
    return this.draftAnotations$.pipe();
  }

  updateDraftAnnotation(markupXml: string) {
    //ok we need to update the annotation that is selected
    if (this.selected != null) {
      this.selected.markupXml = markupXml;
    }
    this.Selected$.next(this.selected);
  }

  //clear button or image was changed
  clearDraftAnnotations(): void {
    this.draftAnotations = [];
    this.draftAnotations$.next(this.draftAnotations);
  }

  createComment(comment: string, documentId: number, mentions?: string[]) {
    var url: string = 'api/AlertComment?dl=' + this.dl;
    this.http.post(url, {
      comment: comment,
      mentions: mentions,
      documentId: documentId
    }).pipe(
      catchError(this.handleError))
      .subscribe(() => {
        this.feedbackService.loadFeedback(documentId);
        //refresh the webvantage page
        //this.updateWVService.updateWebvantageAlert(annotations[0].alertId);
        this.signalrService.sendRefresh();
      });
  }

  createAnotations(comment: string, mentions?: string[]) {
    var value = [];

    if (this.draftAnotations.length > 0) {
      this.draftAnotations.forEach((v, i, s) => {
        value.push(
          {
            Markup: comment,
            MarkupXml: v.markupXml,
            MarkupTypeId: v.markupTypeId,
            DocumentId: this.document?.documentId,
            mentions: mentions
          });
      });

      var url: string = 'api/Annotations?dl=' + this.dl;

      this.http.post(url, value
      ).pipe(
        catchError(this.handleError)
      ).subscribe((annotations: wvAnnotation[]) => {
        annotations.forEach((v, i, a) => {
          a[i].name = this.draftAnotations[i].name;
          a[i].draft = false;
          this.annotations.unshift(a[i]);
        });

        //clear the draft anotations
        this.draftAnotations = [];
        this.draftAnotations$.next(this.draftAnotations);

        //set that we have new annotations
        this.annotations$.next(annotations);
        this.setSelected(annotations[0]);
        //reload the comments
        this.feedbackService.loadFeedback(this.document?.documentId);
        //refresh the webvantage page
        //this.updateWVService.updateWebvantageAlert(annotations[0].alertId);
        this.signalrService.sendRefresh();
      });
    }
    else {
      //this is just a comment
    }
  }

  updateAnnotation(annotation: wvAnnotation) {
    //this should never happen
    var value = {
      Markup: annotation.markup,
      MarkupXml: annotation.markupXml,
      MarkupTypeId: annotation.markupTypeId,
      Id: annotation.id,
      CommentID: annotation.commentId,
      DocumentId: this.document?.documentId
    };
    this.http.put('api/Annotations/' + annotation.id + '?dl=' + this.dl, value
    ).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((annotation: wvAnnotation) => {
      //this.setSelected(annotation);
    });

  }

  clearAnnotations(): void {
    this.annotations$.next(null);
  }

  loadAnotations(dl: string, documentId?: number) {
    var url: string = 'api/Annotations' + (documentId == null ? '?dl=' : '/' + documentId + '?dl=') + dl;
    this.http.get<wvAnnotation[]>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe((annotations) => {
        this.annotations = annotations;
        this.annotations$.next(this.annotations);
      });
  }

  loadComparisonAnotations(dl: string, documentId: number) {
    this.http.get<wvAnnotation[]>('api/Annotations/' + documentId + '?dl=' + dl)
      .pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe((annotations) => {
        this.ComparisonAnnotations.next(annotations);
      });
  }

  deleteAnnotation(annotation: wvAnnotation) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        dl: this.dl,
      },
    };
    this.http.delete('api/Annotations/' + annotation.id, options).
      pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe(() => {
        const index = this.annotations.indexOf(annotation, 0);
        if (index > -1) {
          this.annotations.splice(index, 1);
          this.annotations$.next(this.annotations);
        }
      });
  }
}

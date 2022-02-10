import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { IAnnotation, wvAnnotation } from "../shared/Models/Annotation";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class ComparisonAnnotationService extends BaseService {

  private Selected$: BehaviorSubject<IAnnotation> = new BehaviorSubject<IAnnotation>(null);
  private selected: IAnnotation = new wvAnnotation(0, '', '', '', 0, 0, 0);
  private annotations: IAnnotation[] = [];
  private annotations$: BehaviorSubject<IAnnotation[]> = new BehaviorSubject<IAnnotation[]>(null);

  constructor(private http: HttpClient) {
    super();
  }

  loadAnotations(dl: string, documentId: number) {
    var url: string = 'api/Annotations/' + documentId + '?dl=' + dl;

    this.http.get<IAnnotation[]>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe((annotations: IAnnotation[]) => {
        this.annotations = annotations;
        this.annotations$.next(this.annotations);
      });
  }

  getAnnotations(): Observable<IAnnotation[]> {
    return this.annotations$;
  }

  getAnnotationValues(): IAnnotation[] {
    return this.annotations;
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

  setSelectedById(markupId: number) : boolean {
    var annotation = this.getById(markupId);

    if (annotation != null) {
      this.setSelected(annotation);
      return true;
    }
    else {
      console.log('get annotation by id returned null.');
      return false;
    }
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
}

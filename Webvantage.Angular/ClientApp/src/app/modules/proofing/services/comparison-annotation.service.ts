import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { IAnnotation } from "../shared/Models/Annotation";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class ComparisonAnnotationService extends BaseService {

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
        console.log(annotations, this.annotations);
        this.annotations = annotations;
        this.annotations$.next(this.annotations);
      });
  }

  getAnnotations(): Observable<IAnnotation[]> {
    return this.annotations$;
  }
}

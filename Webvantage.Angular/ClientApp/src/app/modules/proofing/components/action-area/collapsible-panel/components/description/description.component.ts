import { Component, ViewEncapsulation, OnInit, ViewChild, ChangeDetectorRef, Input, EventEmitter, Output, ElementRef } from '@angular/core';
import { IDescriptionButtons } from '../../../../../interfaces/descriptions-buttons';
import { DESCRIPTION_BUTTONS_TYPES } from '../../../../../constants/descriptions-buttons.constants';
import { AnnotationService } from '../../../../../services/annotation.service';
import { IAnnotation } from '../../../../../shared/Models/Annotation';
import { TextareaComponent } from '../../../../../shared/components/textarea/textarea.component';
import { MentionItemComponent } from '../../../../../shared/components/mention-item/mention-item.component';
import { CenterPanelButtonsService } from '../../../../../services/center-panel-buttons.service';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'proof-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DescriptionComponent implements OnInit {
  public descriptionButtons: IDescriptionButtons = JSON.parse(JSON.stringify(DESCRIPTION_BUTTONS_TYPES));
  @Input() description = '';
  public mentions: string[];
  @Output() saveClicked: EventEmitter<string> = new EventEmitter<string>();
  //we need this so we can save the text on draft annotations
  @Output() textChanged: EventEmitter<string> = new EventEmitter<string>();
  public selectedAnnotation: IAnnotation = null;

  @ViewChild('textArea', { static: true }) textArea: TextareaComponent;

  disabled: boolean = true;

  constructor(private annotationService: AnnotationService,
    private centerPanelButtonsService: CenterPanelButtonsService,
    private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.annotationService.getSelected().subscribe((annotation) => {
      if (annotation) {
        if (annotation.draft) {
          this.annotationService.getDraftAnnotations().value.forEach((v, i, a) => {
            this.textArea.value(v.markup);
            annotation.markup = v.markup;
          });
          //if (this.textArea && this.textArea.value() != '' && this.selectedAnnotation?.draft) annotation.markup = this.textArea.value();
          this.description = annotation.markup;
        }

        if (this.selectedAnnotation == null || this.selectedAnnotation.name != annotation.name) {
          //only overwrite the text is a different annotation was actually selected
          this.description = annotation.markup;
        }

        if (annotation.draft) {
          this.disabled = false;
        }
        else {
          this.disabled = true;
        }
      }
      else {
        //console.log('there was a null annotation selected.');
        if (this.annotationService.getDraftAnnotationCount() == 0) {
          this.description = '';
          this.disabled = true;
        }
      }

      this.selectedAnnotation = annotation;

      setTimeout(() => {
        if (!this.disabled) {
          this.textArea.focus();
        }
      }, 100);

      this.ref.detectChanges();

    });

    this.centerPanelButtonsService.getCentralPanelButtons().pipe(map(buttons => {
      return buttons.garbageCan;
    }), filter(x => x.selected == true))
      .subscribe((e) => {
        this.description = '';
        this.ref.detectChanges();
      });

  }

  onChange(value: string): void {

    console.log('onChange', value)
    this.description = value;

    if ((this.selectedAnnotation?.draft || this.annotationService.getDraftAnnotationCount() > 0) && this.description && this.description != '') {
      this.annotationService.setDrafatComment(this.description);
    }

    this.textChanged.emit(this.description);
  }

  onMention(mentions: string[]): void {
    this.mentions = mentions;
  }

  onClearClick(): void {
    this.description = '';

    //this is going to be cancel so we will want to delete the annotation
    this.annotationService.clearDraftAnnotations();

    this.ref.detectChanges();
  }

  onSaveClick(): void {
    let comment = this.description;

    if (comment == null || comment == "") {
      alert('Please enter a Feedback comment');
      this.textArea.focus();
      return;
    }

    if (this.mentions?.length > 0) {
      //remove the 'delete' mention span from comment before saving to db.
      comment = this.textArea.mentionItem.cleanupMentionTag(comment);
      this.description = comment;
    }

    this.annotationService.createAnotations(this.description, this.mentions);

    this.description = '';
  }
}

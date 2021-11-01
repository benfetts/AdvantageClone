import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { filter } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { ActiveFileService } from '../../../../services/active-file.service';
import { AnnotationService } from '../../../../services/annotation.service';
import { CenterPanelButtonsService } from '../../../../services/center-panel-buttons.service';
import { FeedbackService } from '../../../../services/feedback.service';
import { IAnnotation } from '../../../../shared/Models/Annotation';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';

declare var kendo: any;

@Component({
  selector: 'markup-comment-view',
  templateUrl: './comment-view.component.html',
  styleUrls: ['./comment-view.component.scss']
})
export class CommentViewComponent implements OnInit {

  public feedback: IFeedback[];
  private newFile: boolean = false;
  private shortCircut = false;
  public newComment: boolean = false;
  private documentID: number = 0;

  @ViewChild('myEditor', { static: false }) editor: ElementRef;
  @ViewChild('myMention', { static: false }) mentionItem: MentionItemComponent;

  constructor(private feedbackService: FeedbackService,
    private annotationService: AnnotationService,
    private activeFileService: ActiveFileService,
    private ref: ChangeDetectorRef) { }

  mergeByProperty(target, source, prop) : void {
    source.forEach(sourceElement => {
      let targetElement = target.find(targetElement => {
        return sourceElement[prop] === targetElement[prop];
      })
      targetElement ? Object.assign(targetElement, sourceElement) : target.push({ ...sourceElement, expanded: true });
    })
  }


  ngOnInit(): void {
    this.feedbackService.getFeedBack().subscribe(feedback => {
      //console.log(feedback);

      if (this.newFile == true) {
        this.feedback = null;
        this.newFile = false;
      }

      if (this.feedback == null) {
        this.feedback = feedback.map(obj => ({ ...obj, expanded: true }));
      }
      else {
        this.mergeByProperty(this.feedback, feedback, 'commentId');
      }

      this.ref.detectChanges();
    });

    this.activeFileService.getDocument().pipe(filter(x => x != null)).subscribe((document) => {
      this.newFile = true;
      this.documentID = document.documentId;
    });

    this.annotationService.getSelected().pipe(filter(x => x != null)).subscribe((annotation) => {
      if (!this.shortCircut) {
        this.feedback.forEach((v, i, a) => {
          if (annotation.commentId == v.commentId) {
            a[i].active = true;
          }
          else {
            a[i].active = false;
          }
        });
        this.ref.detectChanges();
      }
      else {
        this.shortCircut = false;
      }

      var result = document.getElementsByClassName("active");
      result[0].scrollIntoView();

    });

  }

  markUpclicked(index: number): void {

    this.feedback.forEach((v, i, a) => {
      a[i].active = false;
    })

    this.feedback[index].active = true;

    var markupId = this.feedback[index]?.markupId
    if (markupId != null) {
      this.shortCircut = true;
      this.annotationService.setSelectedById(markupId)
    }
  }

  addComment() {
    this.newComment = !this.newComment;
    this.ref.detectChanges();

    setTimeout(() => {
      this.createCommentEditor(-1);
    }, 50);

    //setTimeout(() => {
    //  if (this.editor) {
    //    kendo.jQuery(this.editor.nativeElement).data("kendoEditor").focus();
    //  }
    //}, 50);

  }

  createCommentEditor(commentId) {

    console.log('createCommentEditor', this.editor.nativeElement);
    kendo.jQuery(this.editor.nativeElement).kendoEditor({
      value: "",
      change: function (e) {
        //me.textChanged(this.value());
      },
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        if (e.key == "Enter") {
          //e.stopPropogation();
          let me = this;
          e.preventDefault();
          console.log(e);
          this.onChange(e, commentId);
          return false;
        }

        this.mentionItem.commentKeyDown(e);
      },
      placeholder: "Write a reply here..."
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();

    setTimeout(() => {
      this.editor.nativeElement.focus();
    }, 200);
  }

  onChange(event: any, commentId) {
    let editor = kendo.jQuery("#editor").data("kendoEditor");
    let editorComment = editor.value();

    console.log(editorComment);
    editorComment = this.mentionItem.cleanupMentionTag(editorComment);
    console.log(editorComment);

    this.annotationService.createComment(editorComment, this.documentID ,this.mentionItem.mentions);

    this.newComment = !this.newComment;

      this.ref.detectChanges();
  }
}

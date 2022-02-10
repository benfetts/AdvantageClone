import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { filter } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { ActiveFileService } from '../../../../services/active-file.service';
import { AnnotationService } from '../../../../services/annotation.service';
import { FeedbackService } from '../../../../services/feedback.service';
import '@progress/kendo-ui';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';
import { IDocument } from '../../../../interfaces/document';
import { DocumentVersionService } from '../../../../services/document-version.service';
import { HtmlUtilites } from '../../../../../../utils/html-utilities';
import { DocumentListService } from '../../../../services/document-list.service';
import { ComparisonAnnotationService } from '../../../../services/comparison-annotation.service';

declare var kendo: any;

@Component({
  selector: 'markup-comment-view',
  templateUrl: './comment-view.component.html',
  styleUrls: ['./comment-view.component.scss']
})
export class CommentViewComponent implements OnInit {
  private isNewFile = false;
  private shortCircut = false;
  private documentID: number = 0;
  public document: IDocument = null;
  public nameVersion: string = '';
  private documentList: IDocument[];

  public feedback: IFeedback[];
  public dialogPrimaryButtonText = 'Add';
  public dialogOpened = false;

  public get sortedFeedback() : IFeedback[] {
    return this.feedback != null ? this.feedback.sort((a, b) => b.commentId - a.commentId) : this.feedback;
  }

  @ViewChild('myEditor', { static: true }) editor: ElementRef;
  @ViewChild('myEditorDialogEditor', { static: false }) editorDialogEditor: ElementRef;
  @ViewChild('myMention', { static: true }) mentionItem: MentionItemComponent;
  @ViewChild('myEditorDialogMention', { static: false }) editorDialogMentionItem: MentionItemComponent;

  constructor(private feedbackService: FeedbackService,
    private annotationService: AnnotationService,
    private comparisonAnnotationService: ComparisonAnnotationService,
    private activeFileService: ActiveFileService,
    private documentListservice: DocumentListService,
    private documentVersionService: DocumentVersionService,
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
      if (this.isNewFile == true) {
        this.feedback = null;
        this.isNewFile = false;
      }
      this.feedback = feedback.map(obj => ({ ...obj, expanded: true }));
      if (this.feedback && this.feedback.length > 0) {
        this.documentID = this.feedback[0].documentId;
      }
      this.documentVersionService.getVersion(this.feedback[0].documentId).subscribe((version) => {
        if (this.documentList) {
          this.documentList.forEach((v, i, a) => {
            if (this.feedback[0].documentId == v.documentId) {
              this.nameVersion = v.filename + ' - Version ' + version;
            }
          });
        }
        this.ref.detectChanges();
      });
      this.ref.detectChanges();
    });

    this.documentListservice.getDocuments().subscribe((documentList: IDocument[]) => {
      this.documentList = documentList;
    });

    this.activeFileService.getDocument().pipe(filter(x => x != null)).subscribe((document : IDocument) => {
      this.isNewFile = true;
      this.document = document;
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
        const result = document.getElementsByClassName("active");
        if (result[0]) {
          result[0].scrollIntoView();
        }
      }
      else {
        this.shortCircut = false;
      }
    });

    this.comparisonAnnotationService.getSelected().pipe(filter(x => x != null)).subscribe((annotation) => {
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
        const result = document.getElementsByClassName("active");
        if (result[0]) {
          result[0].scrollIntoView();
        }
      }
      else {
        this.shortCircut = false;
      }
    });

    this.createCommentEditor();
  }

  markUpclicked(index: number): void {
    this.feedback.forEach((v, i, a) => {
      a[i].active = false;
    })
    this.feedback[index].active = true;
    var markupId = this.feedback[index]?.markupId
    if (markupId != null) {
      this.shortCircut = true;
      if (!this.annotationService.setSelectedById(markupId)) {
        this.comparisonAnnotationService.setSelectedById(markupId);
      }
    }
  }

  createCommentEditor() {
    kendo.jQuery(this.editor.nativeElement).kendoEditor({
      value: "",
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        this.mentionItem.commentKeyDown(e);
      },
      placeholder: "Add a comment here..."
    });
    kendo.jQuery("#editorDiv .k-editor-toolbar-wrap").hide();
    setTimeout(() => {
      this.editor.nativeElement.focus();
    }, 200);
  }

  showFullScreenComment() {
    //If the user types in the on screen editor then clicks enlarge, it will copy
    //the text to the dialog.
    const onScreenEditor = kendo.jQuery("#editor").data("kendoEditor");
    this.dialogOpened = true;
    this.ref.detectChanges();
    this.editorDialogMentionItem.mentions = this.mentionItem.mentions;
    kendo.jQuery(this.editorDialogEditor.nativeElement).kendoEditor({
      value: onScreenEditor.value(),
      tools: [
        {
            name: 'bold'
        },
        {
            name: 'italic'
        },
        {
            name: 'underline'
        },
        {
            name: 'strikethrough'
        },
        {
            name: 'customundo',
            tooltip: 'Undo',
            exec: function (e) {
                const editor = kendo.jQuery("#editorDialogEditor").data("kendoEditor");
                editor.exec('undo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-button k-tool" unselectable="on" title="Undo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-undo" tabindex= "-1" ></span><span class="k-tool-text" tabindex="-1">Undo Changes</span></a>'
        },
        {
            name: 'customredo',
            tooltip: 'Redo',
            exec: function (e) {
              const editor = kendo.jQuery("#editorDialogEditor").data("kendoEditor");
                editor.exec('redo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-button k-tool" unselectable="on" title="Redo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-redo" tabindex= "-1" ></span><span class="k-tool-text" tabindex="-1">Redo Changes</span></a>'
        },
        {
            name: 'createLink'
        },
        {
            name: 'unlink'
        },
        {
            name: 'indent'
        },
        {
            name: 'outdent'
        },
        {
            name: 'insertUnorderedList'
        },
        {
            name: 'insertOrderedList'
        }
      ],
      keydown: (e) => {
        this.editorDialogMentionItem.commentKeyDown(e);
      }
    });
    onScreenEditor.value('');
    setTimeout(() => {
      this.editorDialogEditor.nativeElement.focus();
    }, 200);
  }

  createComment() {
    const editor = kendo.jQuery("#editor").data("kendoEditor");
    let editorComment = editor.value();

    if (!HtmlUtilites.isEmptyHtml(editorComment)) {
      editorComment = this.mentionItem.cleanupMentionTag(editorComment);
      this.annotationService.createComment(editorComment, this.documentID ,this.mentionItem.mentions);
      this.ref.detectChanges();
    }

    editor.value('');
    this.mentionItem.mentions = [];
    this.editorDialogMentionItem.mentions = [];
  }

  closeEditorDialog() {
    this.dialogOpened = false;
    this.mentionItem.mentions = [];
    this.editorDialogMentionItem.mentions = [];
 }

  onSaveClick() {
    const editor = kendo.jQuery("#editorDialogEditor").data("kendoEditor");
    let editorComment = editor.value();

    if (!HtmlUtilites.isEmptyHtml(editorComment)) {
      editorComment = this.editorDialogMentionItem.cleanupMentionTag(editorComment);
      this.annotationService.createComment(editorComment, this.documentID, this.editorDialogMentionItem.mentions);
    }

    editor.value('');
    this.mentionItem.mentions = [];
    this.editorDialogMentionItem.mentions = [];
    this.ref.detectChanges();
    this.closeEditorDialog();
  }

  onCancelClick() {
    this.closeEditorDialog();
  }
}

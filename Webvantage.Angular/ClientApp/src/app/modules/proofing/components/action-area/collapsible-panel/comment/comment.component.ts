import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { filter, map } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { CenterPanelButtonsService } from '../../../../services/center-panel-buttons.service';
import { FeedbackService } from '../../../../services/feedback.service';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';
import { HtmlUtilites } from '../../../../../../utils/html-utilities';

declare var kendo: any;
@Component({
  selector: 'markup-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CommentComponent implements OnInit {
  public dialogOpened = false;
  public dialogPrimaryButtonText = 'Save';

  @Input() public feedback: any;

  @ViewChild('myEditor', { static: false }) editor: ElementRef;
  @ViewChild('myEditorDialogEditor', { static: false }) editorDialogEditor: ElementRef;
  @ViewChild('myReply1Mention', { static: false }) mentionItem: MentionItemComponent;
  @ViewChild('myDialogMention', { static: false }) dialogMentionItem: MentionItemComponent;

  reply: boolean = false;
  edit_comment: boolean = false;

  dl: string;
  markerToolButton: boolean = false;

  constructor(private feedbackService: FeedbackService,
    private ref: ChangeDetectorRef,
    private centerPanelButtonsService: CenterPanelButtonsService,
    private activatedRouter: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });

    this.centerPanelButtonsService.getCentralPanelButtons()
      .pipe(map(buttons => buttons.markerTool)).subscribe((b) => {
        this.markerToolButton = b.selected;
        this.ref.detectChanges();
      });
  }

  toggleReplyTextarea(event, commentId) {
    event.stopPropagation();
    this.reply = !this.reply;
    if (this.reply) {
      setTimeout(() => {
        this.createReplyEditor(commentId);
      }, 50);

      this.ref.detectChanges();

      setTimeout(() => {
        if (this.editor) {
          kendo.jQuery(this.editor.nativeElement).data("kendoEditor").focus();
        }
      }, 50);
    }
    else {
      this.ref.detectChanges();
    }
  }

  showFullScreenComment(event, commentId) {
    event.stopPropagation();
    this.reply = false; //close any replies that might be open.
    this.dialogOpened = true;
    this.ref.detectChanges();

    kendo.jQuery(this.editorDialogEditor.nativeElement).kendoEditor({
      value: this.feedback.comment,
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
                const editor = kendo.jQuery("#editorDialogEditor2").data("kendoEditor");
                editor.exec('undo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-button k-tool" unselectable="on" title="Undo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-undo" tabindex= "-1" ></span><span class="k-tool-text" tabindex="-1">Undo Changes</span></a>'
        },
        {
            name: 'customredo',
            tooltip: 'Redo',
            exec: function (e) {
              const editor = kendo.jQuery("#editorDialogEditor2").data("kendoEditor");
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
        this.dialogMentionItem.commentKeyDown(e);
      }
    });
    this.ref.detectChanges();
    setTimeout(() => {
      this.editorDialogEditor.nativeElement.focus();
    }, 200);
  }

  closeEditorDialog() {
    this.dialogOpened = false;
    this.ref.detectChanges();
  }

  onSaveClick(e: any, commentId: string) {
    e.stopPropagation();
    this.updateComment(e, commentId);
    this.closeEditorDialog();
  }

  onCancelClick() {
    this.closeEditorDialog();
  }

  createReplyEditor(commentId) {
    kendo.jQuery("textarea#editor-" + commentId).kendoEditor({
      value: "",
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        if (e.key == "Enter") {
          let me = this;
          e.preventDefault();
          e.stopPropagation();
          this.createReply(e, commentId);
          return false;
        }

        this.mentionItem.commentKeyDown(e);
      },
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();
  }

  updateComment(event: any, commentId) {
    const editor = kendo.jQuery("#editorDialogEditor2").data("kendoEditor");
    let editorComment = editor.value();
    editorComment = this.dialogMentionItem.cleanupMentionTag(editorComment);

    var comment: IFeedback = {
      alertId: this.feedback.alertId,
      alertStateId: this.feedback.alertStateId,
      alrtNotifyHdrId: this.feedback.alrtNotifyHdrId,
      assignedEmpCode: this.feedback.assignedEmpCode,
      boardColId: this.feedback.boardColId,
      boardDtlId: this.feedback.boardDtlId,
      boardHdrId: this.feedback.boardHdrId,
      boardId: this.feedback.boardId,
      comment: editorComment,
      commentId: this.feedback.commentId,
      csCommentId: this.feedback.csCommentId,
      csProjectId: this.feedback.csProjectId,
      csReplyId: this.feedback.csReplyId,
      csReviewId: this.feedback.csReviewId,
      custodyEnd: this.feedback.custodyEnd,
      custodyStart: this.feedback.custodyStart,
      documentId: this.feedback.documentId,
      emailsent: false,
      generatedDate: null,
      isDraft: false,
      isSystem: false,
      parentId: this.feedback.parentId,
      userCode: this.feedback.userCode,
      userCodeCp: this.feedback.userCodeCp,
      vcCode: this.feedback.vcCode,
      vrCode: this.feedback.vrCode,
      flagChecked: false,
      mentions: this.dialogMentionItem.mentions,
      active: false,
      isMyComment: true
    };
    this.feedbackService.updateFeedback(comment);
    this.edit_comment = !this.edit_comment;
    editor.value('');
    this.dialogMentionItem.mentions = [];
    this.ref.detectChanges();
  }

  createReply(event: any, commentId) {
    let editor = kendo.jQuery("textarea#editor-" + commentId).data("kendoEditor");
    let editorComment = editor.value();
    this.reply = false;

    if (!HtmlUtilites.isEmptyHtml(editorComment)) {
      editorComment = this.mentionItem.cleanupMentionTag(editorComment);
      var comment: IFeedback = {
        alertId: this.feedback.alertId,
        alertStateId: this.feedback.alertStateId,
        alrtNotifyHdrId: this.feedback.alrtNotifyHdrId,
        assignedEmpCode: this.feedback.assignedEmpCode,
        boardColId: this.feedback.boardColId,
        boardDtlId: this.feedback.boardDtlId,
        boardHdrId: this.feedback.boardHdrId,
        boardId: this.feedback.boardId,
        comment: editorComment,
        commentId: -1,
        csCommentId: this.feedback.csCommentId,
        csProjectId: this.feedback.csProjectId,
        csReplyId: this.feedback.csReplyId,
        csReviewId: this.feedback.csReviewId,
        custodyEnd: this.feedback.custodyEnd,
        custodyStart: this.feedback.custodyStart,
        documentId: this.feedback.documentId,
        emailsent: false,
        generatedDate: null,
        isDraft: false,
        isSystem: false,
        parentId: this.feedback.commentId,
        userCode: this.feedback.userCode,
        userCodeCp: this.feedback.userCodeCp,
        vcCode: this.feedback.vcCode,
        vrCode: this.feedback.vrCode,
        flagChecked: false,
        mentions: this.mentionItem.mentions,
        active: false,
        isMyComment: true
      };
      this.feedbackService.createFeedback(comment);
    }

    this.ref.detectChanges();
  }

  getEmployeeCode(feedback) {
    if (feedback.proofingXReviwerId == null || feedback.proofingXReviwerId <= 0) {
      return feedback.userCode;
    }
    var init = (fullname => fullname.map((n, i) => (i == 0 || i == fullname.length - 2) && n[0]).filter(n => n).join(""))(feedback.employeeFullName.split(" "));
    return 'ExternalReviewer:' + init;
  }

  getEmployeeInit(feedback) {
    var init = (fullname => fullname.map((n, i) => (i == 0 || i == fullname.length - 2) && n[0]).filter(n => n).join(""))(feedback.employeeFullName.split(" "));
    return init;
  }

  isExternal(feedback: IFeedback): boolean {
    return (feedback.proofingXReviwerId != null && feedback.proofingXReviwerId > 0);
  }

  ngAfterViewInit() {

  }
}

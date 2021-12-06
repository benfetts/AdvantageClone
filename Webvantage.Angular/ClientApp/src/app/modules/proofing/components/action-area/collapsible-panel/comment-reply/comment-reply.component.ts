import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { FeedbackService } from '../../../../services/feedback.service';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';

declare var kendo: any;

@Component({
  selector: 'markup-comment-reply',
  templateUrl: './comment-reply.component.html',
  styleUrls: ['./comment-reply.component.scss']
})
export class CommentReplyComponent implements OnInit {

  @Input() public feedback: IFeedback;
  @ViewChild('myEditor', { static: true }) editor: ElementRef;
  @ViewChild('myMention', { static: true }) mentionItem: MentionItemComponent;

  reply: boolean = false;

  dl: string;
  //mentions: string[] = null;

  constructor(private ref: ChangeDetectorRef,
    private feedbackService: FeedbackService,
    private activatedRouter: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });
    this.createReplyEditor(this.feedback.commentId);
  }

  showHideReplyTextarea(event, commentId) {
    event.stopPropagation();

    this.reply = !this.reply;

    this.ref.detectChanges();

    setTimeout(() => {
      if (this.editor) {
        kendo.jQuery(this.editor.nativeElement).data("kendoEditor").focus();
      }
    }, 50);
  }

  createReplyEditor(commentId) {
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
          this.onChange(e, commentId);
          return false;
        }

        this.mentionItem.commentKeyDown(e);
      },
      placeholder: "Write a reply here..."
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();

    setTimeout(() => {
      kendo.jQuery(this.editor.nativeElement).css("height","30px")
      this.editor.nativeElement.focus();
    }, 200);
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

  onChange(event: any, commentId) {
    let editor = kendo.jQuery("textarea[editor-data='" + commentId + "']").data("kendoEditor");
    let editorComment = editor.value();

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
      active: false
    };

    this.feedbackService.createFeedback(comment);

    this.reply = !this.reply;
    this.ref.detectChanges();
  }
}


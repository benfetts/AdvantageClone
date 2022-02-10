import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { FeedbackService } from '../../../../services/feedback.service';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { HtmlUtilites } from '../../../../../../utils/html-utilities';
declare var kendo: any;

@Component({
  selector: 'markup-comment-reply',
  templateUrl: './comment-reply.component.html',
  styleUrls: ['./comment-reply.component.scss']
})
export class CommentReplyComponent implements OnInit {

  @Input() public feedback: IFeedback;
  @ViewChild('myReplyEditor', { static: false }) replyEditor: ElementRef;
  @ViewChild('myReply2ReplyCreate', { static: false }) reply2ReplyCreate: ElementRef;
  @ViewChild('myReply2ReplyEditor', { static: false }) reply2ReplyEditor: ElementRef;
  @ViewChild('myReplyEditorMention', { static: false }) replyEditorMention: MentionItemComponent;
  @ViewChild('myReply2ReplyCreateMention', { static: false }) reply2ReplyCreateMention: MentionItemComponent;
  @ViewChild('myReply2ReplyEditorMention', { static: false }) reply2ReplyEditorMention: MentionItemComponent;

  showReplyEditor: boolean = false;
  showReply2ReplyCreate: boolean = false;
  showReply2ReplyEditor: boolean = false;
  reply_comment_id: number = 0;

  dl: string;

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
  }

  //create reply

  toggleReply2ReplyCreate(event, commentId) {
    event.stopPropagation();
    this.showReply2ReplyCreate = !this.showReply2ReplyCreate;
    if (this.showReply2ReplyCreate) {
      setTimeout(() => {
        this.createReply2ReplyCreate(commentId);
      }, 50);

      this.showReply2ReplyEditor = false;
      this.showReplyEditor = false;
      this.ref.detectChanges();

      setTimeout(() => {
        if (this.reply2ReplyCreate) {
          kendo.jQuery(this.reply2ReplyCreate.nativeElement).data("kendoEditor").focus();
        }
      }, 50);
    }
    else {
      this.ref.detectChanges();
    }
  }

  createReply2ReplyCreate(commentId) {
    kendo.jQuery(this.reply2ReplyCreate.nativeElement).kendoEditor({
      value: "",
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        if (e.key == "Enter") {
          let me = this;
          e.preventDefault();
          this.createReply2Reply(e, commentId);
          return false;
        }

        this.reply2ReplyCreateMention.commentKeyDown(e);
      },
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();
  }


  createReply2Reply(event: any, commentId) {
    let editor = kendo.jQuery(`#reply2ReplyCreate-${commentId}`).data("kendoEditor");
    let editorComment = editor.value();

    console.log(this.feedback);

    if (!HtmlUtilites.isEmptyHtml(editorComment)) {
      editorComment = this.reply2ReplyCreateMention.cleanupMentionTag(editorComment);
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
        mentions: this.reply2ReplyCreateMention.mentions,
        active: false,
        isMyComment: true
      };

      this.feedbackService.createFeedback(comment);
    }

    this.showReply2ReplyCreate = false;
    this.ref.detectChanges();
  }


  //edit reply
  toggleReplyEditor(event, commentId) {
    event.stopPropagation();
    this.showReplyEditor = !this.showReplyEditor;
    if (this.showReplyEditor) {
      setTimeout(() => {
        this.createReplyEditor(commentId);
      }, 50);

      this.showReply2ReplyEditor = false;
      this.showReply2ReplyCreate = false;
      this.ref.detectChanges();
    }
    else {
      this.ref.detectChanges();
    }
  }

  toggleReply2ReplyEditor(event, commentId) {
    event.stopPropagation();
    this.reply_comment_id = commentId;
    this.showReply2ReplyEditor = !this.showReply2ReplyEditor;
    if (this.showReply2ReplyEditor) {
      setTimeout(() => {
        this.createReply2ReplyEditor(commentId);
      }, 50);

      this.showReply2ReplyCreate = false;
      this.showReplyEditor = false;
      this.ref.detectChanges();
    }
    else {
      this.ref.detectChanges();
    }
  }

  createReplyEditor(commentId) {
    kendo.jQuery(this.replyEditor.nativeElement).kendoEditor({
      value: "",
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        if (e.key == "Enter") {
          let me = this;
          e.preventDefault();
          this.updateReply(e, commentId);
          return false;
        }
        this.replyEditorMention.commentKeyDown(e);
      },
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();
  }

  updateReply(event: any, commentId) {
    let editor = kendo.jQuery(`#replyEditor-${commentId}`).data("kendoEditor");
    let editorComment = editor.value();
    editorComment = this.replyEditorMention.cleanupMentionTag(editorComment);

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
      mentions: this.replyEditorMention.mentions,
      active: false,
      isMyComment: true
    };
    this.feedbackService.updateFeedback(comment);
    this.showReplyEditor = false;
    this.ref.detectChanges();
  }


  createReply2ReplyEditor(commentId) {
    kendo.jQuery(this.reply2ReplyEditor.nativeElement).kendoEditor({
      value: "",
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        if (e.key == "Enter") {
          let me = this;
          e.preventDefault();
          this.updateReply2Reply(e, commentId);
          return false;
        }

        this.reply2ReplyEditorMention.commentKeyDown(e);
      },
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();
  }

  updateReply2Reply(event: any, commentId) {
    let editor = kendo.jQuery(`#reply2ReplyEditor-${commentId}`).data("kendoEditor");
    let editorComment = editor.value();
    editorComment = this.reply2ReplyEditorMention.cleanupMentionTag(editorComment);
    var feedback = this.feedback.replies.find((v) => v.commentId == commentId);

    var comment: IFeedback = {
      alertId: feedback.alertId,
      alertStateId: feedback.alertStateId,
      alrtNotifyHdrId: feedback.alrtNotifyHdrId,
      assignedEmpCode: feedback.assignedEmpCode,
      boardColId: feedback.boardColId,
      boardDtlId: feedback.boardDtlId,
      boardHdrId: feedback.boardHdrId,
      boardId: feedback.boardId,
      comment: editorComment,
      commentId: feedback.commentId,
      csCommentId: feedback.csCommentId,
      csProjectId: feedback.csProjectId,
      csReplyId: feedback.csReplyId,
      csReviewId: feedback.csReviewId,
      custodyEnd: feedback.custodyEnd,
      custodyStart: feedback.custodyStart,
      documentId: feedback.documentId,
      emailsent: false,
      generatedDate: null,
      isDraft: false,
      isSystem: false,
      parentId: feedback.parentId,
      userCode: feedback.userCode,
      userCodeCp: feedback.userCodeCp,
      vcCode: feedback.vcCode,
      vrCode: feedback.vrCode,
      flagChecked: false,
      mentions: this.reply2ReplyEditorMention.mentions,
      active: false,
      isMyComment: true
    };
    this.feedbackService.updateFeedback(comment);
    this.showReply2ReplyEditor = false;
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
}


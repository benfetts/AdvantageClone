import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Key } from 'protractor';
import { filter, map } from 'rxjs/operators';
import { IFeedback } from '../../../../interfaces/feedback';
import { BottomPanelButtonsService } from '../../../../services/bottom-panel-buttons.service';
import { CenterPanelButtonsService } from '../../../../services/center-panel-buttons.service';
import { FeedbackService } from '../../../../services/feedback.service';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { MentionItemComponent } from '../../../../shared/components/mention-item/mention-item.component';

declare var kendo: any;

@Component({
  selector: 'markup-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CommentComponent implements OnInit {

  @Input() public feedback: any;

  //@ViewChild('replyInput', { static: false }) myInput: ElementRef;
  @ViewChild('myEditor', { static: false }) editor: ElementRef;
  @ViewChild('myMention', { static: false }) mentionItem: MentionItemComponent;

  reply: boolean = false;  

  dl: string;
  markerToolButton: boolean = false;
  //mentions: string[] = null;

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

    //this.markerToolButton = 

    this.centerPanelButtonsService.getCentralPanelButtons()
      .pipe(map(buttons => buttons.markerTool)).subscribe((b) => {
        this.markerToolButton = b.selected;
        this.ref.detectChanges();
      });
  }

  showHideReplyTextarea(event, commentId) {
    event.stopPropagation();

    setTimeout(() => {      
      this.createReplyEditor(commentId);
    }, 50);
    
    this.reply = !this.reply;

    this.ref.detectChanges();    

  //  setTimeout(() => {
  //    if (this.editor) {
  //      kendo.jQuery(this.editor.nativeElement).data("kendoEditor").focus();
  //    }
  //  }, 50);
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
    console.log(event);
    console.log(commentId);
    let editor = kendo.jQuery("textarea[editor-data='" + commentId + "']").data("kendoEditor");
    let editorComment = editor.value();

    console.log(editorComment);
    editorComment = this.mentionItem.cleanupMentionTag(editorComment);
    console.log(editorComment);    

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

  replyLevel2(event, feedback) {
    console.log(event, feedback);
  }

  getEmployeeCode(feedback) {
    if (feedback.proofingXReviwerId == null || feedback.proofingXReviwerId <= 0) {
      return feedback.userCode;
    }

   
    var init = (fullname => fullname.map((n, i) => (i == 0 || i == fullname.length - 2) && n[0]).filter(n => n).join(""))(feedback.employeeFullName.split(" "));

    return 'ExternalReviewer:' + init;
  }

  getEmployeeInit(feedback) {
    //console.log(feedback);
    //if (feedback.proofingXReviwerId == null || feedback.proofingXReviwerId <= 0) {
    //  return feedback.userCode;
    //}

    var init = (fullname => fullname.map((n, i) => (i == 0 || i == fullname.length - 2) && n[0]).filter(n => n).join(""))(feedback.employeeFullName.split(" "));

    return init;
  }

  isExternal(feedback: IFeedback): boolean {
    return (feedback.proofingXReviwerId != null && feedback.proofingXReviwerId > 0);
  }

  ngAfterViewInit() {    

  }
}

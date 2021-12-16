import { containerless, bindable, inject } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { AlertService } from 'services/desktop/alert-service';
import { MentionItem } from './mention-item';

@containerless
@inject(AlertService)
export class Comment extends ModuleBase {

    service: AlertService;
    @bindable employeeCode: string;
    @bindable employeeFullName: string;
    @bindable generatedDate: Date;
    @bindable custodyStartDate: Date;
    @bindable custodyEndDate: Date;
    @bindable comment: string;
    @bindable shortComment: string;
    @bindable isTruncated: boolean;
    @bindable documentList: Array<any>;
    @bindable alertId: number;
    @bindable commentId: number;
    @bindable openReply;
    @bindable refreshList;
    @bindable replyText: string;
    @bindable replyLevel: number;
    fullScreen: boolean = false;
    commentRef: HTMLDivElement;
    document: HTMLDocument;
    @bindable replyList: Array<any>;
    @bindable showReplyTextbox: boolean = false;
    @bindable focusReplyInput: boolean;
    mentionReplyInputComment: MentionItem;
    @bindable hasImage: boolean;
    @bindable proofingExternalReviewerID: number;
    @bindable initials: string;
    @bindable isMyComment: boolean = false;
    @bindable editFunction;
    reply() {
        let element = $("#replyInputComment");        
        if (element.length) {
            this.replyText = element[0].innerHTML;

            this.replyText = this.mentionReplyInputComment.cleanupMentionTag(this.replyText);
        }
        


        if (this.replyText && this.replyText.trim().length > 0) {
            this.showProgress(true);
            //this.service.addAlertComment(this.alertId, this.commentId, this.replyText, null, false, false, null, this.mentionReplyInputComment.mentions)
            this.service.addAlertComment(this.alertId, this.commentId, this.replyText.trim(), null, false, false, null)
                .then(response => {
                    this.showProgress(false);
                    this.replyText = "";
                    this.refreshList();
                    this.showReplyTextbox = false;
                });
        } else {
            this.alert("Please enter a reply.");
        }
    }
    editComment() {
        console.log("edit", this.alertId, this.commentId);
        this.editFunction();
    }
    showHideReplyTextarea() {
        this.showReplyTextbox = !this.showReplyTextbox;
        if (this.showReplyTextbox == true) {
            this.focusReplyInput = true;
        }
    }
    saveReplyOnEnter(e) {
        if (e && e.keyCode && e.keyCode === 13) {                        
            this.reply();
        }
    }

    getDocument(doc: any) {
        if (doc) {
            wvbridge.GetDocumentRepositoryDocument(doc.ID);
        }
    }
    openLink(doc: any) {
        if (doc) {
            let thisLink: string = "";
            if (doc.Link.indexOf("http://") == -1 && doc.Link.indexOf("https://") == -1) {
                thisLink = "http://" + doc.Link;
            } else {
                thisLink = doc.Link;
            }
            if (thisLink && thisLink.trim() != "") {
                window.open(thisLink, "_blank");
            }
        }
    }

    copyCommentToClipboard() {
        var commentDiv = null;
        commentDiv = this.commentRef;
        window.getSelection().removeAllRanges();
        var range = null;
        range = document.createRange();
        range.selectNode(commentDiv);
        window.getSelection().addRange(range);
        document.execCommand("copy");
        window.getSelection().removeAllRanges();
        return false;
    }
    toggleFullscreen() {
        this.fullScreen = !this.fullScreen;
        if (this.fullScreen) {
            $(document.body).css('overflow', 'hidden');
        } else {
            $(document.body).css('overflow', 'auto');
        }
    }

    constructor(service: AlertService) {
        super();
        this.service = service;

    }


}

import { inject, bindable } from 'aurelia-framework';
import { AlertService } from 'services/desktop/alert-service';
import { ModuleBase } from 'modules/base/module-base';
import { responseTypeTransformer } from 'aurelia-http-client';
import { MentionItem } from './mention-item';

@inject(AlertService)
export class CommentView extends ModuleBase {

    service: AlertService;
    @bindable hideSystemComments: boolean = null;
    @bindable alertId: number;
    @bindable commentId: number;
    comments: Array<any>;
    commentScrollWindow: HTMLElement;
    newCommentInput: kendo.ui.Editor;
    @bindable cssClass: string;
    fullScreenComment: kendo.ui.Editor;
    attachmentUpload: kendo.ui.Upload;
    uploadProgressBar: kendo.ui.ProgressBar;
    uploadToDocumentManager: boolean = false;
    commentDialogOpen: boolean = false;
    uploadToProofHQ: boolean = false;
    uploadCurrentFileName: string = "";
    files: Array<any> = [];
    fileNames: Array<any> = [];
    links: Array<any> = [];    
    @bindable commentAddedCallback: Function;
    commentDialog: kendo.ui.Dialog;
    commentDialogActions: Array<any>;
    mentionItemFull: MentionItem;
    mentionItemNew: MentionItem;
    @bindable isProof: boolean = false;
    //mentionAutoComplete: kendo.ui.DropDownList;
    //fullScreenMentionAutoComplete: kendo.ui.DropDownList;
    //mentionEmployeeDataSource: kendo.data.DataSource;
    @bindable documentId: number = 0;

    defaultTools: Array<kendo.ui.EditorTool> = [
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
            name: 'justifyLeft'
        },
        {
            name: 'justifyCenter'
        },
        {
            name: 'justifyRight'
        },
        {
            name: 'justifyFull'
        },
        {
            name: 'foreColor'
        },
        {
            name: 'backColor'
        },
        {
            name: 'fontName'
        },
        {
            name: 'fontSize'
        },
        {
            name: 'customundo',
            tooltip: 'Undo',
            exec: function (e) {
                var editor = $(this).data('kendoEditor');
                editor.exec('undo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-tool" unselectable="on" title="Undo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-undo" tabindex= "-1" ></span><span class="k-tool-text" tabindex="-1">Undo Changes</span></a>'
        },
        {
            name: 'customredo',
            tooltip: 'Redo',
            exec: function (e) {
                var editor = $(this).data('kendoEditor');
                editor.exec('redo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-tool" unselectable="on" title="Redo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-redo" tabindex= "-1" ></span><span class="k-tool-text" tabindex="-1">Redo Changes</span></a>'
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
    ];
    @bindable AllowProofHQ: boolean = false;
    @bindable dialogTitle: string;
    @bindable fullScreenType: number = 0;
    @bindable saveButtonText: string = "Add";
    @bindable isUploadingFile: boolean = true;
    @bindable uploadingFilePrimary: string = "k-primary";
    @bindable uploadingLinkPrimary: string = "";
    @bindable urlTitle: string;
    @bindable urlLink: string;
    @bindable progressValue: number = 0;
    focusLinkTitle: boolean = false;
    focusLinkURL: boolean = false;
    focusUploadFileButton: boolean = false;
    onUploadCount: number = 0;
    uploadDoneCount: number = 0;
    saveDisabled: boolean = false;
    @bindable attachmentAdded: boolean = false;
    @bindable isExternalLink: boolean = false;
    @bindable uploadingExternalLinkPrimary: string = "";
    focusExternalLinkTitle: boolean = false;
    @bindable isEdit: boolean = false;
    // methods
    setUploadToLink() {
        this.isUploadingFile = false;
        this.focusUploadFileButton = false;
        this.focusLinkTitle = true;
        this.focusLinkURL = false;
        this.uploadingLinkPrimary = "k-primary";
        this.uploadingFilePrimary = "";
    }
    setUploadToFile() {
        this.isUploadingFile = true;

        this.focusUploadFileButton = true;
        this.focusLinkTitle = false;
        this.focusLinkURL = false;

        this.uploadingLinkPrimary = "";
        this.uploadingFilePrimary = "k-primary";
    }
    uploadLink() {
        this.showProgress(true);
        if (this.urlLink && this.urlLink.trim() != "") {
            if (!this.urlTitle || this.urlTitle.trim() == "") {
                this.urlTitle = this.urlLink;
            }
            //console.log("uploadLink", { Title: this.urlTitle, Link: this.urlLink, UploadDocumentManager: this.uploadToDocumentManager });
            this.links.push({ Title: this.urlTitle, Link: this.urlLink, UploadDocumentManager: this.uploadToDocumentManager });
            this.urlTitle = null;
            this.urlLink = null;
            this.focusLinkTitle = true;
            this.showProgress(false);
        } else {
            this.alert("A URL is required.");
            this.focusLinkURL = true;
            this.showProgress(false);
        }
    }
    deleteLink(link: any) {
        this.links.splice($.inArray(link, this.links), 1);
    }
    keyUpLinkTitle(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.focusLinkURL = true;
        }
    }
    keyUpLinkURL(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.uploadLink();
        }
    }
    alertIdChanged() {
        this.getAlertComments();
    }
    refreshComments() {
        $(".asset-container").removeClass("selected-asset-container");
        this.getAlertComments();
    }
    getAlertComments() {
        let me = this;
        me.attachmentDoneProcessing();
        try {
            if (me.service) {
                me.showProgress(true);
                if (me.hideSystemComments == null || me.hideSystemComments == undefined) {
                    //console.log("hey?")
                    this.service.getAlertSettings().then(response => {
                        if (response.content) {
                            try {
                                me.hideSystemComments = response.content.HideSystemComments;
                            } catch (e) {
                                me.hideSystemComments = false;
                            }
                        } else {
                            me.hideSystemComments = false;
                        }
                        me.service.getAlertComments(me.alertId, me.documentId, me.hideSystemComments).then(response => {
                            me.comments = response.content;
                            if (!me.comments) {
                                me.comments = [];
                            }
                            me.showProgress(false);
                        });
                    }).then(() => {
                    });
                } else {
                    me.service.getAlertComments(me.alertId, me.documentId, me.hideSystemComments).then(response => {
                        me.comments = response.content;
                        //console.log("comments???", response.content)
                        if (!me.comments) {
                            me.comments = [];
                        }
                        me.showProgress(false);
                    });
                }
            }
        } catch (e) {
            me.showProgress(false);
        }
    }
    uploadFileClick() {
        this.onUploadCount = 0;
        this.uploadDoneCount = 0;
        this.showProgress(false);
        this.attachmentDoneProcessing();
        if (this.attachmentUpload) {
            $(this.attachmentUpload.element).click();
        }
    }
    attachmentOnUpload(e) {
        //console.log("attachmentOnUpload");
        this.onUploadCount += 1;
        e.data = {
            AlertID: this.alertId,
            UploadToRepository: this.uploadToDocumentManager,
            UploadToProofHQ: this.uploadToProofHQ
        }
    }
    attachmentUploadSuccess(e) {
        //console.log("attachmentUploadSuccess", this.onUploadCount, this.uploadDoneCount);
        if ((this.onUploadCount - 1 == this.uploadDoneCount) || (this.onUploadCount == 0 && this.uploadDoneCount == 0)) {
            //console.log("attachmentUploadSuccess Done!");
            this.showProgress(false);
            this.syncFiles();
            this.attachmentDoneProcessing();
        } else {
            this.uploadDoneCount += 1;
        }
    }
    attachmentOnError(e) {
        //console.log("attachmentOnError");
        if (this.onUploadCount - 1 == this.uploadDoneCount) {
            this.attachmentDoneProcessing();
        } else {
            if (e.operation == 'upload') {
                this.uploadDoneCount += 1;
                if (e.XMLHttpRequest.responseText) {
                    this.alert(JSON.parse(e.XMLHttpRequest.responseText));
                }
            }
        }
    }
    attachmentOnProcess(e) {
        this.progressValue = e.percentComplete;
        if (this.uploadProgressBar) {
            this.uploadProgressBar.value(this.progressValue);
            this.uploadProgressBar.progressStatus.text(this.getFileInfo(e) + ":  " + this.progressValue + "%");
        }
    }
    attachmentOnRemove(e) {
        //console.log("attachmentOnRemove");
        this.attachmentDoneProcessing()
    }
    attachmentOnCancel(e) {
        //console.log("attachmentOnCancel");
        this.attachmentDoneProcessing()
    }
    attachmentDoneProcessing() {
        try {
            this.progressValue = 0;
            //this.saveDisabled = null;
            this.onUploadCount = 0;
            this.uploadDoneCount = 0;
            this.attachmentAdded = true;
            this.showProgress(false);
            //console.log("attachmentDoneProcessing files?", this.files);
        } catch (e) {
            //console.log("attachmentDoneProcessing", e);
        }
    }
    deleteFile(file: any) {
        this.attachmentUpload.removeFileByUid(file.uid);
        this.attachmentUpload.clearFileByUid(file.uid);
        this.syncFiles();
    }
    syncFiles() {
        let me = this;
        window.setTimeout(() => {
            me.files = [];
            me.fileNames = [];
            if (me.attachmentUpload) {
                for (var i = 0; i < me.attachmentUpload.getFiles().length; i++) {
                    var file = me.attachmentUpload.getFiles()[i];
                    me.files.push({ name: file.name, uid: file.uid });
                    me.fileNames.push(file.name);
                }
            }
            //console.log("syncFiles this.files", this.files);
        }, 250);
    }
    getFileInfo(e) {
        return $.map(e.files, function (file) {
            var info = file.name;
            if (file.size > 0) {
                info += " (" + Math.ceil(file.size / 1024) + " KB)";
            }
            return info;
        }).join(", ");
    }
    showFullScreenComment(fullScreenType: number = 0) {
        let me = this;
        me.fullScreenType = fullScreenType;
        if (me.fullScreenType == 0) {
            me.saveButtonText = "Add";
            me.dialogTitle = "Add Comment";
            me.fullScreenComment.value(me.newCommentInput.value());
            me.isEdit = false;
        } else if (me.fullScreenType == 1) {
            me.saveButtonText = "Update";
            me.dialogTitle = "Edit Comment";
            me.isEdit = true;
        } else {
            me.saveButtonText = "Add";
            me.dialogTitle = "Add Comment";
            me.fullScreenComment.value(me.newCommentInput.value());
            me.isEdit = false;
        }
        me.commentDialog.title(me.dialogTitle);
        me.commentDialog.open();
        me.fullScreenComment.wrapper.width("").height("").addClass("expandEditor");
        me.fullScreenComment.focus();
        me.commentDialogOpen = true;
        if (this.mentionItemNew.mentions.length > 0) {
            this.mentionItemFull.mentions = this.mentionItemNew.mentions;
            this.mentionItemNew.attachClickEventToMention("#fullScreenCommentDiv");
        }
        this.mentionItemFull.removeLineBreaksFromComment();
    }
    onFullScreenCommentDialogClose() {
        this.commentDialogOpen = false;
        this.isEdit = false;
    }
    closeFullScreenComment() {
        this.fullScreenType = 0;
        this.commentId = null;
        this.saveButtonText = "Add";
        this.fullScreenComment.value(null);
        this.clearAttachmentUploadAndSync();
        this.links = [];
        this.setUploadToFile();
    }
    clearAttachmentUploadAndSync() {
        if (this.attachmentUpload) {
            this.attachmentUpload.removeAllFiles();
            this.attachmentUpload.clearAllFiles();
        }
        this.files = [];
        this.fileNames = [];
        this.syncFiles();
    }
    showHideSystemComments() {
        this.showProgress(true);
        this.service.setShowHideSystemComments(this.hideSystemComments)
            .then(response => {
                this.getAlertComments();
                this.commentScrollWindow.scrollTop = 0;
            })
            .then(() => {
                this.showProgress(false);
            });
    }
    openReply(comment) {
        this.commentId = comment.CommentID;
        //console.log("comment-view.ts openReply comment id", this.commentId)
        //console.log("comment-view.ts openReply comment", comment);
        //this.showFullScreenComment(true);
    }
    refreshList() {
        this.getAlertComments();
    }
    getAllowProofHQ() {

        try {
            this.service.AllowProofHQ().then(response => {
                if (response) {
                    this.AllowProofHQ = response.content;
                    //console.log("ALLOW " + this.AllowProofHQ);
                }
            });
        } catch (e) {
            //console.log("dashboard.ts:loadCounts:AllowProofHQ:error", e);
        }

    }
    //editComment() {

    //}
    addComment(fullScreen: boolean = false) {
        let me = this;
        var comment = "";
        if (fullScreen === true) {
            comment = me.fullScreenComment.value();
        } else {
            comment = me.newCommentInput.value();
        }
        if (comment.trim() !== "") {
            me.showProgress(true);
            let commentMentions: MentionItem;
            if (this.commentDialogOpen) {
                commentMentions = this.mentionItemFull;
            } else {
                commentMentions = this.mentionItemNew
            }            
            comment = commentMentions.cleanupMentionTag(comment); 
            var linksString = "";
            if (me.links) {
                linksString = JSON.stringify(me.links);
            }
            me.syncFiles();
            if (me.fullScreenType == 1 && me.commentId && me.commentId > 0 && me.isEdit == true) {
                //console.log("save edit message!", comment);
                me.service.updateAlertCommentSimple(me.commentId, comment, commentMentions.mentions).then(response => {
                    me.showProgress(false);
                    me.getAlertComments();
                    me.commentScrollWindow.scrollTop = 0;
                    me.newCommentInput.value(null);
                    if (me.fileNames && me.fileNames.length > 0) {
                        me.attachmentAdded = true;
                    } else {
                        me.attachmentAdded = false;
                    }
                    if (me.attachmentUpload) {
                        me.attachmentUpload.removeAllFiles();
                        me.attachmentUpload.clearAllFiles();
                    }
                    me.links = [];
                    me.files = [];
                    me.fileNames = [];
                    commentMentions.mentions = [];
                    me.syncFiles();
                    me.urlTitle = null;
                    me.urlLink = null;
                    me.setUploadToFile();
                    if (me.commentAddedCallback) {
                        me.commentAddedCallback();
                    }
                    if (fullScreen) {
                        me.closeFullScreenComment();
                    }
                }).then(() => {
                    me.showProgress(false);
                });
            //    me.service.updateAlertComment(me.commentId, comment,
            //        me.fileNames, me.uploadToDocumentManager,
            //        me.uploadToProofHQ, linksString, commentMentions.mentions, me.documentId)
            //        .then(response => {
            //            me.showProgress(false);
            //            me.getAlertComments();
            //            me.commentScrollWindow.scrollTop = 0;
            //            me.newCommentInput.value(null);
            //            if (me.fileNames && me.fileNames.length > 0) {
            //                me.attachmentAdded = true;
            //            } else {
            //                me.attachmentAdded = false;
            //            }
            //            if (me.attachmentUpload) {
            //                me.attachmentUpload.removeAllFiles();
            //                me.attachmentUpload.clearAllFiles();
            //            }
            //            me.links = [];
            //            me.files = [];
            //            me.fileNames = [];
            //            commentMentions.mentions = [];
            //            me.syncFiles();
            //            me.urlTitle = null;
            //            me.urlLink = null;
            //            me.setUploadToFile();
            //            if (me.commentAddedCallback) {
            //                me.commentAddedCallback();
            //            }
            //            if (fullScreen) {
            //                me.closeFullScreenComment();
            //            }
            //        })
            //        .then(() => {
            //            me.showProgress(false);
            //        });
            } else {
                me.service.addAlertComment(me.alertId, me.commentId, comment,
                    me.fileNames, me.uploadToDocumentManager,
                    me.uploadToProofHQ, linksString, commentMentions.mentions, me.documentId)
                    .then(response => {
                        me.showProgress(false);
                        me.getAlertComments();
                        me.commentScrollWindow.scrollTop = 0;
                        me.newCommentInput.value(null);
                        if (me.fileNames && me.fileNames.length > 0) {
                            me.attachmentAdded = true;
                        } else {
                            me.attachmentAdded = false;
                        }
                        if (me.attachmentUpload) {
                            me.attachmentUpload.removeAllFiles();
                            me.attachmentUpload.clearAllFiles();
                        }
                        me.links = [];
                        me.files = [];
                        me.fileNames = [];
                        commentMentions.mentions = [];
                        me.syncFiles();
                        me.urlTitle = null;
                        me.urlLink = null;
                        me.setUploadToFile();
                        if (me.commentAddedCallback) {
                            me.commentAddedCallback();
                        }
                        if (fullScreen) {
                            me.closeFullScreenComment();
                        }
                    })
                    .then(() => {
                        me.showProgress(false);
                    });
            }

        } else {
            me.alert('Please enter a comment.');
        }
    }
    editEntry(entry: any) {
        //console.log("editComment from comment-view", entry);
        this.commentId = entry.CommentID;
        this.fullScreenComment.value(entry.Comment);
        this.showFullScreenComment(1);
    }
    activate(params: any) {
        if (params && params.AlertID) {
            //console.log("params", params);
            this.alertId = params.AlertID
            this.getAlertComments();
        }
    //    console.log("activate proof?", this.isProof)
    }
    attached() {
        //console.log("activate attached?", this.isProof)
        $(this.commentScrollWindow).scroll(() => {
            var topBox = true;
            var bottomBox = true;
            if ($(this.commentScrollWindow).scrollTop() === 0) {
                topBox = false;
            }
            if ($(this.commentScrollWindow).scrollTop() + $(this.commentScrollWindow).innerHeight() >= $(this.commentScrollWindow).prop('scrollHeight')) {
                bottomBox = false;
            }
            if (!topBox) {
                $(this.commentScrollWindow).removeClass('wv-scroll-box-shadow-top');
            } else if (!$(this.commentScrollWindow).hasClass('wv-scroll-box-shadow-top')) {
                $(this.commentScrollWindow).addClass('wv-scroll-box-shadow-top')
            }
            if (!bottomBox) {
                $(this.commentScrollWindow).removeClass('wv-scroll-box-shadow-bottom');
            } else if (!$(this.commentScrollWindow).hasClass('wv-scroll-box-shadow-bottom')) {
                $(this.commentScrollWindow).addClass('wv-scroll-box-shadow-bottom')
            }
        });         
    }
    constructor(service: AlertService) {
        super();
        this.service = service;
        let vm = this;
        vm.getAllowProofHQ();
        this.commentDialogActions = [
            {
                text: 'Add',
                primary: true,
                action: function (e) {
                    vm.addComment(true);
                }
            },
            {
                text: 'Cancel',
                primary: false,
                action: function (e) {
                    vm.closeFullScreenComment();
                }
            }
        ];
    }
}

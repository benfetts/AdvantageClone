import { inject, bindable } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { AlertModel } from 'models/desktop/alert-model';
import { MentionItem } from './mention-item';

@inject(DialogController)
export class AlertCommentDialog {

    @bindable saveLabel: string = 'Save'
    @bindable showUpload: boolean = false;

    controller: DialogController;
    editor: kendo.ui.Editor;
    showOk: boolean = false;
    Comment: string;
    Alert: AlertModel;
    mentionItemEditor: MentionItem;

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

    saveClick() {
        this.returnOk(true);
    }
    okClick() {
        this.returnOk(false);
    }
    cancelClick() {
        this.controller.cancel();
    }

    returnOk(send: boolean) {
        this.controller.ok({ Send: send, Comment: this.editor.value() });
    }

    activate(model: any) {
        this.Alert = model.Alert;
        this.Comment = model.Comment;
        if (model.SaveLabel) {
            this.saveLabel = model.SaveLabel;
        }
    }
    attached() {
        let me = this;
        
        $(document).ready(function () {
            me.editor.value(me.Comment);
            me.editor.focus();                        
            window.setTimeout(() => { me.mentionItemEditor.attachClickEventToMention("#editorCommentDiv"); }, 100);            
            me.mentionItemEditor.removeLineBreaksFromComment();            
            me.mentionItemEditor.populateMentions("#editorCommentDiv");            
        });
    }

    constructor(dialogController: DialogController) {
        this.controller = dialogController;
        this.controller.settings.centerHorizontalOnly = false;
        this.controller.settings.overlayDismiss = false;
    }

}

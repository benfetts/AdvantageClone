import { inject, bindable } from 'aurelia-framework';
import { AlertService } from 'services/desktop/alert-service';
import { ModuleBase } from 'modules/base/module-base';
import { responseTypeTransformer } from 'aurelia-http-client';
import { error } from 'jquery';

@inject(AlertService)
export class MentionItem extends ModuleBase {

    service: AlertService;
    mentions: Array<string> = [];
    mentionAutoComplete: kendo.ui.DropDownList;    
    mentionEmployeeDataSource: kendo.data.DataSource;
    mentionDeleteTemplate: string;    
    @bindable mentionCommentDiv: string;
    @bindable commentEditor: kendo.ui.Editor;
    @bindable verticalOffset: string;
    @bindable horizontalOffset: string;
    @bindable mentionContainer: string;        

    // methods
    editorAddInsertHTMLTool() {        
        let editor: any = $(this.commentEditor);

        //if the insertHTML toolbar item doesn't exist for Editor, add it
        if (editor[0]) {
            if (!editor[0].toolbar.options.tools.includes("insertHTML")) {
                editor[0].toolbar.options.tools.push("insertHTML");
            }   
        }             
    }    

    commentKeyDownEvent(e: KeyboardEvent) {         
        if (e.shiftKey && e.keyCode === 50) {             
            e.preventDefault();
            if (this.commentEditor) {
                this.editorAddInsertHTMLTool();
            }            
            
            let mentionDropDown;                        
            
            mentionDropDown = this.mentionAutoComplete;                        
            this.positionMentionAutoComplete();
            
            $(mentionDropDown).show();

            //set the selected item in the dropdown to a value outside the zero-based range of the selectable indexes
            //this will open the dropdown with nothing selected.
            mentionDropDown.select(mentionDropDown.dataSource._total);
            mentionDropDown.open();            
            //mentionDropDown.focus();            
        }

        return true;
    }
    preventEnter(e: KeyboardEvent) {
        if (e.keyCode == 13) {
            e.preventDefault;
        }
    }
    GetXY() {
        let selector = "#" + this.mentionCommentDiv;
        let selection, range, rect;
        
        if (this.commentEditor) {
            let iframe: any = $(selector).find("iframe").get(0);
            var idoc = iframe.contentDocument || iframe.contentWindow.document;
            selection = idoc.getSelection();

            range = selection.getRangeAt(0);            
            rect = range.getClientRects()[0];            
        } else {
            selection = window.getSelection();
            range = selection.getRangeAt(0).cloneRange();            
            range.collapse(true);
            rect = range.getClientRects()[0];

            if (!rect) {
                let testElement = $('#replyInputComment').get(0);
                //let element = document.getElementById("replyInputComment");
                rect = testElement.getBoundingClientRect();                
            }                
        }        
        
        return rect;
    }

    positionMentionAutoComplete() {        
        let rect: any | undefined = this.GetXY();
        let xOffset = 0;
        let yOffset = 0;        

        yOffset = this.verticalOffset == "0" ? -20 : parseInt(this.verticalOffset) - 20;        
        xOffset = this.horizontalOffset == "0" ? 15 : parseInt(this.horizontalOffset) + 15;

        if (rect !== undefined) {
            xOffset += rect.left;
            yOffset += rect.top;
        }

        if (this.commentEditor) {
            let el = document.getElementById(this.mentionContainer);
            el.style.position = "absolute";
            el.style.left = xOffset + "px";
            el.style.top = yOffset + "px";            
        }
        
        
    }    
    mentionAutoCompleteClose(e) {
        if (!this.commentEditor) {
            $("#replyInputComment").focus();
        }        
    }
    mentionAutoCompleteChange(e) {             
        let empCode = this.mentionAutoComplete.value();        
        let empName = this.mentionAutoComplete.text();   

        if (empCode.length < 1) {            
            return;
        }

        let styleText = "background-color:#E8F5FA;border-radius:3px;padding:2px;";
        let editor, commentDiv;        

        commentDiv = this.mentionCommentDiv;

        if (this.commentEditor) {
            editor = this.commentEditor;            
            editor.exec("inserthtml", { value: `<span id='${empCode}' contenteditable='false' class='mention-name' data-code='${empCode}' style='${styleText}'>@${empName}${this.mentionDeleteTemplate}<span contenteditable='false'>&nbsp;</span></span>&#xfeff;` });
        } else {            
            $("#replyInputComment").append(`<span id='${empCode}' contenteditable='false' class='mention-name' data-code='${empCode}' style='${styleText}'>@${empName}${this.mentionDeleteTemplate}<span contenteditable='false'>&nbsp;</span></span>`);            
        }        

        $(this.mentionAutoComplete).hide();             
        
        if (this.mentions) {
            if (!this.mentions.includes(empCode)) {
                this.mentions.push(empCode);
            }   
        }        

        this.attachClickEventToMention("#" + commentDiv, empCode);

        if (this.commentEditor) {
            this.cleanupNewMention("#" + commentDiv);
        } else {             
            let element = $("#replyInputComment");            
            element.focus();
            var range = document.createRange();
            var sel = window.getSelection();
            range.setStart(element.get(0), 1);
            range.collapse(true);
            sel.removeAllRanges();
            sel.addRange(range);
            element.focus();
            //var e = $.Event('keypress');
            //e.which = 65;
            //element.trigger(e);
        }
        

        this.mentionAutoCompleteClearFilter();      

        //set the selected item in the dropdown to a value outside the zero-based range of the selectable indexes
        //this will open the dropdown with nothing selected.
        this.mentionAutoComplete.select(this.mentionEmployeeDataSource.total());
        //e.preventDefault();     
    }

    mentionAutoCompleteClearFilter() {
        let filters = this.mentionEmployeeDataSource.filter();        

        if (filters) {
            //clear applied filters
            this.mentionEmployeeDataSource.filter({});
            this.mentionAutoComplete.text("");            
        }
    }

    removeLineBreaksFromComment() {        
        this.cleanupNewMention("#" + this.mentionCommentDiv);

        let editor = this.commentEditor;
        let range = editor.getRange() || editor.createRange();
        range.selectNodeContents(editor.body);
        range.collapse(false);
        editor.selectRange(range);
    }

    cleanupNewMention(commentDiv) {
        //the kendo editor is dynamically adding </br class="k-br"> tags around the newly added mention
        //remove them.         
        let editorIFrame = $(commentDiv).find("iframe");
        let mention = editorIFrame.contents().find("span.mention-name");        

        mention.siblings("br.k-br").remove();
    }

    mentionAutoCompleteReady(e) {         
        //k-on-ready    
    }      

    //addDeleteToMention() {
    //    let selector = "#" + this.mentionCommentDiv;
    //    let editorIFrame = $(selector).find("iframe");        
    //    let mention = editorIFrame.contents().find("span.mention-name");                  
        
    //    mention.append(this.mentionDeleteTemplate)       

    //    window.setTimeout(() => { this.attachClickEventToMention(selector)}, 1000);
    //}
    populateMentions(commentDiv) {
        let editorIFrame = $(commentDiv).find("iframe");
        let mentions: any = editorIFrame.contents().find("span.mention-name"); 

        for (let i = 0; i < mentions.length; i++) {            
            this.mentions.push(mentions[i].id);
        }        
    }

    attachClickEventToMention(commentDiv, empCode?) {                 
        let selector = "";        
        if (empCode) {            
            selector = "span#" + empCode + ".mention-name > span.delete-mention";;
        } else {
            selector = "span.mention-name > span.delete-mention";
        }
        
        let editorIFrame, mention;
        
        if (this.commentEditor) {
            editorIFrame = $(commentDiv).find("iframe");
            mention = editorIFrame.contents().find(selector);
        } else {
            let element = $("#replyInputComment");
            mention = element.find(selector);
        }        

        let me = this;        
        console.log(mention);
        
        mention.on("click", function(event) {
            let mentionElement = $(event.target).closest(".mention-name");            
            mentionElement.remove();
            me.removeMentionFromArray(mentionElement[0].id);
        });     
    }    

    removeMentionFromArray(mention) {        
        let index = this.mentions.indexOf(mention);        
        this.mentions.splice(index, 1);        
    }

    cleanupMentionTag(comment) {          
        let parsedComment = "";   
        let replaceTemplate: any = this.mentionDeleteTemplate;
        replaceTemplate = replaceTemplate.replaceAll(/'/g, '"');        
        comment = comment.replaceAll(replaceTemplate, '')

        if (!this.commentEditor) {
            comment = comment.replaceAll("<br>", '');
            comment = comment.replaceAll("<div>", '');
        }       
        
        parsedComment = comment;
        return parsedComment;
    }   

    //removeMentionDeleteSpan(alertBody){
    //    let parsedBody: string;
    //    //this.mentionDeleteTemplate;
    //    let replaceTemplate: any = this.mentionDeleteTemplate;        

    //    try {
    //        replaceTemplate = replaceTemplate.replaceAll(/'/g, '"');

    //        parsedBody = alertBody.replaceAll(replaceTemplate, '');

    //        parsedBody = alertBody;
    //    }
    //    catch (e) { }
    //    finally {
    //        parsedBody = alertBody;
    //    }

    //    return parsedBody
    //}

    attached() {   
        
    }

    constructor(service: AlertService) {
        super();
        this.service = service;                  
        this.mentionEmployeeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertRecipientsLookup'
                }
            }
        });        

        this.mentionDeleteTemplate = "<span class='delete-mention' contenteditable='false' style='font-weight:bold;margin-left:7px;' title='remove this mention'>X</span>";
        //$(document).ready(function () {              
        //});
    }

}

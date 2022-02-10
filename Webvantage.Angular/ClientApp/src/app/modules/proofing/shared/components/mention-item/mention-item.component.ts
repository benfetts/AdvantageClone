import { Component, ElementRef, EventEmitter, Input, Output, ViewChild, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
//import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { FeedbackService } from '../../../services/feedback.service';
import { IEmployeeMention } from '../../../interfaces/employee-mention';

declare var kendo: any;

@Component({
  selector: 'mention-item',
  templateUrl: './mention-item.component.html',
  styleUrls: ['./mention-item.component.css']
})
export class MentionItemComponent implements OnInit {
  //Comment Types:
  //  annotation - this is a mention for an annotation (standard comment)
  //  reply - this is a mention for a reply to a comment
  @Input() public commentType;
  @Input() public baseElementId;
  @Input() public textAreaId;


  public mentions: Array<string> = [];
  public mentionables: IEmployeeMention[];
  public mentionDeleteTemplate: string;
  public employees: Array<IEmployeeMention> = [];
  public mentionDropDownId ='';
  public mentionDropDownDivId = '';

  public listItems: Array<IEmployeeMention> = this.getEmployeesNew();

  public get mentionDropDownIdSelector() {
    return `#${ this.mentionDropDownId }`;
  }

  public get mentionDropDownDivIdSelector() {
    return `#${ this.mentionDropDownDivId }`;
  }

  public get baseElementSelector() {
    return `#${ this.baseElementId }`;
  }

  public get textAreaSelector() {
    return `#${ this.textAreaId }`;
  }

  commentKeyDown(e: KeyboardEvent) {
    let allow = false;

    if (e.shiftKey && e.keyCode == 50) {
      //only allow mentions if they follow a space
      //this will allow users to type an email address (etc.) without the @mention popping up
      allow = this.allowMention();

      if (allow) {
        e.preventDefault();
        this.hideMentionDropDown(false);
        kendo.jQuery("span[aria-owns='mentionDropDown_listbox'].k-widget.k-dropdown > .k-dropdown-wrap").hide();

        kendo.jQuery("#mentionDropDown-list").css("box-shadow", "none");
        kendo.jQuery("#mentionDropDown-list").css("border-bottom", "1px solid #ccccc");
        if (this.commentType == 'annotation') {
          this.positionMentionDropDown();
        } else {
          this.positionMentionDropDown(e);
        }

        let dropdown = kendo.jQuery(this.mentionDropDownIdSelector).data("kendoDropDownList");

        //this is called to show the items in the drop-down.
        //for some reason, the items in the datasource won't show without doing so, rendering an empty list.
        dropdown.dataSource.filter("");
        dropdown.list.width("auto");

        dropdown.select(dropdown.dataSource._total);
        dropdown.open();
      }
    }
  }

  getPlainText(comment) {
    let tempDiv = document.createElement("div");
    tempDiv.innerHTML = comment;
    return tempDiv.textContent || tempDiv.innerText || "";
  }

  allowMention() {
    let allow = false;
    let editor;
    editor = kendo.jQuery(this.textAreaSelector).data("kendoEditor");
    let commentText = editor.value();

    let plainText = this.getPlainText(commentText);
    let lastCharacter = plainText[plainText.length - 1];

    if (!lastCharacter) {
      //there was no previous character
      allow = true;
    } else {
      //insure the previous character was a space/empty
      if (lastCharacter.trim() !== "") {
        allow = false;
      } else {
        allow = true;
      }
    }

    return allow;
  }

  mentionAutoCompleteFiltering(e) {
    let me = this;

    setTimeout(function () {
      me.checkFilteredListCount();
    }, 0);
  }

  checkFilteredListCount() {
    let dropdown = kendo.jQuery(this.mentionDropDownIdSelector).data("kendoDropDownList");
    let editor = kendo.jQuery(this.textAreaSelector).data("kendoEditor");

    let items: HTMLCollection = dropdown.items();

    if (items.length == 0) {
      dropdown.close();

      let filterInput: any = dropdown.filterInput[0];
      let editorText = editor.value();
      editor.value(editorText + "@" + filterInput.value);

      //re-focus and move cursor to end
      editor.focus();
      let range = editor.createRange();
      range.selectNodeContents(editor.body);
      range.collapse(false);
      editor.selectRange(range);
    }
  }

  positionMentionDropDown(e?: KeyboardEvent) {
    let rect: any | undefined;
    let baseElement: any;
    let xOffset = 0;
    let yOffset = 0;

    if (this.commentType == 'annotation') {
      rect = this.GetXY();
      baseElement = document.getElementsByTagName("proof-textarea")[0];
      xOffset = 20;
      yOffset = -35;
    } else {
      let commentId;
      let eventSender: any = e;

      xOffset = 0;
      yOffset = 3;
      commentId = kendo.jQuery(eventSender.sender.element[0]).attr("editor-data");
      baseElement = document.getElementById(this.baseElementId);
    }

    let loc = baseElement.getBoundingClientRect();
    yOffset += loc.top;
    xOffset += loc.left;

    if (this.commentType == "annotation" && rect !== undefined) {
      xOffset += rect.left;
      yOffset += rect.top;
    }

    let el = document.getElementById(this.mentionDropDownDivId);
    el.style.position = "absolute";
    el.style.left = xOffset + "px";
    el.style.top = yOffset + "px";
  }

  GetXY() {
    let selection, range, rect;

    let iframe: any = kendo.jQuery(this.baseElementSelector).find("iframe").get(0);
    var idoc = iframe.contentDocument || iframe.contentWindow.document;
    selection = idoc.getSelection();

    range = selection.getRangeAt(0);
    rect = range.getClientRects()[0];

    return rect;
  }

  hideMentionDropDown(hide: boolean) {
    let dropdown = kendo.jQuery(this.mentionDropDownDivIdSelector);

    if (hide) {
      dropdown.addClass("mention-dropdown-hide");
      dropdown.removeClass("mention-dropdown-show");
    } else {
      dropdown.removeClass("mention-dropdown-hide");
      dropdown.addClass("mention-dropdown-show");
    }
  }

  mentionItemChange(value: any) {
    let empCode = value.Code;
    let empName = value.Name;

    if (empCode.length < 1) {
      return;
    }

    let styleText = "background-color:#E8F5FA;border-radius:3px;padding:2px;";


    //`<span id='${empCode}' contenteditable='false' class='mention-name' data-code='${empCode}' style='${styleText}'>@${empName}${this.mentionDeleteTemplate}</span>&nbsp;`)
  }

  mentionAutoCompleteChange(e) {
    let dropdown = kendo.jQuery(this.mentionDropDownIdSelector).data("kendoDropDownList");
    let empCode = dropdown.value();
    let empName = dropdown.text();

    if (empCode.length < 1) {
      return;
    }

    let styleText = "background-color:#E8F5FA;border-radius:3px;padding:2px;";
    let editor = kendo.jQuery(this.textAreaSelector).data("kendoEditor");

    editor.exec("inserthtml", { value: `<span id='${empCode}' contenteditable='false' class='mention-name' data-code='${empCode}' style='${styleText}'>@${empName}${this.mentionDeleteTemplate}</span>&nbsp;` });
    this.hideMentionDropDown(true);

    var found = false;
    if (this.mentions.length > 0) {
      for (let i = 0; i < this.mentions.length; i++) {
        if (this.mentions[i] == empCode) {
          found = true;
        }
      }
      if (found == false) {
        this.mentions.push(empCode);
      }
    } else {
      this.mentions.push(empCode);
    }

    this.attachClickEventToMention(this.baseElementSelector);
    this.cleanupNewMention(this.baseElementSelector);

    this.mentionAutoCompleteClearFilter();
  }

  attachClickEventToMention(commentDiv) {
    let editorIFrame: any = kendo.jQuery(this.baseElementId).find("iframe");
    let mention = editorIFrame.contents().find("span > span.delete-mention");

    mention.on("click", function (event) {
      let mentionElement = kendo.jQuery(event.target).closest(".mention-name");
      mentionElement.remove();
    });
  }

  cleanupNewMention(commentDiv) {
    //the kendo editor is dynamically adding </br class="k-br"> tags around the newly added mention
    //remove them.
    let editorIFrame = kendo.jQuery(commentDiv).find("iframe");
    let mention = editorIFrame.contents().find("span.mention-name");

    mention.siblings("br.k-br").remove();
  }

  cleanupMentionTag(comment) {
    let parsedComment = "";
    let replaceTemplate: any = this.mentionDeleteTemplate;
    replaceTemplate = replaceTemplate.replaceAll(/'/g, '"');
    comment = comment.replaceAll(replaceTemplate, '')

    //if (!this.commentEditor) {
    //  comment = comment.replaceAll("<br>", '');
    //  comment = comment.replaceAll("<div>", '');
    //}

    parsedComment = comment;
    return parsedComment;
  }

  mentionAutoCompleteClearFilter() {
    kendo.jQuery(this.mentionDropDownIdSelector).data("kendoDropDownList").text("");
  }
  getEmployeesNew() {

    let result: Array<IEmployeeMention> = [];
    this.feedbackService.loadEmployeesNew().subscribe(resp => {
      if (resp) {
        for (let i = 0; i < resp.length; i++) {
          result.push(resp[i]);
        }
      }
    });

    return result;
  }

  constructor(private feedbackService: FeedbackService) {
    this.mentionDeleteTemplate = "<span class='delete-mention' style='font-weight:bold;margin-left:7px;' title='remove this mention'>X</span>";
  }

  ngAfterViewInit() {
    this.employees = this.getEmployeesNew();
    let me = this;
    kendo.jQuery(this.mentionDropDownIdSelector).kendoDropDownList({
      dataSource: this.employees,
      dataTextField: "employeeName",
      dataValueField: "employeeCode",
      filter: "contains",
      autowidth: "false",
      width: 200,
      change: (e) => {
        me.mentionAutoCompleteChange(e);
      },
      filtering: (e) => {
        me.mentionAutoCompleteFiltering(e);
      }
    });

    me.hideMentionDropDown(true);
  }

  ngOnInit(): void {
    this.mentionDropDownDivId = `mentionDiv-${this.baseElementId}`;
    this.mentionDropDownId = `mention-${this.baseElementId}`;
  }

}

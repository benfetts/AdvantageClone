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

  @ViewChild('myEditor', { static: true }) editor: ElementRef;
  @ViewChild('myDropDown', { static: false }) mentionDropDown: ElementRef;

  public mentions: Array<string> = [];
  public mentionables: IEmployeeMention[];
  public mentionDeleteTemplate: string;
  public employees: Array<IEmployeeMention> = [];

  public listItems: Array<IEmployeeMention> = this.getEmployeesNew();

  commentKeyDown(e: KeyboardEvent) {
    if (e.shiftKey && e.keyCode == 50) {
      e.preventDefault();      
      this.hideMentionDropDown(false);
      console.log("out");
      kendo.jQuery("span[aria-owns='mentionDropDown_listbox'].k-widget.k-dropdown > .k-dropdown-wrap").hide();

      kendo.jQuery("#mentionDropDown-list").css("box-shadow", "none");
      kendo.jQuery("#mentionDropDown-list").css("border-bottom", "1px solid #ccccc");
      if (this.commentType == 'annotation') {
        this.positionMentionDropDown();
      } else {
        this.positionMentionDropDown(e);
      }

      //console.log(kendo.jQuery("#mentionDropDown"));
      let dropdown = kendo.jQuery("#mentionDropDown").data("kendoDropDownList");      

      //this is called to show the items in the drop-down.
      //for some reason, the items in the datasource won't show without doing so, rendering an empty list.
      dropdown.dataSource.filter("");
      dropdown.list.width("auto");

      dropdown.select(dropdown.dataSource._total);
      dropdown.open();
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

      //let editorElement = kendo.jQuery("textarea[editor-data='" + commentId + "']");      
      
      //baseElement = editorElement.get(0);
      baseElement = document.getElementById("editorDiv");
    }

    console.log(baseElement);
    let loc = baseElement.getBoundingClientRect()
    console.log(loc);

    yOffset += loc.top;
    xOffset += loc.left;

    if (this.commentType == "annotation" && rect !== undefined) {
      xOffset += rect.left;
      yOffset += rect.top;
    }

    let el = document.getElementById("mentionDropDownDiv");
    el.style.position = "absolute";
    el.style.left = xOffset + "px";
    el.style.top = yOffset + "px";
  }

  GetXY() {
    let selector = "#editorDiv";
    let selection, range, rect;

    let iframe: any = kendo.jQuery(selector).find("iframe").get(0);
    var idoc = iframe.contentDocument || iframe.contentWindow.document;
    selection = idoc.getSelection();

    range = selection.getRangeAt(0);
    rect = range.getClientRects()[0];

    return rect;
  }

  hideMentionDropDown(hide: boolean) {
    let dropdown = kendo.jQuery("#mentionDropDownDiv");    

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
    let dropdown = kendo.jQuery("#mentionDropDown").data("kendoDropDownList");
    let empCode = dropdown.value();
    let empName = dropdown.text();

    if (empCode.length < 1) {
      return;
    }

    let styleText = "background-color:#E8F5FA;border-radius:3px;padding:2px;";
    let editor, commentDiv;
    let commentId;

    if (this.commentType == 'reply') {
      commentId = kendo.jQuery("mention-item").attr("mention-data");
      console.log(commentId);

      editor = kendo.jQuery("textarea[editor-data='" + commentId + "']").data("kendoEditor");

    } else {
      editor = kendo.jQuery("#editor").data("kendoEditor");
    }
        
    commentDiv = "editorDiv";
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

    this.attachClickEventToMention("#editorDiv");
    this.cleanupNewMention("#editorDiv");

    this.mentionAutoCompleteClearFilter();
  }

  attachClickEventToMention(commentDiv) {
    let editorIFrame: any = kendo.jQuery(commentDiv).find("iframe");
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
    kendo.jQuery("#mentionDropDown").data("kendoDropDownList").text("");
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
    kendo.jQuery(this.mentionDropDown.nativeElement).kendoDropDownList({
      dataSource: this.employees,
      dataTextField: "employeeName",
      dataValueField: "employeeCode",
      filter: "contains",
      autowidth: "false",
      width: 200,
      change: (e) => {
        me.mentionAutoCompleteChange(e);
      }
    });

    me.hideMentionDropDown(true);
  }

  ngOnInit(): void {
  }

}

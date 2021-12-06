import { Component, ElementRef, EventEmitter, Input, Output, ViewChild, ViewEncapsulation, OnInit, OnChanges } from '@angular/core';
import '@progress/kendo-angular-editor';
import '@progress/kendo-ui';
import { FeedbackService } from '../../../services/feedback.service';
//import { IEmployeeMention } from '../../../interfaces/employee-mention';
import { MentionItemComponent } from '../../../shared/components/mention-item/mention-item.component';

declare var kendo: any;

@Component({
  selector: 'proof-textarea',
  templateUrl: './textarea.component.html',
  styleUrls: ['./textarea.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class TextareaComponent implements OnInit, OnChanges {
  @Input() public text = '';
  @Input() public disabled: boolean = false;
  @Output() public onChange: EventEmitter<string> = new EventEmitter<string>();
  @Output() public onMention: EventEmitter<string[]> = new EventEmitter<string[]>();

  @ViewChild('myEditor', { static: true }) editor: ElementRef;
  @ViewChild('overlay', { static: true }) overlay: ElementRef;
  @ViewChild('myMention', { static: true }) mentionItem: MentionItemComponent;

  public focus() {
    var control = kendo.jQuery(this.editor.nativeElement).data("kendoEditor");

    if (control) {
      control.focus();
    }

    //kendo.jQuery(this.editor.nativeElement).data("kendoEditor").focus();
  }

  textChanged(value: string): void {
    console.log('textChanged', value);
    this.text = value;
    this.onChange.emit(value);
    this.onMention.emit(this.mentionItem.mentions);
  }

  ngAfterViewInit() {
    let me = this;
    var foo = kendo.jQuery(this.editor.nativeElement).kendoEditor({
      value: this.text,
      change: function (e) {
        me.textChanged(this.value());
      },
      tools: [{ name: "insertHtml" }],
      keydown: (e) => {
        this.mentionItem.commentKeyDown(e);
      }
    });

    kendo.jQuery(".k-editor-toolbar-wrap").hide();
  }

  ngOnChanges(changes) {
    var kendoEditor = kendo.jQuery(this.editor.nativeElement).data('kendoEditor');

    if (kendoEditor && changes?.text) {
      kendoEditor.value(changes.text.currentValue);
    }
    else if (kendoEditor) {
      kendoEditor.value('');
    }
  }

  ngOnInit(): void {
    this.editor.nativeElement.value = this.text;
  }

  value(val : string): string {
    var kendoEditor = kendo.jQuery(this.editor.nativeElement).data('kendoEditor');

    if (kendoEditor) {
      return kendoEditor.value(val);
    }

    return '';
  }

  constructor(private feedbackService: FeedbackService) { }
}

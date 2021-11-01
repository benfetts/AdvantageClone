import { Component, Input, ViewEncapsulation } from "@angular/core";
import { FeedbackService } from "../../../../../services/feedback.service";
import { IFeedback } from "../../../../../interfaces/feedback";

const REPLY_PLACEHOLDER = 'Reply';

@Component({
  selector: 'proof-edit-feedback',
  templateUrl: './edit-feedback.component.html',
  styleUrls: ['./edit-feedback.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class EditFeedbackComponent {
  public replyPlaceholder = REPLY_PLACEHOLDER;
  public comment: string = '';

  @Input() public FeedBack: IFeedback;

  constructor(private feedbackService: FeedbackService) {

  }

  onSaveClick() {
    this.FeedBack.comment = this.comment;

    this.feedbackService.updateFeedback(this.FeedBack).subscribe((newFeedback: IFeedback) => {
      console.log(newFeedback);
    });
  }
}

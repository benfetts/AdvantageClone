import { Component, ViewEncapsulation, OnInit, ChangeDetectorRef } from '@angular/core';

import { IFeedback } from '../../../../interfaces/feedback';
import { FlagConstants } from '../constants/flag.constants';
import { IFlag } from '../../../../interfaces/flag';
import { FeedbackService } from '../../../../services/feedback.service';

@Component({
  selector: 'proof-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class FeedbacksComponent implements OnInit{
  //{alertId:0,assignedEmpCode:'ama',comment:'FUBAR',commentId:0,flagChecked:true}
  public feedback: IFeedback[] = [];
  public flag: IFlag = FlagConstants;

  constructor(private feedbackService: FeedbackService,
    private ref: ChangeDetectorRef) {

  }

  ngOnInit(): void {
    this.feedbackService.getFeedBack().subscribe(feedback => {
      console.log(feedback);
      this.feedback = feedback;
      this.ref.detectChanges();
    });
  }

  public onFlagClick(event): void {
    event.stopPropagation();
    this.flag.flagChecked = !this.flag.flagChecked;
  }

  public onNewComment(event): void {
    event.stopPropagation();

    console.log('create new comment here', event);

  //  var feedback =  {
  //    alertId: 260,
  //    assignedEmpCode: 'ama',
  //    comment: '',
  //    commentId: -1,
  //    flagChecked: false
  //  }

  //  this.feedbackService.createFeedback(feedback);
  }
}

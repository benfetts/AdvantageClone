


















/*   CTB-2006/06/23: Change the WHERE clause so that if either the start
     or the end date is null the record is filtered out of the resultant set

     CTB-2006/06/22: Made sure records are not being returned if both of the 
     following dates are null:  1) JOB_TRAFFIC_DET.JOB_REVISED_DATE  and 
     2) JOB_TRAFFIC_DET.TASK_START_DAT
     Segue issue number: 100 */


CREATE PROCEDURE [dbo].[usp_wv_traffic_gettimeline] 

@JobNumber int,
@JobComponent smallint

AS
Declare @TaskDescription as varchar(50)
set @TaskDescription = ' '
Declare @Milestone as int
set @Milestone = 2
Declare @Status as varchar(50)
set @Status = ' '
Declare @SeqNo as int
set @SeqNo = -1 
Declare @Phase as varchar(50)
set @Phase = ' '
Declare @PhaseOrder as int
Set @PhaseOrder = -1
Declare @TaskCode as varchar(50)
set @TaskCode = ' ' 
Declare @Spacer1 as char(3)
set @Spacer1 = '   '
Declare @Spacer2 as char(3)
set @Spacer2 = '   '
Declare @Spacer3 as char(3)
set @Spacer3 = '   '

SELECT '<B>' + TRAFFIC_PHASE.PHASE_DESC + '</B>' as 'Phase', 
       @Spacer1 as '&nbsp;&nbsp;', 
       @TaskCode as [Task Code], 
       @Spacer2 as '&nbsp;&nbsp;&nbsp;&nbsp;', 
       @TaskDescription as [Task Description], 
       @Spacer3 as '&nbsp;&nbsp;&nbsp;', 
       min(JOB_TRAFFIC_DET.TASK_START_DATE) as [Start Date&nbsp;&nbsp;&nbsp;&nbsp;], 
       max(JOB_TRAFFIC_DET.JOB_REVISED_DATE) as [End Date&nbsp;&nbsp;], 
       @Status as Status, 
       TRAFFIC_PHASE.PHASE_DESC as PhaseDesc, 
       @SeqNo as SeqNo,  
       ISNULL(TRAFFIC_PHASE.PHASE_ORDER,0) as PhaseOrder, 
       @Milestone as Milestone,'' AS EMP_CODE, -1 AS JOB_ORDER, -1 AS SortID
  FROM JOB_TRAFFIC_DET INNER JOIN TRAFFIC_PHASE on JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
 WHERE JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber and 
       JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComponent and
       Not ((JOB_TRAFFIC_DET.JOB_REVISED_DATE Is Null) Or (JOB_TRAFFIC_DET.TASK_START_DATE Is Null ))
 GROUP BY TRAFFIC_PHASE.PHASE_DESC,  TRAFFIC_PHASE.PHASE_ORDER

Union

SELECT @Phase as 'Phase', 
       @Spacer1 as '&nbsp;&nbsp;', 
       ('    ' + JOB_TRAFFIC_DET.FNC_CODE) as [Task Code], 
       @Spacer2 as '&nbsp;&nbsp;&nbsp;&nbsp;', 
       JOB_TRAFFIC_DET.TASK_DESCRIPTION as [Task Description], 
       @Spacer3 as '&nbsp;&nbsp;&nbsp;', 
       isnull(JOB_TRAFFIC_DET.TASK_START_DATE, getdate()) as [Start Date&nbsp;&nbsp;&nbsp;&nbsp;], 
       ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '          ') as [End Date&nbsp;&nbsp;],  
       ISNULL(JOB_TRAFFIC_DET.TASK_STATUS,' ') as Status,
       TRAFFIC_PHASE.PHASE_DESC as PhaseDesc, 
       JOB_TRAFFIC_DET.SEQ_NBR as SeqNo,  
       ISNULL(TRAFFIC_PHASE.PHASE_ORDER,0) as PhaseOrder, 
       ISNULL(JOB_TRAFFIC_DET.MILESTONE,0) as Milestone, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.JOB_ORDER, 0 AS SortID
  FROM JOB_TRAFFIC_DET INNER JOIN TRAFFIC_PHASE on JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
 WHERE JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber and 
       JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComponent and 
       Not ((JOB_TRAFFIC_DET.JOB_REVISED_DATE Is Null) Or (JOB_TRAFFIC_DET.TASK_START_DATE Is Null ))

union

SELECT @Phase as 'Phase', 
       @Spacer1 as '&nbsp;&nbsp;', 
       ('    ' + JOB_TRAFFIC_DET.FNC_CODE) as [Task Code], 
       @Spacer2 as '&nbsp;&nbsp;&nbsp;&nbsp', 
       JOB_TRAFFIC_DET.TASK_DESCRIPTION as [Task Description], 
       @Spacer3 as '&nbsp;&nbsp;&nbsp;', 
       isnull(JOB_TRAFFIC_DET.TASK_START_DATE, getdate()) as [Start Date&nbsp;&nbsp;&nbsp;&nbsp;], 
       ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, '          ') as [End Date&nbsp;&nbsp;],  
       ISNULL(JOB_TRAFFIC_DET.TASK_STATUS,' ') as Status,
       'no phase', 
       JOB_TRAFFIC_DET.SEQ_NBR as SeqNo,  
       -1, 
       ISNULL(JOB_TRAFFIC_DET.MILESTONE,0) as Milestone, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.JOB_ORDER, 0 AS SortID
  FROM JOB_TRAFFIC_DET
 WHERE JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber and 

       JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComponent and 
       JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID IS NULL and
       Not ((JOB_TRAFFIC_DET.JOB_REVISED_DATE Is Null) Or (JOB_TRAFFIC_DET.TASK_START_DATE Is Null ))

 ORDER BY 7, 8, 3












































/*****************************************************************
Webvantage
This Stored Procedure gets a Alerts by Employee Code, TypeID, CatID, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alerts] 
@EmpCode Varchar(6),
@TypeID Int, 
@CatID Int,
@Processed Varchar(1)
AS

SET NOCOUNT ON

If @TypeID > 0 
	If @CatID > 0 
		If @Processed = 'Y'
			SELECT    ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			and ALERT.ALERT_CAT_ID = @CatID
			and ALERT.ALERT_TYPE_ID = @TypeID
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC
		else
			SELECT     ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			and ALERT.ALERT_CAT_ID = @CatID
			and ALERT.ALERT_TYPE_ID = @TypeID
			and ALERT_RCPT.PROCESSED is  Null
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC
	Else
		If @Processed = 'Y'
			SELECT     ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			and ALERT.ALERT_TYPE_ID = @TypeID
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC
		else
			SELECT     ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			and ALERT.ALERT_TYPE_ID = @TypeID
			and ALERT_RCPT.PROCESSED is  Null
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC
else
		If @Processed = 'Y'
			SELECT     ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC
		else
			SELECT     ALERT_RCPT.ALERT_ID as AlertID,  ALERT_RCPT.ALERT_RCPT_ID as AlertRcptID,  ALERT.GENERATED as Date, ALERT.PRIORITY as Priority, ALERT.SUBJECT as Subject, ALERT_RCPT.PROCESSED as DateRead
			FROM         ALERT INNER JOIN
			                      ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
			WHERE     (ALERT_RCPT.EMP_CODE = @EmpCode)
			and ALERT_RCPT.PROCESSED is  Null
			ORDER BY ALERT.PRIORITY, ALERT.GENERATED DESC


























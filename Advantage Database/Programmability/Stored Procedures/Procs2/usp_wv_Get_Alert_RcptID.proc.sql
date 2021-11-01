




CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_RcptID]

@AlertID int,
@EmpCode Varchar(6),
@AlertRcptID as integer OUTPUT
AS

SELECT @AlertRcptID = ALERT_RCPT_ID FROM ALERT_RCPT
Where ALERT_ID = @AlertID and EMP_CODE = @EmpCode

If @@rowcount != 1 begin
set @AlertRcptID = 0
end























/*****************************************************************
Webvantage
This Stored Procedure gets Total number of Attachments by AlertID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_TotalAttachments] 
@AlertID Int
AS


SELECT Count(*) as totalattachments
FROM        ALERT_ATTACHMENT
WHERE     ALERT_ATTACHMENT.ALERT_ID = @AlertID


















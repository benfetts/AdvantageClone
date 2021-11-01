

/*****************************************************************
Webvantage
This Stored Procedure gets Total number of Attachments by AlertID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_TotalAttachments] 
@AlertID Int
AS


SELECT     COUNT(*) AS TotalAttachments
FROM         ALERT_ATTACHMENT
WHERE     (ALERT_ID = @AlertID)



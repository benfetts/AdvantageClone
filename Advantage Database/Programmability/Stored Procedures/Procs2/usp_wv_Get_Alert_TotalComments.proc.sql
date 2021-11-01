





/*****************************************************************
Webvantage
This Stored Procedure gets Total number of Comments by AlertID
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_TotalComments] 
@AlertID Int
AS


SELECT Count(*) as totalcomments
FROM        ALERT_COMMENT
WHERE     ALERT_COMMENT.ALERT_ID = @AlertID





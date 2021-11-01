




























/*****************************************************************
Webvantage
This Stored Procedure gets Alert Categories by Type
******************************************************************/
CREATE PROCEDURE [dbo].[usp_Get_Alert_Cat_By_TypeID] 
@Type Int
AS

SET NOCOUNT ON

Select ALERT_CAT_ID, ALERT_DESC from ALERT_CATEGORY
Where ALERT_TYPE_ID = @Type
ORDER BY ALERT_DESC



























